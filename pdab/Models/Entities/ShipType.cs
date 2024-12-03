using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class ShipType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ShipTypeCargoType> ShipTypeCargoTypes { get; set; } = new List<ShipTypeCargoType>();

    public virtual ICollection<Ship> Ships { get; set; } = new List<Ship>();
}
