using System.Collections.Generic;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Model;

namespace ThriveEcommerce.BusinessLibrary.Interfaces
{
   public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoryList();
    }
}
