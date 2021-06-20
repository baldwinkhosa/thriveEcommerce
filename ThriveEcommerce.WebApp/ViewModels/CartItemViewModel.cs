using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels.Base;

namespace ThriveEcommerce.WebApp.ViewModels
{
    public class CartItemViewModel : BaseViewModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
