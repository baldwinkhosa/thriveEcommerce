using ThriveEcommerce.BusinessLibrary.Model;
using System.Threading.Tasks;

namespace ThriveEcommerce.BusinessLibrary.Interfaces
{
    public interface ICartService
    {
        Task<CartModel> GetCartByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int cartId, int cartItemId);
        Task ClearCart(string userName);
    }
}
