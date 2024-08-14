using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Ana Kategori tablosu
    public class MainCategory
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }

        [Required,MaxLength(500)]
        public string Description { get; set; }

        [Required, MaxLength(50)]
        public string MetaTitle { get; set; }

        [Required,MaxLength(300)]
        public string MetaDescription { get; set; }
        [Required]
        public bool Status { get; set; } = true;
        public ICollection<Category> Category { get; set; }
    }

}
