using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Model.Base;

namespace ThriveEcommerce.BusinessLibrary.Model
{
    public class WishlistModel : BaseModel
    {
        public string UserName { get; set; }
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
    }
}
