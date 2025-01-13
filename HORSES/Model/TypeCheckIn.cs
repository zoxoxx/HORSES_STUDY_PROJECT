using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class TypeCheckIn
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
}
