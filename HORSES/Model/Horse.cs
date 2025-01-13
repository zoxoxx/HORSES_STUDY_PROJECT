using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Horse
{
    public int Id { get; set; }

    public int? GenderId { get; set; }

    public int? TypId { get; set; }

    public string? PhyoTrener { get; set; }

    public int? OwnerId { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Name { get; set; }

    public int? PlaceBirthId { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual Gender? Gender { get; set; }

    public virtual Owner? Owner { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual PlaceBirth? PlaceBirth { get; set; }

    public virtual TypHorse? Typ { get; set; }
}
