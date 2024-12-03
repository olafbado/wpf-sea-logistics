using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class ShipMaintenance
{
    public int MaintenanceId { get; set; }

    public int ShipId { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual Ship Ship { get; set; } = null!;
}
