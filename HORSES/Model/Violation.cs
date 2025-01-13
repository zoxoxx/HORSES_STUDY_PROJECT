using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Violation
{
    public int Id { get; set; }

    public string? Violations { get; set; }

    public int? ParticipantId { get; set; }

    public virtual Participant? Participant { get; set; }
}
