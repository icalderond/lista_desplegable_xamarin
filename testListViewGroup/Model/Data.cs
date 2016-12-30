using System;
using System.Collections.Generic;

namespace testListViewGroup
{
	public class Data
	{
		public static List<Tarima> SampleTarima()
		{
			var newTarimaList = new List<Tarima>();

			Random rand = new Random();
			for (int i = 0; i < 10; i++)
			{
				int counProduct = rand.Next(1, 10);
				List<Product> currentList = new List<Product>();
				for (int j = 0; j < counProduct; j++)
				{
					currentList.Add(new Product()
					{
						ProductName = Guid.NewGuid().ToString(),
						CountProduct = rand.Next(10, 500)
					});
				}

				newTarimaList.Add(new Tarima(i.ToString(), currentList));
			}
			return newTarimaList;
		}
	}
}
