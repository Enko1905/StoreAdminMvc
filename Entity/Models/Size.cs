using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Size
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<ProductVariants> ProductVariants { get; set; }
    }

}
