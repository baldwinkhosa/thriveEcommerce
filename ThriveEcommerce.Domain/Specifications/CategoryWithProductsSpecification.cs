using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Specifications.Base;

namespace ThriveEcommerce.Domain.Specifications
{
    public sealed class CategoryWithProductsSpecification : BaseSpecification<Category>
    {
        public CategoryWithProductsSpecification(int categoryId) : base(b => b.Id == categoryId)
        {
            AddInclude(b => b.Id);
        }
    }
}
