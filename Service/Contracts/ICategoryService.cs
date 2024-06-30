using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICategoryService:IServiceBase<Category>
    {
       public Task<List<Category>> GetAllById(int id);

    }
}
