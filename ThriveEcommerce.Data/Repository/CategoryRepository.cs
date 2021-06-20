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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ThriveEcommerceContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetCategoryWithProductsAsync(int categoryId)
        {
            var spec = new CategoryWithProductsSpecification(categoryId);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
