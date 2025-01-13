using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Track
{
    public int Id { get; set; }

    public string? Number { get; set; }

    public virtual ICollection<CompetitionAndCheckIn> CompetitionAndCheckIns { get; set; } = new List<CompetitionAndCheckIn>();
}
