using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Horse> Horses { get; set; } = new List<Horse>();

    public virtual ICollection<UserI> UserIs { get; set; } = new List<UserI>();
}
