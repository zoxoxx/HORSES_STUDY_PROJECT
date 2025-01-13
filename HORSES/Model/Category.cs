using System;
using System.Collections.Generic;

namespace HORSES.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<UserI> UserIs { get; set; } = new List<UserI>();
}
