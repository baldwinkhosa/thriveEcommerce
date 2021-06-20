using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriveEcommerce.Domain.Entities
{
    public class ProductList
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ListId { get; set; }
        public List List { get; set; }
    }
}
