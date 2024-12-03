using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class CargoType
{
    public int CargoTypeId { get; set; }

    public string Name { get; set; } = null!;
}
