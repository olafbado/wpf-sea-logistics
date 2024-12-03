using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Rank
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();
}
