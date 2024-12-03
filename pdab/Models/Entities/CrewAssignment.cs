using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class CrewAssignment
{
    public int Id { get; set; }

    public int ShipRouteId { get; set; }

    public int CrewMemberId { get; set; }

    public virtual CrewMember CrewMember { get; set; } = null!;

    public virtual ShipRoute ShipRoute { get; set; } = null!;
}
