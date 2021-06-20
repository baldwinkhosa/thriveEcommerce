using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Interfaces;
using ThriveEcommerce.WebApp.Interfaces;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Services
{
    public class IndexPageService : IIndexPageService
    {
        private readonly IProductService _productAppService;
        private readonly IMapper _mapper;

        public IndexPageService(IProductService productAppService, IMapper mapper)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var list = await _productAppService.GetProductList();
            var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            return mapped;
        }
    }
}
