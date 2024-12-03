using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class ShipCargo
{
    public int Id { get; set; }

    public int ShipId { get; set; }

    public int CargoId { get; set; }

    public int Quantity { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual Ship Ship { get; set; } = null!;
}
