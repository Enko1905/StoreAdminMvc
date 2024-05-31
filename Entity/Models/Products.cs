using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Products
    {

        [Key]
        public int Id { get; set; }
        // [Required(ErrorMessage ="Ürün Adı Boş")]
        //[MaxLength(250, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]

        public string ProductName { get; set; } = string.Empty;
        public string? ImagesUrl { get; set; } = string.Empty;
        //[Required(ErrorMessage = "CategoryId Boş olamaz")]
        [ForeignKey("SubCategory")] // Categories ile olan ilişkiyi belirtmek için
        public int SubCategoryId { get; set; } // Zorunlu CategoryId
        public SubCategory SubCategory { get; set; }

        public List<ProductAttribute> ProductAttributes { get; set; }
        public String Description { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }

        public Decimal Price { get; set; }
        public int Stok { get; set; }
        public Products()
        {
            DateTime = DateTime.Now;
        }


    }
}
