using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class ShipTypeCargoType
{
    public int Id { get; set; }

    public int ShipTypeId { get; set; }

    public int CargoTypeId { get; set; }

    public virtual CargoType CargoType { get; set; } = null!;

    public virtual ShipType ShipType { get; set; } = null!;
}
