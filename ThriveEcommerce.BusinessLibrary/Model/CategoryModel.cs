
using ThriveEcommerce.BusinessLibrary.Model.Base;

namespace ThriveEcommerce.BusinessLibrary.Model
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}
