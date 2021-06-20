using System.Threading.Tasks;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Repositories.Base;

namespace ThriveEcommerce.Domain.Repositories
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {
        Task<Wishlist> GetByUserNameAsync(string userName);
    }
}
