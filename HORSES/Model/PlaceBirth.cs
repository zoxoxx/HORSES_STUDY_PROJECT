using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class PlaceBirth
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Horse> Horses { get; set; } = new List<Horse>();
}
