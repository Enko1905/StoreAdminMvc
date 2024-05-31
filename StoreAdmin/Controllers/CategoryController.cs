using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using Service.Contracts;
using System.Net.Http;

namespace StoreAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        string basariliMesaj = "Kategori İşlemi Başarıyla Tamamlandı";
        string basarisizMesaj = "Kategori İşlemi Başarısız !";
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            if(id == 0 || id == null)
            {
                return RedirectToAction("Index", "MainCategory");
            }
            var categoryheader =await _serviceManager.MainCategoryService.GetOne(id);
            var veri = await _serviceManager.CategoryService.GetAllById(id);
            var result =  Tuple.Create( categoryheader, veri);
            return View(result);
        }
        private async Task<SelectList> GetCategoriesSelectList(int  selectedValue=1)
        {
            return new SelectList(await _serviceManager.MainCategoryService.GetAll(), "MainCategoryId", "Name", selectedValue);
        }
        [HttpGet]
        public async Task<IActionResult> Create([FromRoute] int id=1)
        {
           ViewBag.MainCategory =await GetCategoriesSelectList(id);
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Categories categories)
        {
            var sonuc = await _serviceManager.CategoryService.CreateOne(categories);
            if (sonuc)
            {
                TempData["Message"] = basariliMesaj;
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = basarisizMesaj;
                TempData["MessageType"] = "error"; // success, info, warning, error
            }
            return RedirectToAction("Index", new {id=categories.MainCategoryId});
        }

        [HttpGet("Category/Delete/{id1:int}/{id2:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id1, [FromRoute] int id2)
        {
            var sonuc =  await _serviceManager.CategoryService.DeleteOne(id1);
            var altkategori = await _serviceManager.SubCategoryService.GetAllById(id1);
            if (altkategori.Count() > 0)
            {
                TempData["Message"] = $"Kategorinin {altkategori.Count()} Alt Kategorisi Mevcut Silinemedi";
                TempData["MessageType"] = "warning"; // success, info, warning, error
            }
            else if (sonuc)
            {
                TempData["Message"] = basariliMesaj;
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = basarisizMesaj;
                TempData["MessageType"] = "error"; // success, info, warning, error
            }
            return RedirectToAction("Index",new {id=id2});
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var veri = await _serviceManager.CategoryService.GetOne(id);
            
            ViewBag.MainCategory = await GetCategoriesSelectList(veri.MainCategoryId);
            return View(veri);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Categories categories)
        {
            bool veri = await _serviceManager.CategoryService.UpdateOne(categories.CategoryId, categories);
            if (veri)
            {
                TempData["Message"] = basariliMesaj;
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = basarisizMesaj;
                TempData["MessageType"] = "error"; // success, info, warning, error

            }
            return RedirectToAction("Index", new {id=categories.MainCategoryId});
        }
    }
}
