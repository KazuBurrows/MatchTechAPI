using MatchTech.Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentAPI.DAL;
using TournamentAPI.sakila;
using static MatchTech.Classes.Models.LinkedList;
using static MatchTech.Classes.Models.RoundRobinTimeTable;

namespace MatchTech.Classes.Models
{
	abstract class TournamentModel 
	{
        protected DbAa1c85MtechContext _context = new DbAa1c85MtechContext();
        public TimeTable Schedule { get; set; }
		protected string Name { get; set; }
		protected List<Team> Teams { get; set; }
		protected DateTime StartDate { get; set; }

		protected List<DateTime> HolidayDates { get; set; }
		protected List<DateTime> SpecialRequests { get; set; }

		protected abstract ISchedule FactoryMethod();
		protected abstract TimeTable InstansiateSchedule(Tournament t, DateTime d);
		protected abstract void PopulateSchedule();

	}


	internal class RoundRobin : TournamentModel
	{
        private IClubRepository clubRepository;
        private IClubsFieldRepository clubsFieldRepository;
        private IFieldRepository fieldRepository;
        private IMatchdayfixtureRepository matchdayfixtureRepository;
        private IMatchweekfixtureRepository matchweekfixtureRepository;
        private IMatchweekMatchdayRepository matchweekMatchdayRepository;
        private ITeamRepository teamRepository;
        private ITournamentRepository tournamentRepository;

        private int Rounds { get; set; }
		private List<string> MatchDays { get; set; }
		//private double MaxGamesPerWeek { get; set; }     // n !> rounds
		//private double SameTeamMatchGap { get; set; }

		private int TotalTeams { get; set; }
		private int TotalGames { get; set; }
		private int TotalWeeks { get; set; }
		private int TotalGamesPerWeek { get; set; }


		public RoundRobin(
			string name,
			List<Team> teams,
			DateTime startDate,
			List<DateTime> holidayDates,
			List<DateTime> specialRequests,
			List<string> matchDays,
			int rounds
		//double maxGamesPerWeek
		//double sameTeamMatchGap
		)
		{
			Name = name;
			Teams = ConstructTeams(teams);
			StartDate = startDate;
			HolidayDates = holidayDates;
			SpecialRequests = specialRequests;

			MatchDays = matchDays;

			Rounds = rounds;
			//MaxGamesPerWeek = maxGamesPerWeek;
			//SameTeamMatchGap = sameTeamMatchGap;

			TotalTeams = teams.Count();
			TotalGames = CalculateTotalGames();
			TotalWeeks = CalculateTotalWeeks();         // Without considering Holidays and Special Requests
			TotalGamesPerWeek = CalculateTotalGamesPerWeek();


            this.tournamentRepository = new TournamentRepository(_context);
            var tournament = new Tournament()
			{
				Name = this.Name,
				Matchweekfixtures = new List<Matchweekfixture>() { }
            };
            tournamentRepository.InsertTournament(tournament);
            tournamentRepository.Save();


			Schedule = InstansiateSchedule(tournament, startDate);
			PopulateSchedule();

			Schedule.PrintTimeTable();


			Console.WriteLine("END");

		}



		protected override TimeTable InstansiateSchedule(Tournament tournament, DateTime dateTime)
		{
			var product = FactoryMethod();
			var timeTable = product.TimeTable();

            this.matchweekfixtureRepository = new MatchweekfixtureRepository(_context);

            DateTime startDate;
            //int ceilTotalWeeks = (int)Math.Ceiling(TotalWeeks);
			for (int week=1; week<this.TotalWeeks + 1; week++)
			{
				startDate = dateTime.AddDays((week-1) * 7);

                var matchWeek = new Matchweekfixture()
                {
                    TournamentKey = tournament.Id,
                    Week = week,
                    StartDate = startDate,
                    EndDate = startDate.AddDays(7)
                };
                matchweekfixtureRepository.InsertMatchweekfixture(matchWeek);
                matchweekfixtureRepository.Save();

                timeTable.Add(matchWeek.Week, new MatchWeek(matchWeek));
            }

			return timeTable;
		}



		protected override void PopulateSchedule()
		{
            this.matchdayfixtureRepository = new MatchdayfixtureRepository(_context);
            this.matchweekMatchdayRepository = new MatchweekMatchdayRepository(_context);
            this.clubsFieldRepository = new ClubsFieldRepository(_context);

            Team[,] TDPairings = Create2DPairings();

			LinkedList.Node head = (LinkedList.Node)Schedule.GetData(1);
			LinkedList.Node curr = head;
            Console.WriteLine("this.TotalWeeks");
            Console.WriteLine(this.TotalWeeks);
            MatchweekMatchday matchweekMatchday;
			MatchWeek matchWeek;
            Matchdayfixture matchDay;
            Team homeTeam;
            Team awayTeam;
            int w = 0;
			while (w < (this.TotalWeeks))			// this.TotalWeeks should be used but is type double.
			{
				matchWeek = (MatchWeek)curr.Data;
				for (int i=0; i< TDPairings.GetLength(0); i++)
				{
					homeTeam = TDPairings[i, 0];
					awayTeam = TDPairings[i, 1];
					var fieldkey = clubsFieldRepository.GetClubsFields().Where(c => c.ClubKey == homeTeam.ClubId).FirstOrDefault().FieldKey;

                    matchDay = new Matchdayfixture()
					{
						DateTime = matchWeek.matchweekfixture.StartDate,
						HomeTeamKey = homeTeam.Id,
						AwayTeamKey = awayTeam.Id,
						FieldKey = fieldkey

                    };
					matchdayfixtureRepository.InsertMatchdayfixture(matchDay);
					matchdayfixtureRepository.Save();

					matchweekMatchday = new MatchweekMatchday()
					{
						MatchDayKey = matchDay.Id,
						MatchWeekKey = matchWeek.matchweekfixture.Id
					};

					matchweekMatchdayRepository.InsertMatchweekMatchday(matchweekMatchday);
					matchweekMatchdayRepository.Save();

                    matchWeek.MatchDays.Add(matchDay);
					
				}

                TDPairings = Rotate2DPairings(TDPairings);
				curr = curr.next;
				w++;
			}

		}


		

		

		private Team[,] Create2DPairings()
		{
			double halfTeam = this.Teams.Count() / 2;
            int y = (int)Math.Ceiling(halfTeam);

			Team[,] pairings = new Team[y, 2];
			List<Team> teamRowOne = this.Teams.Skip(0).Take(y).ToList();
			List<Team> teamRowTwo = this.Teams.Skip(y).Take(y).ToList();


            teamRowTwo.Reverse();

			for (int i=0; i<pairings.GetLength(0); i++)
			{
				pairings[i,0] = teamRowOne[i];
			}

			for (int j=0; j<pairings.GetLength(0); j++)
			{
				pairings[j,1] = teamRowTwo[j];
			}


            return pairings;
		}

		private Team[,] Rotate2DPairings(Team[,] pairings)
		{

            //string[,] pairings = new string[2, 2];
            //pairings[0, 0] = "A";
            //pairings[0, 1] = "B";
            //pairings[1, 0] = "D";
            //pairings[1, 1] = "C";


            var navi = new (int, int)[]
            {
				(0,1),(1,1),(1,0)
            };
            Team curr = pairings[navi[0].Item1, navi[0].Item2];
            Team next = pairings[navi[1].Item1, navi[1].Item2];

            (int, int) nextPos = navi[1];

            //int i = 0;
            int j = 1;
            //while (i < 3)
            //{
                while (j < 3)
                {

                    pairings[nextPos.Item1, nextPos.Item2] = curr;
                    curr = next;

                    nextPos = (j < 2) ? navi[j + 1] : navi[0];
                    next = pairings[nextPos.Item1, nextPos.Item2];







                    //Console.WriteLine("PAIRING START");
                    //Console.WriteLine(pairings[0, 0]);
                    //foreach (var n in navi)
                    //{
                    //    Console.WriteLine(pairings[n.Item1, n.Item2]);
                    //}
                    //Console.WriteLine("PAIRING END");

                    j++;
                }

                j = 1;
            //    i++;
            //}














   //         int fixedPivot = 0;

			//Team curr = pairings[1, 0];
   //         Team next = null;
			//int i = 1;
			//while (i<pairings.GetLength(0))
			//{
			//	if (i+1 >= pairings.GetLength(0))
			//	{
			//		next = pairings[i, 1];
					
			//		pairings[i, 1] = curr;
			//		curr = next;
			//		next = pairings[i - 1, 1];
			//		break;
			//	}

			//	next = pairings[i+1, 0];

			//	pairings[i+1, 0] = curr;
			//	curr = next;
			//	i++;

			//}
			////Console.WriteLine("CURR: " + curr + " Next: " + next);
			//i = pairings.GetLength(0)-2;
			//while (i > 0)
			//{

			//	pairings[i, 1] = curr;
			//	curr = next;
			//	next = pairings[i-1, 1];
				
				
			//	i--;

			//	if (i <= 0)
			//	{
			//		pairings[i, 1] = curr;
			//		pairings[i+1, 0] = next;
			//		break;
			//	}

			//}

   //         Console.WriteLine("pairings");
   //         Console.WriteLine(pairings[0, 0].Name);
   //         Console.WriteLine(pairings[0, 1].Name);
   //         Console.WriteLine(pairings[1, 1].Name);
   //         Console.WriteLine(pairings[1, 0].Name);
   //         Console.WriteLine("pairings");

            return pairings;
		}


		public void PrintTimeTable()
		{
			this.Schedule.PrintTimeTable();
		}

		protected override ISchedule FactoryMethod()
		{
			return new RoundRobinSchedule();
		}


		private List<Team> ConstructTeams(List<Team> teams)
		{
			if (teams.Count() % 2 == 1)
			{
                teams.Add(teamRepository.GetByeTeam());
            }

			return teams;
        }


        private int CalculateTotalGames()
		{
			return (this.TotalTeams > 3) ? ((this.TotalTeams * (this.TotalTeams - 1)) / 2) * this.Rounds : (this.TotalTeams * (this.TotalTeams - 1)) * this.Rounds;
		}

		private int CalculateTotalWeeks()
		{
            return ((this.TotalTeams - 1) * this.Rounds);
		}

		private int CalculateTotalGamesPerWeek()
		{
			return this.TotalTeams / 2;
		}
	}
}
