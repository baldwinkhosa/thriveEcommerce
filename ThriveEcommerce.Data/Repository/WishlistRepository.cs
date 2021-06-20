using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.Data.Data;
using ThriveEcommerce.Data.Repository.Base;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Repositories;
using ThriveEcommerce.Domain.Specifications;

namespace ThriveEcommerce.Data.Repository
{
    public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(ThriveEcommerceContext dbContext) : base(dbContext)
        {
        }

        public async Task<Wishlist> GetByUserNameAsync(string userName)
        {
            var spec = new WishlistWithItemsSpecification(userName);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
