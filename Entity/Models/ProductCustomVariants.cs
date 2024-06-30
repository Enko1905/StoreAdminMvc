using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    //İptal Edildi
    public class ProductCustomVariants
    {
        [Key]
        public int ProductCustomVariantId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(int.MaxValue)]
        public uint Stock { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products Products { get; set; }
        [ForeignKey("productVariants")]
        public int VariantId { get; set; }
        public ProductVariants productVariants { get; set; }
    }

}
