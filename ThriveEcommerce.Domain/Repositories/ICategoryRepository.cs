using System.Threading.Tasks;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Repositories.Base;

namespace ThriveEcommerce.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
}
