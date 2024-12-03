using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class ShipRoute
{
    public int RouteId { get; set; }

    public int ShipId { get; set; }

    public int DeparturePortId { get; set; }

    public int ArrivalPortId { get; set; }

    public DateTime DepartureDate { get; set; }

    public DateTime ArrivalDate { get; set; }

    public virtual Port ArrivalPort { get; set; } = null!;

    public virtual ICollection<CrewAssignment> CrewAssignments { get; set; } = new List<CrewAssignment>();

    public virtual Port DeparturePort { get; set; } = null!;

    public virtual Ship Ship { get; set; } = null!;
}
