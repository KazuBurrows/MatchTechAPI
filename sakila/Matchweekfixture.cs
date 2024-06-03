using System;
using System.Collections.Generic;

namespace TournamentAPI.sakila;

public partial class Matchweekfixture
{
    public int Id { get; set; }

    public int TournamentKey { get; set; }

    public int Week { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Tournament TournamentKeyNavigation { get; set; } = null!;
}
