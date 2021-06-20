using System.Threading.Tasks;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Repositories.Base;

namespace ThriveEcommerce.Domain.Repositories
{
    public interface ICompareRepository : IRepository<Compare>
    {
        Task<Compare> GetByUserNameAsync(string userName);
    }
}
