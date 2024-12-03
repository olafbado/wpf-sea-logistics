using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Contract
{
    public int ContractId { get; set; }

    public int CargoId { get; set; }

    public int ShipId { get; set; }

    public string CustomerName { get; set; } = null!;

    public DateTime ContractDate { get; set; }

    public DateTime DeliveryDeadline { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual Ship Ship { get; set; } = null!;
}
