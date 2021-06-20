using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Model;

namespace ThriveEcommerce.BusinessLibrary.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<ProductModel> GetProductById(int productId);
        Task<ProductModel> GetProductBySlug(string slug);
        Task<IEnumerable<ProductModel>> GetProductByName(string productName);
        Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId);
        Task<ProductModel> Create(ProductModel productModel);
        Task Update(ProductModel productModel);
        Task Delete(ProductModel productModel);
    }
}
