using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Interfaces
{
    public interface ICheckOutPageService
    {
        Task<CartViewModel> GetCart(string userName);
        Task CheckOut(OrderViewModel order, string userName);
    }
}
