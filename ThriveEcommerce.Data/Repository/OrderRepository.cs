using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.Data.Data;
using ThriveEcommerce.Data.Repository.Base;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Repositories;

namespace ThriveEcommerce.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ThriveEcommerceContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Order>> GetOrderByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
