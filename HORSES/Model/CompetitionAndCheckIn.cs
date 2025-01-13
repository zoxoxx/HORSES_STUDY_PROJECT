using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class CompetitionAndCheckIn
{
    public int Id { get; set; }

    public int? CompetitionId { get; set; }

    public int? CheckInId { get; set; }

    public int? ParticipantId { get; set; }

    public int? TrackId { get; set; }

    public virtual CheckIn? CheckIn { get; set; }

    public virtual Competition? Competition { get; set; }

    public virtual Participant? Participant { get; set; }

    public virtual Track? Track { get; set; }
}
