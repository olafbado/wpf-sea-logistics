using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class CrewMember
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int RankId { get; set; }

    public virtual ICollection<CrewAssignment> CrewAssignments { get; set; } = new List<CrewAssignment>();

    public virtual Rank Rank { get; set; } = null!;
}
