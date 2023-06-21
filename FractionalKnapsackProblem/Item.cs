using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalKnapsackProblem
{
	public class Item
	{
		public string Name { get; set; }
		public float Profit { get; set; }
		public float Weight { get; set; }
		public float Ratio { get; set; }

		public Item(string name, float profit, float weight)
		{
			this.Profit = profit;
			this.Weight = weight;
			this.Name = name;

			this.Ratio = profit / weight;
		}

	}
}
