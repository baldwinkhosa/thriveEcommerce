using ThriveEcommerce.WebApp.ViewModels.Base;

namespace ThriveEcommerce.WebApp.ViewModels
{
    public class OrderItemView : BaseViewModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
