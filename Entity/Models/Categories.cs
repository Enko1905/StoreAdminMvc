using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("MainCategory")]
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }

    }
}
