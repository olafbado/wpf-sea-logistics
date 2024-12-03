using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class ShipInspection
{
    public int InspectionId { get; set; }

    public int ShipId { get; set; }

    public string InspectorName { get; set; } = null!;

    public DateTime Date { get; set; }

    public string? Notes { get; set; }

    public virtual Ship Ship { get; set; } = null!;
}
