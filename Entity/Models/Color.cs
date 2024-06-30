using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Color
    {
        public int ColorId { get; set; }

        [MaxLength(50)]
        public string ColorName { get; set; }
        [MaxLength(20)]
        public string? ColorCode { get; set; }
        public ICollection<ProductVariants> ProductVariants { get; set; }
    }

}
