using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.Data.Data;
using ThriveEcommerce.Data.Repository.Base;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Repositories;
using ThriveEcommerce.Domain.Specifications;

namespace ThriveEcommerce.Data.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ThriveEcommerceContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cart> GetByUserNameAsync(string userName)
        {
            var spec = new CartWithItemsSpecification(userName);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
