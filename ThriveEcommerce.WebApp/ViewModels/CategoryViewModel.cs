using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels.Base;

namespace ThriveEcommerce.WebApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}
