using System;
using System.Collections.Generic;

namespace testListViewGroup
{
	public class Tarima
	{
		public Tarima( string _numTarima,List<Product> _producto)
		{
			NumTarima = _numTarima;
			ProductItems = _producto;
		}

		public string NumTarima
		{
			get;
			set;
		}
		public List<Product> ProductItems
		{
			get;
			set;
		}
	}
	public class Product
	{
		public string ProductName { get; set; }
		public int CountProduct { get; set; }
	}
}