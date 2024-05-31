using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IMainCategoryService MainCategoryService { get; }
        ICategoryService CategoryService { get; }
        ISubCategoryService SubCategoryService { get; }
        IProductService ProductService { get; }
    }
}
