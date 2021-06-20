using ThriveEcommerce.Domain.Entities.Base;

namespace ThriveEcommerce.Domain.Entities
{
    public class Specification : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
