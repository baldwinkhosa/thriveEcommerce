using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriveEcommerce.Domain.Entities
{
    public class ProductRelatedProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int RelatedProductId { get; set; }
        public Product RelatedProduct { get; set; }
    }
}
