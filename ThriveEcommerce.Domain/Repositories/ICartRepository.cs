using System.Threading.Tasks;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Repositories.Base;

namespace ThriveEcommerce.Domain.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart> GetByUserNameAsync(string userName);
    }
}
