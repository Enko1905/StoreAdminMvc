using Service.Contracts;
using Service;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace StoreAdmin.Extensions
{
    public static class ServiceExtensions
    {


        public static void HttpConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureHttpClient<IMainCategoryService, MainCategoryManager>(services, configuration);
            ConfigureHttpClient<ICategoryService, CategoryManager>(services, configuration);
            ConfigureHttpClient<ISubCategoryService, SubCategoryManager>(services, configuration);
            ConfigureHttpClient<IProductService, ProductManager>(services, configuration);
        }

        private static void ConfigureHttpClient<TInterface, TImplementation>(IServiceCollection services, IConfiguration configuration)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddHttpClient<TInterface, TImplementation>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetConnectionString("ApiBaseUrl"));
            })
              .ConfigurePrimaryHttpMessageHandler(() =>
               {
                   var handler = new HttpClientHandler();
                   handler.ServerCertificateCustomValidationCallback =
                       (HttpRequestMessage req, X509Certificate2 cert, X509Chain chain, SslPolicyErrors errors) => true;
                   return handler;
               });
        }


    }


}
