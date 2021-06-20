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
    public class CompareRepository : Repository<Compare>, ICompareRepository
    {
        public CompareRepository(ThriveEcommerceContext dbContext) : base(dbContext)
        {
        }

        public async Task<Compare> GetByUserNameAsync(string userName)
        {
            var spec = new CompareWithItemsSpecification(userName);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
