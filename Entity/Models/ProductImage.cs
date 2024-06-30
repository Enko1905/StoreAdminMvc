using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Ürün Resmi tablosu
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        [MaxLength(800)]
        public string? ImageUrl { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }

}
