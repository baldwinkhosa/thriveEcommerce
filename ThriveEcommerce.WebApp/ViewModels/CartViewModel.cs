using System;
using System.Collections.Generic;
using ThriveEcommerce.WebApp.ViewModels.Base;

namespace ThriveEcommerce.WebApp.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        public decimal GrandTotal
        {
            get
            {
                decimal grandTotal = 0;
                foreach (var item in Items)
                {
                    grandTotal += item.TotalPrice;
                }

                return grandTotal;
            }
        }
    }
}
