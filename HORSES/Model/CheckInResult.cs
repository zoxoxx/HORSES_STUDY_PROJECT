using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class CheckInResult
{
    public int Id { get; set; }

    public int? CheckInId { get; set; }

    public string? Indicator { get; set; }

    public decimal? Result { get; set; }

    public int? ParticipantId { get; set; }

    public TimeOnly? TimeEnd { get; set; }

    public virtual CheckIn? CheckIn { get; set; }

    public virtual Participant? Participant { get; set; }
}
