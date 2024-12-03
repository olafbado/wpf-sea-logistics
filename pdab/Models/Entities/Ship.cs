using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Ship
{
    public int ShipId { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Flag { get; set; } = null!;

    public int BuildYear { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();

    public virtual ICollection<FuelLog> FuelLogs { get; set; } = new List<FuelLog>();

    public virtual ICollection<PortFee> PortFees { get; set; } = new List<PortFee>();

    public virtual ICollection<ShipCargo> ShipCargos { get; set; } = new List<ShipCargo>();

    public virtual ICollection<ShipInspection> ShipInspections { get; set; } = new List<ShipInspection>();

    public virtual ICollection<ShipMaintenance> ShipMaintenances { get; set; } = new List<ShipMaintenance>();

    public virtual ICollection<ShipRoute> ShipRoutes { get; set; } = new List<ShipRoute>();
}
