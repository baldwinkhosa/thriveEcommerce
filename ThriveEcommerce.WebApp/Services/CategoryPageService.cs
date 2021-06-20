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
    public class CategoryPageService : ICategoryPageService
    {
        private readonly ICategoryService _categoryAppService;
        private readonly IMapper _mapper;

        public CategoryPageService(ICategoryService categoryAppService, IMapper mapper)
        {
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var list = await _categoryAppService.GetCategoryList();
            var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
            return mapped;
        }
    }
}