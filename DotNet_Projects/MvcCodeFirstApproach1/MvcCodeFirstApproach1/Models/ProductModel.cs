using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCodeFirstApproach1.Models
{
    [Table("tblProduct")]
    public class Product
    {
            [Key]
            public int ProductId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
        
    }
}
