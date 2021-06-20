using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThriveEcommerce.WebApp.ViewModels;

namespace ThriveEcommerce.WebApp.Interfaces
{
    public interface IComparePageService
    {
        Task<CompareViewModel> GetCompare(string userName);
        Task RemoveItem(int compareId, int productId);
        Task AddToCart(string userName, int productId);
    }
}
