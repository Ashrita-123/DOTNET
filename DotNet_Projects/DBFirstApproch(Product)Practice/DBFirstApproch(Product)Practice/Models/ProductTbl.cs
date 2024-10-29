using System;
using System.Collections.Generic;

namespace DBFirstApproch_Product_Practice.Models;

public partial class ProductTbl
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal ProductPice { get; set; }

    public DateOnly? ProductDate { get; set; }

    public virtual ICollection<OrderItemId> OrderItemIds { get; set; } = new List<OrderItemId>();
}
