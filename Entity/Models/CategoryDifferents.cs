using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CategoryDifferents
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Products Products { get; set; }

        [MaxLength(100)]
        public string CategoryName { get; set; }
    }

}
