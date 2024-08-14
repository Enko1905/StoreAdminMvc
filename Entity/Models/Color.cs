using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Color
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string? ColorCode { get; set; }
        public ICollection<ProductVariants> ProductVariants { get; set; }
    }

}
