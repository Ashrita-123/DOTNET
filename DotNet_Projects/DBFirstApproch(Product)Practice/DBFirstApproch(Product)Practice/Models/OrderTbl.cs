using System;
using System.Collections.Generic;

namespace DBFirstApproch_Product_Practice.Models;

public partial class OrderTbl
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public virtual ICollection<BillTbl> BillTbls { get; set; } = new List<BillTbl>();

    public virtual CustomerTbl Customer { get; set; } = null!;

    public virtual ICollection<OrderItemId> OrderItemIds { get; set; } = new List<OrderItemId>();
}
