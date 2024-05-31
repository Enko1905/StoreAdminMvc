using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
    public class CategoryViewModel
    {
        public List<SelectListItem> Categories { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}
