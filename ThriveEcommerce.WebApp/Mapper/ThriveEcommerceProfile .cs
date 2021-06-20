using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Model;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Mapper
{
    public class ThriveEcommerceProfile : Profile
    {
        public ThriveEcommerceProfile()
        {
            CreateMap<ProductModel, ProductViewModel>().ReverseMap();
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
            CreateMap<CartModel, CartViewModel>().ReverseMap();
            CreateMap<CartItemModel, CartItemViewModel>().ReverseMap();
        }
    }
}
