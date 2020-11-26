﻿using EShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.HttpRepository
{
	public interface IProductHttpRepository
	{
		Task<VirtualizeResponse<Product>> GetProducts(ProductParameters productParams);
	}
}
