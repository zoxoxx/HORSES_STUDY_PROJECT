using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Participant
{
    public int Id { get; set; }

    public bool? Disqualification { get; set; }

    public int? ClothesSetId { get; set; }

    public int? HorseId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<CheckInResult> CheckInResults { get; set; } = new List<CheckInResult>();

    public virtual ClothesSet? ClothesSet { get; set; }

    public virtual ICollection<CompetitionAndCheckIn> CompetitionAndCheckIns { get; set; } = new List<CompetitionAndCheckIn>();

    public virtual Horse? Horse { get; set; }

    public virtual UserI? User { get; set; }

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();

}
