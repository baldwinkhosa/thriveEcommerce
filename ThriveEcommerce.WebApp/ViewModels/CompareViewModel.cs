using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels.Base;

namespace ThriveEcommerce.WebApp.ViewModels
{
    public class CompareViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public List<ProductViewModel> Items { get; set; } = new List<ProductViewModel>();
    }
}
