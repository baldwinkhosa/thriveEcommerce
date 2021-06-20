using System.Collections.Generic;
using ThriveEcommerce.BusinessLibrary.Model.Base;

namespace ThriveEcommerce.BusinessLibrary.Model
{
    public class CompareModel : BaseModel
    {
        public string UserName { get; set; }
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
    }
}
