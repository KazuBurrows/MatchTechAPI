using System;
using System.Collections.Generic;

namespace TournamentAPI.sakila;

public partial class Club
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
