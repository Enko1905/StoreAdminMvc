using Entities.Models;
using Entities.RequestFeatures;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductManager : IProductService
    {
        private readonly HttpClient _httpClient;
        string baseController = "product";
        public ProductManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateOne(Products entity)
        {
            var response = await _httpClient.PostAsJsonAsync(baseController, entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOne(int id)
        {
            var response = await _httpClient.DeleteAsync($"{baseController}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Products>> GetAll()
        {
            try
            {
                // HTTP isteği oluşturuluyor
                var baseUrl = string.Concat(_httpClient.BaseAddress, baseController); //apiurl/product

                var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);

                // Accept başlığı ekleniyor
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // İstek gönderiliyor
                var responseMessage = await _httpClient.SendAsync(request);

                // Başarılı olup olmadığını kontrol ediyor
                responseMessage.EnsureSuccessStatusCode();

                // Yanıt içeriğini JSON olarak okuyor
                var response = await responseMessage.Content.ReadFromJsonAsync<List<Products>>();

                return response?.ToList() ?? new List<Products>();
            }
            catch (HttpRequestException httpEx)
            {
                // HTTP isteği hatalarını yakala ve logla
                Console.Error.WriteLine($"HttpRequestException: {httpEx.Message}");

                // İsteğin döndüğü hatalı yanıtı logla
                var errorResponse = httpEx.StatusCode;
                if (errorResponse == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.Error.WriteLine("API isteği 400 (Bad Request) hatası döndü.");
                }
                throw;
            }
            catch (Exception ex)
            {
                // Diğer hataları yakala ve logla
                Console.Error.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public async Task<Products> GetOne(int id)
        {
            var respone = await _httpClient.GetFromJsonAsync<Products>($"{baseController}/{id}");
            return respone;
        }

        public Task<bool> UpdateOne(int id, Products entity)
        {
            throw new NotImplementedException();
        }
    }
}
