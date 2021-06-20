
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Model;

namespace ThriveEcommerce.BusinessLibrary.Interfaces
{
    public interface IWishlistService
    {
        Task<WishlistModel> GetWishlistByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int wishlistId, int productId);
    }
}
