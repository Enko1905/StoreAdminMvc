using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryManager : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateOne(Categories entity)
        {
            var response = await _httpClient.PostAsJsonAsync("Category", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOne(int id)
        {
            var response = await _httpClient.DeleteAsync($"Category/{id}");
            return response.IsSuccessStatusCode;
        }

        [Obsolete("GetAllById")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<List<Categories>> GetAll()
        {
            throw new NotImplementedException();

        }

        public async Task<List<Categories>> GetAllById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Categories>>($"Category/{id}");
            return response.ToList();
        }

        public async Task<Categories> GetOne(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Categories>($"Category/GetOne/{id}");
            return response;
        }

        public async Task<bool> UpdateOne(int id, Categories entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"Category/{id}", entity);
            return response.IsSuccessStatusCode;
        }

    }
}
