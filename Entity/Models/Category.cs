using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    // Kategori tablosu
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MainCategory")]
        public int MainCategoryId { get; set; }
        MainCategory MainCategory { get; set; }


        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(300)]
        public string Description { get; set; }

        [Required, MaxLength(50)]
        public string MetaTitle { get; set; }

        [Required, MaxLength(300)]
        public string MetaDescription { get; set; }

        [Required]
        public bool Status { get; set; } = true;

        public ICollection<SubCategory> SubCategories { get; set; } 
        public ICollection<Products> Products { get; set; }
    }

}
