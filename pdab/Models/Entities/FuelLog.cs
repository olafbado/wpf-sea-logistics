using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class FuelLog
{
    public int Id { get; set; }

    public int ShipId { get; set; }

    public DateTime Date { get; set; }

    public string FuelType { get; set; } = null!;

    public int Quantity { get; set; }

    public int Cost { get; set; }

    public virtual Ship Ship { get; set; } = null!;
}
