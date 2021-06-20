using System;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Interfaces;
using ThriveEcommerce.BusinessLibrary.Mapper;
using ThriveEcommerce.BusinessLibrary.Model;
using ThriveEcommerce.Domain.Entities;
using ThriveEcommerce.Domain.Interfaces;
using ThriveEcommerce.Domain.Repositories;
using ThriveEcommerce.Domain.Specifications;

namespace ThriveEcommerce.BusinessLibrary.Services
{
    public class CompareService : ICompareService
    {
        private readonly ICompareRepository _compareRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<CompareService> _logger;

        public CompareService(ICompareRepository compareRepository, IProductRepository productRepository, IAppLogger<CompareService> logger)
        {
            _compareRepository = compareRepository ?? throw new ArgumentNullException(nameof(compareRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CompareModel> GetCompareByUserName(string userName)
        {
            var compare = await GetExistingOrCreateNewCompare(userName);
            var compareModel = ObjectMapper.Mapper.Map<CompareModel>(compare);

            foreach (var item in compare.ProductCompares)
            {
                var product = await _productRepository.GetProductByIdWithCategoryAsync(item.ProductId);
                var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);
                compareModel.Items.Add(productModel);
            }
            return compareModel;
        }

        public async Task AddItem(string userName, int productId)
        {
            var compare = await GetExistingOrCreateNewCompare(userName);
            compare.AddItem(productId);
            await _compareRepository.UpdateAsync(compare);
        }

        public async Task RemoveItem(int CompareId, int productId)
        {
            var spec = new CompareWithItemsSpecification(CompareId);
            var compare = (await _compareRepository.GetAsync(spec)).FirstOrDefault();
            compare.RemoveItem(productId);
            await _compareRepository.UpdateAsync(compare);
        }

        private async Task<Compare> GetExistingOrCreateNewCompare(string userName)
        {
            var compare = await _compareRepository.GetByUserNameAsync(userName);
            if (compare != null)
                return compare;

            var newCompare = new Compare
            {
                UserName = userName
            };

            await _compareRepository.AddAsync(newCompare);
            return newCompare;
        }

    }
}
