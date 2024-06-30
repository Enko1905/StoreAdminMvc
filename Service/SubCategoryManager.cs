using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly HttpClient _httpClient;

        public SubCategoryManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateOne(SubCategory entity)
        {
            var response = await _httpClient.PostAsJsonAsync("SubCategory",entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOne(int id)
        {
            var response = await _httpClient.DeleteAsync($"SubCategory/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<SubCategory>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SubCategory>>("SubCategory"); 
            return response.ToList();
        }
        public async Task<List<SubCategory>> GetAllById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<List<SubCategory>>($"SubCategory/{id}");
            return response.ToList();
        }

        public async Task<SubCategory> GetOne(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<SubCategory>($"SubCategory/OneSubCategory/{id}");
            return response;
        }

        public async Task<bool> UpdateOne(int id, SubCategory entity)
        {
            var reponse = await _httpClient.PutAsJsonAsync($"SubCategory/{id}",entity);
            return reponse.IsSuccessStatusCode;
        }
    }
}
