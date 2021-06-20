using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.Domain.Entities.Base;

namespace ThriveEcommerce.Domain.Entities
{
    public class Contact : Entity
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [MinLength(10)]
        [Required]
        public string Message { get; set; }
    }

}
