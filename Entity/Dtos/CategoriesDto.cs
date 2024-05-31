using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CategoriesDto
    {
        public string Name { get; set; }
        public int MainCategoryId { get; set; }
    }
}
