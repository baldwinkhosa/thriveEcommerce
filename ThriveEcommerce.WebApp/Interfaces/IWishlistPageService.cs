using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Interfaces
{
    public interface IWishlistPageService
    {
        Task<WishlistViewModel> GetWishlist(string userName);
        Task RemoveItem(int wishlistId, int productId);
        Task AddToCart(string userName, int productId);
    }
}
