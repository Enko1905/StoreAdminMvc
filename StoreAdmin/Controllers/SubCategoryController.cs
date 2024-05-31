using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using Service.Contracts;

namespace StoreAdmin.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public SubCategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        string basariliMesaj = "Alt Kategori İşlemi Başarıyla Tamamlandı";
        string basarisizMesaj = "Alt Kategori İşlemi Başarısız !";
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var veri = await _serviceManager.SubCategoryService.GetAllById(id);
            var category = await _serviceManager.CategoryService.GetOne(id);
            var MainCategory = await _serviceManager.MainCategoryService.GetOne(category.MainCategoryId);
            var result = Tuple.Create(MainCategory, category, veri);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var categerory = await _serviceManager.CategoryService.GetOne(id);

            ViewBag.Category = await GetCategoriesSelectList(id, categerory.MainCategoryId);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            var sonuc = await _serviceManager.SubCategoryService.CreateOne(subCategory);
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
            return RedirectToAction("Index", new { id = subCategory.CategoryId });
        }
        private async Task<SelectList> GetCategoriesSelectList(int selectedValue = 1, int mainCategoryId = 1)
        {
            return new SelectList(await _serviceManager.CategoryService.GetAllById(mainCategoryId), "CategoryId", "Name", selectedValue);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var subcategory = await _serviceManager.SubCategoryService.GetOne(id);
            var categerory = await _serviceManager.CategoryService.GetOne(subcategory.CategoryId);

            ViewBag.Category = await GetCategoriesSelectList(id, categerory.MainCategoryId);
            return View(subcategory);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SubCategory subCategory)
        {
            var sonuc = await _serviceManager.SubCategoryService.CreateOne(subCategory);
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
            return RedirectToAction("Index", new { id = subCategory.CategoryId });
        }

        [HttpGet("SubCategory/Delete/{id1:int}/{id2:int}")]
        public async Task<IActionResult> Delete(int id1, int id2)
        {
            var sonuc = await _serviceManager.SubCategoryService.DeleteOne(id1);
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
            return RedirectToAction("Index", new { id = id2 });
        }

    }

}


