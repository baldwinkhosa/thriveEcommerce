using System.ComponentModel.DataAnnotations;
using ThriveEcommerce.Domain.Entities.Base;

namespace ThriveEcommerce.Domain.Entities
{
    public class Blog : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
