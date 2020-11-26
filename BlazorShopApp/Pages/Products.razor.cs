using BlazorShopApp.HttpRepository;
using BlazorShopApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShopApp.Pages
{
	public partial class Products
	{
		public List<Product> ProductList { get; set; } = new List<Product>();
		public int TotalSize { get; set; }

		[Inject]
		public IProductHttpRepository ProductRepo { get; set; }

		private async Task GetProducts(ProductParameters productParams)
		{
			var virtualizeResult = await ProductRepo.GetProducts(productParams);
			ProductList = virtualizeResult.Items;
			TotalSize = virtualizeResult.TotalSize;
		}
	}
}
