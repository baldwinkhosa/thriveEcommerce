using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Interfaces
{
    public interface IIndexPageService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
    }
}
