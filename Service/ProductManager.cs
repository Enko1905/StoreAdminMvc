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
    public class ProductManager : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateOne(Products entity)
        {
            var response = await _httpClient.PostAsJsonAsync("Product",entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOne(int id)
        {
            var response = await _httpClient.DeleteAsync($"Product/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Products>> GetAll()
        {
            var respone = await _httpClient.GetFromJsonAsync<List<Products>>("Product");
            return respone.ToList();    
        }

        public async Task<Products> GetOne(int id)
        {
            var respone = await _httpClient.GetFromJsonAsync<Products>($"Product/{id}");
            return respone;
        }

        public Task<bool> UpdateOne(int id, Products entity)
        {
            throw new NotImplementedException();
        }
    }
}
