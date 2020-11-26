using BlazorShopApp.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShopApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient("ProductsAPI", cl =>
            {
                //cl.BaseAddress = new Uri("https://localhost:44343/api/");
                cl.BaseAddress = new Uri("https://localhost:44343/");
            });

            builder.Services.AddScoped(
                sp => sp.GetService<IHttpClientFactory>().CreateClient("ProductsAPI"));

            builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();

            await builder.Build().RunAsync();
        }
    }
}
