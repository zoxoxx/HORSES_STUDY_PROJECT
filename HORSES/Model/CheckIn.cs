using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class CheckIn
{
    public int Id { get; set; }

    public int? TypeCheckInId { get; set; }

    public int? SequenceNumber { get; set; }

    public decimal? PrizeFund { get; set; }

    public TimeOnly? TimeStart { get; set; }

    public DateOnly? DateStart { get; set; }

    public int? Distance { get; set; }

    public string? Name { get; set; }

    public string? TypeHorseIdCollection { get; set; }

    public string? Age { get; set; }

    public string? PlaceBirthIdCollection { get; set; }

    public virtual ICollection<CheckInResult> CheckInResults { get; set; } = new List<CheckInResult>();

    public virtual ICollection<CompetitionAndCheckIn> CompetitionAndCheckIns { get; set; } = new List<CompetitionAndCheckIn>();

    public virtual TypeCheckIn? TypeCheckIn { get; set; }
}
