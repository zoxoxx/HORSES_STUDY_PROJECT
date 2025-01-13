using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class ClothesSet
{
    public int Id { get; set; }

    public string? HelmetForm { get; set; }

    public string? HelmetColor { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
