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
    public class WishListService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<WishListService> _logger;

        public WishListService(IWishlistRepository wishlistRepository, IProductRepository productRepository, IAppLogger<WishListService> logger)
        {
            _wishlistRepository = wishlistRepository ?? throw new ArgumentNullException(nameof(wishlistRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<WishlistModel> GetWishlistByUserName(string userName)
        {
            var wishlist = await GetExistingOrCreateNewWishlist(userName);
            var wishlistModel = ObjectMapper.Mapper.Map<WishlistModel>(wishlist);

            foreach (var item in wishlist.ProductWishlists)
            {
                var product = await _productRepository.GetProductByIdWithCategoryAsync(item.ProductId);
                var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);
                wishlistModel.Items.Add(productModel);
            }

            return wishlistModel;
        }

        public async Task AddItem(string userName, int productId)
        {
            var wishlist = await GetExistingOrCreateNewWishlist(userName);
            wishlist.AddItem(productId);
            await _wishlistRepository.UpdateAsync(wishlist);
        }

        public async Task RemoveItem(int wishlistId, int productId)
        {
            var spec = new WishlistWithItemsSpecification(wishlistId);
            var wishlist = (await _wishlistRepository.GetAsync(spec)).FirstOrDefault();
            wishlist.RemoveItem(productId);
            await _wishlistRepository.UpdateAsync(wishlist);
        }

        private async Task<Wishlist> GetExistingOrCreateNewWishlist(string userName)
        {
            var wishlist = await _wishlistRepository.GetByUserNameAsync(userName);
            if (wishlist != null)
                return wishlist;

            var newWishlist = new Wishlist
            {
                UserName = userName
            };

            await _wishlistRepository.AddAsync(newWishlist);
            return newWishlist;
        }
    }
}
