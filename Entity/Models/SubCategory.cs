using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Alt Kategori tablosu
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required, MaxLength(300)]
        public string Description { get; set; }

        [Required, MaxLength(50)]
        public string MetaTitle { get; set; }

        [Required, MaxLength(300)]
        public string MetaDescription { get; set; }

        [Required]
        public bool Status { get; set; } = true;

        public ICollection<Products>? Products { get; set; }

    }

}
