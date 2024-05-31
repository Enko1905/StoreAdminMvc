using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }

        ICollection<Products> products { get; set; }
    }
}
