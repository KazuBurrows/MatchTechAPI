using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentAPI.sakila;

namespace MatchTech.Classes.Models
{
	internal class MatchWeek
	{

		internal int Week { get; }
		internal Matchweekfixture matchweekfixture { get; }
		internal List<Matchdayfixture> MatchDays = new List<Matchdayfixture>();

		public MatchWeek(Matchweekfixture m)
		{
			Week = m.Week;
			matchweekfixture = m;
		}

		public void Add(Matchdayfixture m)
		{
			MatchDays.Add(m);
		}

		public void Remove(Matchdayfixture m)
		{
			MatchDays.Remove(m);
		}

		public override string ToString()
		{
			if (MatchDays.Count() == 0)
			{
				return "";
			}

			string str = "";
			foreach (Matchdayfixture m in MatchDays)
			{
				try
				{
					str += m.HomeTeamKeyNavigation.Name + " vs " + m.AwayTeamKeyNavigation.Name + " ";
				}
				catch {
					str += " null ";
				}
				
			}

			return str;
		}
	}
}
