using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Rank
{
    public int RankId { get; set; }

    public string Name { get; set; } = null!;
}
