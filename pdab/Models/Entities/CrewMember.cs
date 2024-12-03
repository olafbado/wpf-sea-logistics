using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class CrewMember
{
    public int CrewMemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Rank { get; set; } = null!;

    public int ShipId { get; set; }

    public virtual ICollection<CrewAssignment> CrewAssignments { get; set; } = new List<CrewAssignment>();

    public virtual Ship Ship { get; set; } = null!;
}
