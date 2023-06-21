using System;

namespace FractionalKnapsackProblem
{
	class Program
	{
		static void Main(string[] args)
		{
			//Fractional Knapsack Problem
			//We need to fill the bag with possible high profit
			//we solved the problem with using Greedy Technique

			//new Item(Name, Profit, Weight)

			Item[] items = {
				new Item("#1", 4, 1),
				new Item("#2", 9, 2),
				new Item("#3", 12, 10),
				new Item("#4", 11, 4),
				new Item("#5", 6, 3),
				new Item("#6", 5, 5)};

			items = Sort.MergeSort(items, SortType.Descending);
			PrintArray(items);

			Knapsack bag = new Knapsack(12);

			int j = 0;
			while (bag.CurrentCapacity < bag.MaxCapacity)
			{
				bag.AddItem(items[j]);
				j++;
			}

			PrintItems(bag);

			Console.ReadLine();
		}

		private static void PrintItems(Knapsack bag)
		{
			Console.WriteLine();
			Console.WriteLine("Total Profit: " + bag.TotalProfit);
			Console.WriteLine("Current Capacity: " + bag.CurrentCapacity);
			Console.WriteLine("Items:");

			Console.WriteLine("Name	Profit	Weight");
			Console.WriteLine("____________________");

			foreach (var item in bag.Items)
			{
				Console.WriteLine(string.Format("{0}	{1}	{2}", item.Name, item.Profit, item.Weight, item.Ratio));
			}
		}

		static void PrintArray(Item[] items)
		{
			Console.WriteLine("Name	Profit	Profit	Ratio");
			Console.WriteLine("_____________________________");

			foreach (var item in items)
			{
				Console.WriteLine(string.Format("{0}	{1}	{2}	{3}", item.Name, item.Profit, item.Weight, item.Ratio));
			}
		}
	}
}
