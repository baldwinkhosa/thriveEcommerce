using Microsoft.EntityFrameworkCore;
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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ThriveEcommerceContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            var spec = new ProductWithCategorySpecification();
            return await GetAsync(spec);
        }

        public async Task<Product> GetProductBySlug(string slug)
        {
            var spec = new ProductSlugSpecification(slug);
            return (await GetAsync(spec)).FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string productName)
        {
            var spec = new ProductWithCategorySpecification(productName);
            return await GetAsync(spec);
        }

        public async Task<Product> GetProductByIdWithCategoryAsync(int productId)
        {
            var spec = new ProductWithCategorySpecification(productId);
            return (await GetAsync(spec)).FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
        }

    }
}
