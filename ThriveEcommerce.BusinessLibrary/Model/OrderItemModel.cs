using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Model.Base;

namespace ThriveEcommerce.BusinessLibrary.Model
{
    public class OrderItemModel : BaseModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
