using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Cargo
{
    public int CargoId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Weight { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<ShipCargo> ShipCargos { get; set; } = new List<ShipCargo>();
}
