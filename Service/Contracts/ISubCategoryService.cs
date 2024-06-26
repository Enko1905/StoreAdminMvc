﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISubCategoryService:IServiceBase<SubCategory>
    {
        public Task<List<SubCategory>> GetAllById(int id);

    }
}
