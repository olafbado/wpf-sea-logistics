using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class PortFee
{
    public int FeeId { get; set; }

    public int PortId { get; set; }

    public int ShipId { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public virtual Port Port { get; set; } = null!;

    public virtual Ship Ship { get; set; } = null!;
}
