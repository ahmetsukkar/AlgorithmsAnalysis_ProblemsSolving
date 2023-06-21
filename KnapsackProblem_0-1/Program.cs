using System;
using System.Collections.Generic;

namespace KnapsackProblem_0_1
{
	class Program
	{
		static void Main(string[] args)
		{
			Item[] items = {
				new Item("#0", 0, 0),
				new Item("#1", 1, 4),
				new Item("#2", 3, 9),
				new Item("#3", 5, 12),
				new Item("#4", 4, 11),
			};

			int max_weight = 8;

			int[,] dp = new int[items.Length, max_weight + 1];

			int row, col;
			for (row = 0; row < items.Length; row++)
			{
				for (col = 0; col <= max_weight; col++)
				{
					if (row == 0 || col == 0)
					{
						dp[row, col] = 0;
					}
					else if (items[row].Weight <= col)
					{
						dp[row, col] = Math.Max(
												items[row].Profit + dp[row - 1, col - items[row].Weight],
												dp[row - 1, col]
												);
					}
					else
					{
						dp[row, col] = dp[row - 1, col];
					}
				}
			}

			for (row = 0; row < items.Length; row++)
			{
				for (col = 0; col <= max_weight; col++)
				{
					Console.Write(dp[row, col] + "	");
				}
				Console.WriteLine();
			}

			Console.WriteLine();
			Console.WriteLine("Max Profit: " + dp[items.Length - 1, max_weight]);

			row = items.Length - 1;
			col = max_weight;
			int remain = max_weight;

			List<string> solutions = new List<string>();

			while (row > 0 && col > 0)
			{
				int topRow = dp[row - 1, col];

				if (dp[row, col] > topRow)
				{
					solutions.Add(items[row].Name);
					remain -= items[row].Weight;
					col = remain;
					row--;
				}
				else
				{
					row--;
				}
			}

			Console.WriteLine("Solutions: " + string.Join(", ", solutions));

			Console.ReadLine();
		}
	}
}
