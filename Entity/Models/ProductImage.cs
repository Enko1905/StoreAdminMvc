using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Ürün Resmi tablosu
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string? ImageUrl { get; set; }
        public string? Alt { get; set; }
       
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products? Products { get; set; }


    }

}
