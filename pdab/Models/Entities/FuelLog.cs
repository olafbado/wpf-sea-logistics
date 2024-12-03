using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class FuelLog
{
    public int FuelLogId { get; set; }

    public int ShipId { get; set; }

    public DateTime Date { get; set; }

    public string FuelType { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal Cost { get; set; }

    public virtual Ship Ship { get; set; } = null!;
}
