using System;
using System.Collections.Generic;

namespace DBFirstApproch_Product_Practice.Models;

public partial class OrderItemId
{
    public int OrderItemId1 { get; set; }

    public int OrderId { get; set; }

    public int PropductId { get; set; }

    public int NoOfItems { get; set; }

    public virtual OrderTbl Order { get; set; } = null!;

    public virtual ProductTbl Propduct { get; set; } = null!;
}
