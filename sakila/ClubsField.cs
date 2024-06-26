﻿using System;
using System.Collections.Generic;

namespace TournamentAPI.sakila;

public partial class ClubsField
{
    public int Id { get; set; }
    public int ClubKey { get; set; }

    public int FieldKey { get; set; }

    public virtual Club ClubKeyNavigation { get; set; } = null!;

    public virtual Field FieldKeyNavigation { get; set; } = null!;
}
