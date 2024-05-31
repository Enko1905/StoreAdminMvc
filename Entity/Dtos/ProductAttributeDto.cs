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
    public class ProductAttributeDto
    {
        [MaxLength(255)]
        public string Type { get; set; }
        [MaxLength(255)]
        public string Value { get; set; }

    }
}
