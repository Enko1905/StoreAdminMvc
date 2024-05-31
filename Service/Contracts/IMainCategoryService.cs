using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMainCategoryService:IServiceBase<MainCategory>
    {
        public Task<List<MainCategory>> GetFullAll();
    }
}
