using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Cargo
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int Weight { get; set; }

    public int CargoTypeId { get; set; }

    public virtual CargoType CargoType { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<ShipCargo> ShipCargos { get; set; } = new List<ShipCargo>();
}
