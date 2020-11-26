using BlazorShopApp.Models;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorShopApp.HttpRepository
{
	public class ProductHttpRepository : IProductHttpRepository
	{
		private readonly HttpClient _client;
		private readonly JsonSerializerOptions _options =
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

		public ProductHttpRepository(HttpClient client)
		{
			_client = client;
		}

		public async Task<VirtualizeResponse<Product>> GetProducts(ProductParameters productParams)
		{
			var queryStringParam = new Dictionary<string, string>
			{
				["pageSize"] = productParams.PageSize.ToString(),
				["startIndex"] = productParams.StartIndex.ToString()
			};

			var response =
				//await _client.GetAsync(QueryHelpers.AddQueryString("products", queryStringParam));
				await _client.GetAsync(QueryHelpers.AddQueryString("product/paged", queryStringParam));
			var content = await response.Content.ReadAsStringAsync();

			response.EnsureSuccessStatusCode();

			var virtualizeResponse = JsonSerializer
				.Deserialize<VirtualizeResponse<Product>>(content, _options);

			return virtualizeResponse;
		}
	}
}
