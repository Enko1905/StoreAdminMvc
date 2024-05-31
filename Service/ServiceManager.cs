using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMainCategoryService> _mainCategoryService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ISubCategoryService> _subCategoryService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager ( 
            IMainCategoryService mainCategoryService,
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            IProductService productService)
        {
            _mainCategoryService = new Lazy<IMainCategoryService>(() => mainCategoryService);
            _categoryService = new Lazy<ICategoryService>(() => categoryService);
            _subCategoryService = new Lazy<ISubCategoryService>(()=>subCategoryService);
            _productService = new Lazy<IProductService>(() => productService);
            
        }
        public IMainCategoryService MainCategoryService => _mainCategoryService.Value;
        public ICategoryService CategoryService =>_categoryService.Value;
        public ISubCategoryService SubCategoryService =>_subCategoryService.Value;
        public IProductService ProductService => _productService.Value;
    }
}
