using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Interfaces
{
    public interface ICartComponentService
    {
        Task<CartViewModel> GetCart(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int cartId, int cartItemId);
    }
}
