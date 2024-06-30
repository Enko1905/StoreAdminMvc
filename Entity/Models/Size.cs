using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Size
    {
        public int SizeId { get; set; }

        [MaxLength(50)]
        public string SizeName { get; set; }
        public ICollection<ProductVariants> ProductVariants { get; set; }
    }

}
