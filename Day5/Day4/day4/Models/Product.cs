using System;
using System.Collections.Generic;

namespace day4.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public float Price { get; set; }

    public string? Description { get; set; }
}
