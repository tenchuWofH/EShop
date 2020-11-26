using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Shared
{
	public class ProductParameters
	{
		private int _pageSize = 15;

		public int StartIndex { get; set; }
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = value;
			}
		}
	}
}
