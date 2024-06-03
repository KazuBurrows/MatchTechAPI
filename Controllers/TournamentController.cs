using MatchTech.Classes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentAPI.DAL;
using TournamentAPI.sakila;
using static TournamentAPI.DAL.ContextRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TournamentAPI.Controllers
{
    [Route("api/TournamentController")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        DbAa1c85MtechContext _context = new DbAa1c85MtechContext();
        private IClubRepository clubRepository;
        private IClubsFieldRepository clubsFieldRepository;
        private IFieldRepository fieldRepository;
        private IMatchdayfixtureRepository matchdayfixtureRepository;
        private IMatchweekfixtureRepository matchweekfixtureRepository;
        private IMatchweekMatchdayRepository matchweekMatchdayRepository;
        private ITeamRepository teamRepository;
        private ITournamentRepository tournamentRepository;

        // GET: api/<TournamentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public class ApiParam
        {
            public string TournamentName { get; set; }
            public string TournamentType { get; set; }
            public List<int> Teams { get; set; }
            public DateTime StartDate { get; set; }
            public int Rounds { get; set; }
        }

        public class DeleteParam
        {
            public int Id { get; set; }
        }

        public class EditParam
        {
            public int matchdayId { get; set; }
            public int oldMatchweekId { get; set; }
            public int newMatchweekId { get; set; }
            public DateTime dateTime { get; set; }
            public int fieldId { get; set; }
        }

        // POST api/<TournamentController>
        [HttpPost]
        public async Task<IEnumerable<string>> Post([ModelBinder] ApiParam TournamentObj)
        {
            Console.WriteLine(TournamentObj.TournamentName);
            Console.WriteLine("Post");

            this.teamRepository = new TeamRepository(_context);

            List<Team> myTeams = new List<Team>();
            foreach (int id in TournamentObj.Teams)
            {
                myTeams.Add(teamRepository.GetTeamByID(id));
            }



            RoundRobin roundRobin = new RoundRobin(
                TournamentObj.TournamentName,
                myTeams,
                TournamentObj.StartDate,
                new List<DateTime>() { },
                new List<DateTime>() { },
                new List<string>() { "Wednesday", "Saturday" },
                TournamentObj.Rounds
            );



            return new string[] { TournamentObj.TournamentName };
        }



        //[HttpPost]
        //public async Task<IEnumerable<string>> Delete([ModelBinder] DeleteParam json)
        //{
        //    this.tournamentRepository = new TournamentRepository(_context);
        //    this.matchweekMatchdayRepository = new MatchweekMatchdayRepository(_context);
        //    var matchweekMatchdaysList = matchweekMatchdayRepository.GetMatchweekMatchdays();

        //    Tournament tournament = tournamentRepository.GetTournamentByID(json.Id);
        //    List<Matchweekfixture> matchweekfixtures = tournament.Matchweekfixtures.ToList();
        //    List<MatchweekMatchday> matchweekMatchdays = new List<MatchweekMatchday>();
        //    foreach (var m in matchweekfixtures)
        //    {
        //        matchweekMatchdays.Add(matchweekMatchdaysList.Where(l => l.MatchWeekKey == m.Id).FirstOrDefault());
        //    };


        //    foreach (var m in matchweekMatchdays)
        //    {
        //        matchweekMatchdayRepository.DeleteMatchweekMatchday(m.Id);
        //    }
        //    tournamentRepository.DeleteTournament(tournament.Id);

        //    return new string[] { };
        //}



        //[HttpPost]
        //public async Task<IEnumerable<string>> Edit([ModelBinder] EditParam json)
        //{

        //    this.matchdayfixtureRepository = new MatchdayfixtureRepository(_context);
        //    this.matchweekMatchdayRepository = new MatchweekMatchdayRepository(_context);

        //    Matchdayfixture matchdayfixture = matchdayfixtureRepository.GetMatchdayfixtureByID(json.matchdayId);
        //    matchdayfixture.DateTime = json.dateTime;
        //    matchdayfixture.FieldKey = json.fieldId;
        //    matchdayfixtureRepository.UpdateMatchdayfixture(matchdayfixture);
        //    matchdayfixtureRepository.Save();

        //    var matchweekMatchdays = matchweekMatchdayRepository.GetMatchweekMatchdays();
        //    MatchweekMatchday matchweekMatchday = matchweekMatchdays.Where(m => m.MatchDayKey == matchdayfixture.Id && m.MatchWeekKey == json.oldMatchweekId).FirstOrDefault();
        //    matchweekMatchday.MatchWeekKey = json.newMatchweekId;
        //    matchweekMatchdayRepository.UpdateMatchweekMatchday(matchweekMatchday);
        //    matchweekMatchdayRepository.Save();


        //    return new string[] { };
        //}


    }
}
