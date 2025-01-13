using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Owner
{
    public int Id { get; set; }

    public string? Phyo { get; set; }

    public int? Age { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Horse> Horses { get; set; } = new List<Horse>();
}
