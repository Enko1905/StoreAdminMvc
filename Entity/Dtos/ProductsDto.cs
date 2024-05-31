using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductsDto
    {
     
        public string ProductName { get; set; } = string.Empty;
        public string? ImagesUrl { get; set; } = string.Empty;
        public int SubCategoryId { get; set; } 
        public String Description { get; set; } = string.Empty;
        public Decimal Price { get; set; }
        public int Stok { get; set; }
        
        public List<ProductAttributeDto>  productAttributes { get; set; }

    }
}
