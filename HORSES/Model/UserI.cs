using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class UserI
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? Phyo { get; set; }

    public int? GenderId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? Age { get; set; }

    public DateOnly? Birthday { get; set; }

    public decimal? Weight { get; set; }

    public int? CategoryId { get; set; }

    public int? CityId { get; set; }

    public Guid? DistinctCode { get; set; }

    public virtual Category? Category { get; set; }

    public virtual City? City { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual Role? Role { get; set; }
}
