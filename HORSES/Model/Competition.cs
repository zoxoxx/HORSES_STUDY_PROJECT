using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Competition
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? DateStart { get; set; }

    public TimeOnly? TimeStart { get; set; }

    public virtual ICollection<CompetitionAndCheckIn> CompetitionAndCheckIns { get; set; } = new List<CompetitionAndCheckIn>();
}
