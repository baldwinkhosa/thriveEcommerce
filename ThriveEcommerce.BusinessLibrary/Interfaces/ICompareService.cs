using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Model;

namespace ThriveEcommerce.BusinessLibrary.Interfaces
{
    public interface ICompareService
    {
        Task<CompareModel> GetCompareByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int compareId, int productId);
    }
}
