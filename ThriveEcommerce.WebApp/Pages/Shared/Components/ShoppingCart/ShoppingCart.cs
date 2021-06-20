using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.Interfaces;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Pages.Shared.Components.ShoppingCart
{
    public class ShoppingCart : ViewComponent
    {
        private readonly ICartComponentService _cartComponentService;

        public ShoppingCart(ICartComponentService cartComponentService)
        {
            _cartComponentService = cartComponentService ?? throw new ArgumentNullException(nameof(cartComponentService));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartViewModel = new CartViewModel();
            if (!User.Identity.IsAuthenticated)
            {
                return View(cartViewModel);
            }

            cartViewModel = await _cartComponentService.GetCart(User.Identity.Name);
            return View(cartViewModel);
        }
    }
}

