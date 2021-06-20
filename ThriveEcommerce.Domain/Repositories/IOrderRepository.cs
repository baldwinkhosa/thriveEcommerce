using System.Collections.Generic;
using System.Threading.Tasks;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Repositories.Base;

namespace ThriveEcommerce.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUserNameAsync(string userName);
    }
}
