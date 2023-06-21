using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalKnapsackProblem
{
	public class Knapsack
	{
		public float MaxCapacity;
		public float CurrentCapacity;
		public float TotalProfit;
		public List<Item> Items;

		public Knapsack(int maxCapacity)
		{
			this.MaxCapacity = maxCapacity;
			this.CurrentCapacity = 0;
			this.TotalProfit = 0;
			Items = new List<Item>();
		}

		public void AddItem(Item newItem)
		{
			if (newItem.Weight > this.MaxCapacity - this.CurrentCapacity)
			{
				float diff = this.MaxCapacity - this.CurrentCapacity;
				newItem.Weight = diff;
				newItem.Profit = diff * newItem.Ratio;
			}

			this.Items.Add(newItem);

			this.CurrentCapacity += newItem.Weight;
			this.TotalProfit += newItem.Profit;
		}
	}
}
