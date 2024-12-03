using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Contract
{
    public int Id { get; set; }

    public int CargoId { get; set; }

    public string CustomerName { get; set; } = null!;

    public DateTime ContractDate { get; set; }

    public DateTime DeliveryDeadline { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual ICollection<ShipRoute> ShipRoutes { get; set; } = new List<ShipRoute>();
}
