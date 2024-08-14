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

        [Required,MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public uint? Stock { get; set; }

    

        [Required,MaxLength(1500)]
        public String Description { get; set; }

        [ForeignKey("SubCategory")]
        [Required]
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

        [Required,MaxLength(500)]
        public string ImageUrl { get; set; }
        [MaxLength(150)]
        public string? SKU { get; set; }

        public bool Status { get; set; } 
        public bool variousProduct { get; set; }
        public bool Featured { get; set; }

        public string? Tags { get; set; }

        public decimal? Weight { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
         
        public Category? Category { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
        public ICollection<ProductAttribute>? ProductAttributes { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public ICollection<ProductVariants>? productVariants { get; set; }
    }
}
