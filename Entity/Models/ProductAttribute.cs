using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductAttribute
    {
        [Key]
        public int ProductAttributeId { get; set; }

        [ForeignKey("Product")]
        public int?ProductId { get; set; }
        public Products Product { get; set; }


        [MaxLength(255)]
        public string Type { get; set; }
        [MaxLength(255)]
        public string Value { get; set; }

    }
}
