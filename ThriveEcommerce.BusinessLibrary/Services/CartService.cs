using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<CartService> _logger;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, IAppLogger<CartService> logger)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CartModel> GetCartByUserName(string userName)
        {
            var cart = await GetExistingOrCreateNewCart(userName);
            var cartModel = ObjectMapper.Mapper.Map<CartModel>(cart);

            if (cart.Items.Any(c => c.Product == null)) // If product can not loaded from razor page, we apply manuel mapping.
            {
                cartModel.Items.Clear();
                foreach (var item in cart.Items)
                {
                    var cartItemModel = ObjectMapper.Mapper.Map<CartItemModel>(item);
                    var product = await _productRepository.GetProductByIdWithCategoryAsync(item.ProductId);
                    var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);
                    cartItemModel.Product = productModel;
                    cartModel.Items.Add(cartItemModel);
                }
            }

            return cartModel;
        }

        public async Task AddItem(string userName, int productId)
        {
            var cart = await GetExistingOrCreateNewCart(userName);

            var product = await _productRepository.GetByIdAsync(productId);
            cart.AddItem(productId, unitPrice: product.UnitPrice);
            await _cartRepository.UpdateAsync(cart);
        }

        public async Task RemoveItem(int cartId, int cartItemId)
        {
            var spec = new CartWithItemsSpecification(cartId);
            var cart = (await _cartRepository.GetAsync(spec)).FirstOrDefault();
            cart.RemoveItem(cartItemId);
            await _cartRepository.UpdateAsync(cart);
        }

        private async Task<Cart> GetExistingOrCreateNewCart(string userName)
        {
            var cart = await _cartRepository.GetByUserNameAsync(userName);
            if (cart != null)
                return cart;

            var newCart = new Cart
            {
                UserName = userName
            };

            await _cartRepository.AddAsync(newCart);
            return newCart;
        }

        public async Task ClearCart(string userName)
        {
            var cart = await _cartRepository.GetByUserNameAsync(userName);
            if (cart == null)
                throw new ApplicationException("Submitted order should have cart");

            cart.ClearItems();

            await _cartRepository.UpdateAsync(cart);
        }
    }
}
