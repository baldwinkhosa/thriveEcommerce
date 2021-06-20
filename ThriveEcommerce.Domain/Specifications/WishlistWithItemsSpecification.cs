using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Specifications.Base;

namespace ThriveEcommerce.Domain.Specifications
{
    public class WishlistWithItemsSpecification : BaseSpecification<Wishlist>
    {
        public WishlistWithItemsSpecification(string userName)
            : base(p => p.UserName.ToLower().Contains(userName.ToLower()))
        {
            AddInclude(p => p.ProductWishlists);
        }

        public WishlistWithItemsSpecification(int wishlistId)
            : base(p => p.Id == wishlistId)
        {
            AddInclude(p => p.ProductWishlists);
        }
    }
}
