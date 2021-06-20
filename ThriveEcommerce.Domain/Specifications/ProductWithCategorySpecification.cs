using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Specifications.Base;

namespace ThriveEcommerce.Domain.Specifications
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(string productName)
            : base(p => p.Name.ToLower().Contains(productName.ToLower()))
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification(int productId)
            : base(p => p.Id == productId)
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification()
            : base(null)
        {
            AddInclude(p => p.Category);
        }
    }
}
