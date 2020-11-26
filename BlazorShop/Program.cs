using BlazorShop.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

            builder.Services.AddHttpClient("ProductsAPI", cl =>
            {
                cl.BaseAddress = new Uri("https://localhost:5011/api/");
            });

            builder.Services.AddScoped(
                sp => sp.GetService<IHttpClientFactory>().CreateClient("ProductsAPI"));

            //builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();
            builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();

            await builder.Build().RunAsync();
        }
    }
}
