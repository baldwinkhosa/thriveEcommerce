using System;using System.Collections.Generic;
using ThriveEcommerce.BusinessLibrary.Model;
using ThriveEcommerce.BusinessLibrary.Model.Base;

namespace ThriveEcommerce.BusinessLibrary.Model
{
    public class CartModel : BaseModel
    {
        public string UserName { get; set; }
        public List<CartItemModel> Items { get; set; } = new List<CartItemModel>();
    }
}
