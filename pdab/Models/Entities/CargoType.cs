using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class CargoType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual ICollection<ShipTypeCargoType> ShipTypeCargoTypes { get; set; } = new List<ShipTypeCargoType>();
}
