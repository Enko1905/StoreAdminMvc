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
    public class SubCategoryDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
