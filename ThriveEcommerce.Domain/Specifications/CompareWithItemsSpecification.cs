using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Specifications.Base;

namespace ThriveEcommerce.Domain.Specifications
{
    public class CompareWithItemsSpecification : BaseSpecification<Compare>
    {
        public CompareWithItemsSpecification(string userName) : base(p => p.UserName.ToLower().Contains(userName.ToLower()))
        {
            AddInclude(p => p.ProductCompares);
        }

        public CompareWithItemsSpecification(int compareId)
            : base(p => p.Id == compareId)
        {
            AddInclude(p => p.ProductCompares);
        }
    }
}
