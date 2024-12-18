﻿using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Port
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<PortFee> PortFees { get; set; } = new List<PortFee>();

    public virtual ICollection<ShipRoute> ShipRouteArrivalPorts { get; set; } = new List<ShipRoute>();

    public virtual ICollection<ShipRoute> ShipRouteDeparturePorts { get; set; } = new List<ShipRoute>();
}
