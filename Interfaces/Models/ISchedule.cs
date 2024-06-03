using MatchTech.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTech.Interfaces.Models
{
	internal interface ISchedule
	{
		TimeTable TimeTable();
	}

	class RoundRobinSchedule : ISchedule
	{
		public TimeTable TimeTable()
		{
			return new RoundRobinTimeTable();
		}

	}


	class KnockOutSchedule : ISchedule
	{
		public TimeTable TimeTable()
		{
			return new KnockOutTimeTable();
		}
	}
}
