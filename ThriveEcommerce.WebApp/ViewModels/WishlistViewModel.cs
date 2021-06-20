using System.Collections.Generic;
using ThriveEcommerce.WebApp.ViewModels.Base;

namespace ThriveEcommerce.WebApp.ViewModels
{
    public class WishlistViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public List<ProductViewModel> Items { get; set; } = new List<ProductViewModel>();
    }
}
