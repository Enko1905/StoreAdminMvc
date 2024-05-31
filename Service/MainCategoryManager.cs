using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Entities.Models;
using Service.Contracts;
namespace Service
{
    public class MainCategoryManager : IMainCategoryService
    {
        private readonly HttpClient _httpClient;

        public MainCategoryManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateOne(MainCategory mainCategory)
        {
            var response = await _httpClient.PostAsJsonAsync("MainCategory", mainCategory);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOne(int id)
        {
            var response = await _httpClient.DeleteAsync($"MainCategory/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<MainCategory>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<MainCategory>>("MainCategory");
            return response.ToList();
        }

        public async Task<List<MainCategory>> GetFullAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<MainCategory>>("MainCategory/FullSubMainCategory");
            return response.ToList();
        }

        public async Task<MainCategory> GetOne(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<MainCategory>($"MainCategory/{id}");
            return response;
        }

     

        public async Task<bool> UpdateOne(int id, MainCategory mainCategory)
        {
            var sonuc = await _httpClient.PutAsJsonAsync($"MainCategory/{id}", mainCategory);
            return sonuc.IsSuccessStatusCode;
        }
    }
}
