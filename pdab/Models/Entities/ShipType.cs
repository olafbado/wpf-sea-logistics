using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class ShipType
{
    public int ShipTypeId { get; set; }

    public string Name { get; set; } = null!;
}
