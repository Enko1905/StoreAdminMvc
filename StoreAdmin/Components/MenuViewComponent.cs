using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Service.Contracts;

namespace StoreAdmin.Components
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IServiceManager _manager;

        public MenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var menuList=  await _manager.MainCategoryService.GetFullAll();
            return View(menuList);
        }
    }
}
