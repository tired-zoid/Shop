﻿using System;

namespace Shop.Entities
{
    public class PageParameters	
    {
		public int PageNumber { get; set; } = 1;

		public int PageSize { get; set; } = 10;

		public int TotalCount { get; set; }
	}
}
