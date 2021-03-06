using ThriveEcommerce.Domain.Entities.Base;

namespace ThriveEcommerce.Domain.Entities
{
    public class CartItem : Entity
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
