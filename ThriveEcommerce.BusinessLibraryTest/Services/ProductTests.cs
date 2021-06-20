using Moq;
using System;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Services;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Interfaces;
using ThriveEcommerce.Domain.Repositories;
using ThriveEcommerce.Domain.Repositories.Base;
using Xunit;

namespace ThriveEcommerce.BusinessLibraryTest.Services
{
    public class ProductTests
    {
        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IRepository<Category>> _mockCategoryRepository;
        private Mock<IAppLogger<ProductService>> _mockAppLogger;

        public ProductTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockCategoryRepository = new Mock<IRepository<Category>>();
            _mockAppLogger = new Mock<IAppLogger<ProductService>>();
        }

        [Fact]
        public async Task Get_Product_List()
        {
            var category = Category.Create(It.IsAny<int>(), It.IsAny<string>());
            var product1 = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());
            var product2 = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());

            _mockCategoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(category);
            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product1);
            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product2);

            var productService = new ProductService(_mockProductRepository.Object, _mockAppLogger.Object);
            var productList = await productService.GetProductList();

            _mockProductRepository.Verify(x => x.GetProductListAsync(), Times.Once);
        }

        [Fact]
        public async Task Create_New_Product()
        {
            var category = Category.Create(It.IsAny<int>(), It.IsAny<string>());
            var product = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());
            Product nullProduct = null;

            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(nullProduct);
            _mockProductRepository.Setup(x => x.AddAsync(product)).ReturnsAsync(product);

            var productService = new ProductService(_mockProductRepository.Object, _mockAppLogger.Object);
            var createdProductDto = await productService.Create(new BusinessLibrary.Model.ProductModel { Id = product.Id, CategoryId = product.CategoryId, Name = product.Name });

            _mockProductRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockProductRepository.Verify(x => x.AddAsync(product), Times.Once);
        }

        [Fact]
        public async Task Create_New_Product_Validate_If_Exist()
        {
            var category = Category.Create(It.IsAny<int>(), It.IsAny<string>());
            var product = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());

            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
            _mockProductRepository.Setup(x => x.AddAsync(product)).ReturnsAsync(product);

            var productService = new ProductService(_mockProductRepository.Object, _mockAppLogger.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () =>
                await productService.Create(new BusinessLibrary.Model.ProductModel { Id = product.Id, CategoryId = product.CategoryId, Name = product.Name }));
        }
    }
}
