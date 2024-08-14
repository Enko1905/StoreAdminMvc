using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CategoryDifferents
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products Products { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }

}
