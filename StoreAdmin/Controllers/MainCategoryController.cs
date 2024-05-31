using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Service.Contracts;
using StoreAdmin.Extensions;

namespace StoreAdmin.Controllers
{
    public class MainCategoryController : Controller
    {

        public readonly IServiceManager _ServiceManager;
        
       
        
        string basariliMesaj = "Ana Kategori İşlemi Başarıyla Tamamlandı";
        string basarisizMesaj = "Ana Kategori İşlemi Başarısız !";
        public MainCategoryController(IServiceManager serviceManager)
        {
            _ServiceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
           
            var veri = await _ServiceManager.MainCategoryService.GetAll();
            return View(veri);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MainCategory mainCategory)
        {

            var sonuc = await _ServiceManager.MainCategoryService.CreateOne(mainCategory);

            if (sonuc)
            {
                TempData["Message"] = basariliMesaj;
                TempData["MessageType"] = "success"; // success, info, warning, error
            }
            else
            {
                TempData["Message"] = basarisizMesaj;
                TempData["MessageType"] = "error"; // success, info, warning, error
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {

            var veri = await _ServiceManager.MainCategoryService.GetOne(id);
            return View(veri);
        }
        [HttpPost]
        public async Task<IActionResult> Update(MainCategory mainCategory)
        {
            bool sonuc = await _ServiceManager.MainCategoryService.UpdateOne(mainCategory.MainCategoryId, mainCategory);
            if(sonuc)
            {
                TempData["Message"] = basariliMesaj;
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = basarisizMesaj;
                TempData["MessageType"] = "error"; // success, info, warning, error
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool sonuc = await _ServiceManager.MainCategoryService.DeleteOne(id);
            var altkategori = await _ServiceManager.CategoryService.GetAllById(id);
            if (altkategori.Count() > 0)
            {
                TempData["Message"] = $"Ana Kategorinin {altkategori.Count()} Alt Kategorisi Mevcut Silinemedi!";
                TempData["MessageType"] = "warning"; // success, info, warning, error
            }
            else if (sonuc)
            {
                TempData["Message"] = basariliMesaj;
                TempData["MessageType"] = "success"; // success, info, warning, error

            }
            else
            {
                TempData["Message"] = basarisizMesaj;
                TempData["MessageType"] = "error"; // success, info, warning, error
            }
            return RedirectToAction("Index");
        }
    }
}
