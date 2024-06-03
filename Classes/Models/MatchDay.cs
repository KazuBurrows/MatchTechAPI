using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentAPI.sakila;

namespace MatchTech.Classes.Models
{
	internal class MatchDay
	{
		public int Id { get; }
		public Team HomeTeam { get; }
		public Team AwayTeam { get; }

		public MatchDay(int id, Team homeTeam, Team awayTeam)
		{
			Id = id;
			HomeTeam = homeTeam;
			AwayTeam = awayTeam;
		}

	}
}
