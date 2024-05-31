using Entities.Models;

using Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Protocol;
using Service.Contracts;
using System.Collections;

namespace StoreAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var veri = await _serviceManager.ProductService.GetAll();
            return View(veri);
        }
        private async Task<SelectList> GetCategoriesSelectList(int selectedValue = 1)
        {
            var data = await _serviceManager.MainCategoryService.GetFullAll(); // Veriyi buradan alın

            var categories = new List<SelectListItem>();
            foreach (var mainCategory in data)
            {
                foreach (var category in mainCategory.Categories)
                {
                    foreach (var subCategory in category.SubCategories)
                    {
                        var itemText = $"{mainCategory.Name} > {category.Name} > {subCategory.Name}";
                        var itemValue = subCategory.SubCategoryId.ToString();
                        categories.Add(new SelectListItem { Text = itemText, Value = itemValue });
                    }
                }
            }
            return new SelectList(categories, "Value", "Text", selectedValue);
        }
        public async Task<IActionResult> Details()
        {
            var veri = await _serviceManager.ProductService.GetAll();
            return View(veri);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.FullCategories = await GetCategoriesSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Products product)
        {
            //ViewBag.FullCategories = await GetCategoriesSelectList();

          //  TempData["ReceivedProductJson"] = JsonConvert.SerializeObject(product);
            /*
            var products = new Products
            {
                ProductName = product.ProductName,
                ImagesUrl = product.ImagesUrl,
                SubCategoryId = 17,
                Description = product.Description,
                Price = product.Price,
                Stok = product.Stok,
                ProductAttributes = product.ProductAttributes.Select(a => new ProductAttribute
                {
                    Type = a.Type,
                    Value = a.Value 
                }).ToList() ?? new List<ProductAttribute>()
            };*/

            // Ensure all ProductAttributes have valid Type and Value

            product.ProductAttributes = product.ProductAttributes
                .Where(attr => !string.IsNullOrEmpty(attr.Type) && !string.IsNullOrEmpty(attr.Value))
                .ToList();

            var sonuc = await _serviceManager.ProductService.CreateOne(product);

            if (sonuc)
            {
                TempData["Message"] = "başarılı";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "Bir hata oluştu";
                TempData["MessageType"] = "error";
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var sonuc = await _serviceManager.ProductService.DeleteOne(id);
            if (sonuc)
            {
                TempData["Message"] = "başarılı";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "Bir hata oluştu";
                TempData["MessageType"] = "error";
            }
            return RedirectToAction("Index");
        }
        // New action to display the received product
        public IActionResult ShowReceivedProduct()
        {
            var receivedProductJson = TempData["ReceivedProductJson"] as string;
            return Content(receivedProductJson, "application/json");
        }


    }
}
