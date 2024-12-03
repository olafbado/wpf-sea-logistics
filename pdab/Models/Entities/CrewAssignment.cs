using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class CrewAssignment
{
    public int AssignmentId { get; set; }

    public int RouteId { get; set; }

    public int CrewMemberId { get; set; }

    public virtual CrewMember CrewMember { get; set; } = null!;

    public virtual ShipRoute Route { get; set; } = null!;
}
