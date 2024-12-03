using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Ship
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ShipTypeId { get; set; }

    public string Flag { get; set; } = null!;

    public int BuildYear { get; set; }

    public virtual ICollection<FuelLog> FuelLogs { get; set; } = new List<FuelLog>();

    public virtual ICollection<PortFee> PortFees { get; set; } = new List<PortFee>();

    public virtual ICollection<ShipCargo> ShipCargos { get; set; } = new List<ShipCargo>();

    public virtual ICollection<ShipInspection> ShipInspections { get; set; } = new List<ShipInspection>();

    public virtual ICollection<ShipMaintenance> ShipMaintenances { get; set; } = new List<ShipMaintenance>();

    public virtual ICollection<ShipRoute> ShipRoutes { get; set; } = new List<ShipRoute>();

    public virtual ShipType ShipType { get; set; } = null!;
}
