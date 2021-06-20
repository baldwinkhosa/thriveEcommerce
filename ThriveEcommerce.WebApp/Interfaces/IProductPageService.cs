using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Interfaces
{
    public interface IProductPageService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts(string productName);
        Task<ProductViewModel> GetProductById(int productId);
        Task<ProductViewModel> GetProductBySlug(string slug);
        Task<IEnumerable<ProductViewModel>> GetProductByCategory(int categoryId);
        Task<IEnumerable<CategoryViewModel>> GetCategories();

        Task AddToCart(string userName, int productId);
        Task AddToWishlist(string userName, int productId);
        Task AddToCompare(string userName, int productId);
    }
}
