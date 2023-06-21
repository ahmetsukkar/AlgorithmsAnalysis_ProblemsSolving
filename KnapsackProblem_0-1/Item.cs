using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem_0_1
{
	public class Item
	{
		public string Name { get; set; }
		public int Profit { get; set; }
		public int Weight { get; set; }

		public Item(string name, int weight, int profit)
		{
			this.Profit = profit;
			this.Weight = weight;
			this.Name = name;
		}

	}
}
