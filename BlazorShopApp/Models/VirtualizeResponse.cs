﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShopApp.Models
{
	public class VirtualizeResponse<T>
	{
		public List<T> Items { get; set; }
		public int TotalSize { get; set; }
	}
}
