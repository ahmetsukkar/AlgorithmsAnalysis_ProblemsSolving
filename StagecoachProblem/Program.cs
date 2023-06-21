using System;
using System.Collections.Generic;

namespace StagecoachProblem
{
	class Program
	{

		#region "DataMatrix Representation"

		//We need to find the best route with minimum cost from these data
		//&
		//Print the route

		//(I/J) = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
		// (A)  = { "0", "2", "4", "3", "0", "0", "0", "0", "0", "0" },
		// (B)  = { "0", "0", "0", "0", "7", "4", "6", "0", "0", "0" },
		// (C)  = { "0", "0", "0", "0", "3", "2", "4", "0", "0", "0" },
		// (D)  = { "0", "0", "0", "0", "4", "1", "5", "0", "0", "0" },
		// (E)  = { "0", "0", "0", "0", "0", "0", "0", "1", "4", "0" },
		// (F)  = { "0", "0", "0", "0", "0", "0", "0", "6", "3", "0" },
		// (G)  = { "0", "0", "0", "0", "0", "0", "0", "3", "3", "0" },
		// (H)  = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "3" },
		// (I)  = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "4" },
		// (J)  = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
		#endregion

		static void Main(string[] args)
		{
			string[] labels = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
			//					 0    1    2    3    4    5    6    7    8    9

			int[,] data = {
				{ 0, 2, 4, 3, 0, 0, 0, 0, 0, 0 }, //0
				{ 0, 0, 0, 0, 7, 4, 6, 0, 0, 0 }, //1
				{ 0, 0, 0, 0, 3, 2, 4, 0, 0, 0 }, //2
				{ 0, 0, 0, 0, 4, 1, 5, 0, 0, 0 }, //3
				{ 0, 0, 0, 0, 0, 0, 0, 1, 4, 0 }, //4
				{ 0, 0, 0, 0, 0, 0, 0, 6, 3, 0 }, //5
				{ 0, 0, 0, 0, 0, 0, 0, 3, 3, 0 }, //6
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 }, //7
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 }, //8
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};//9

			//    0  1  2  3  4  5  6  7  8  9		//

			int n = labels.Length;

			State[] states = new State[n];
			states[n - 1] = new State(null, labels[n - 1], 0);

			int i, j;
			for (i = n - 2; i >= 0; i--)
			{
				states[i] = new State(labels[i], null, int.MaxValue);
				for (j = i + 1; j < n; j++)
				{
					if (data[i, j] == 0) continue;

					var newCost = data[i, j] + states[j].Cost;

					if (newCost < states[i].Cost)
					{
						states[i].To = labels[j];
						states[i].Cost = newCost;
					}
				}
			}

			Console.WriteLine("Minimum Cost: " + states[0].Cost);

			Console.WriteLine("---");

			Console.WriteLine("From" + "	" + "Total Cost" + "	" + "By");

			foreach (var item in states)
			{
				Console.WriteLine(item.From + "	" + item.Cost + "		" + item.To);
			}


			Console.WriteLine();

			List<string> path = new List<string>() { "A" };

			i = 0;
			j = 0;
			while (i < states.Length)
			{
				if (states[i].From == path[j])
				{
					path.Add(states[i].To);
					j++;
				}
				i++;
			}

			Console.WriteLine("Shourtest Path:");
			Console.WriteLine(string.Join(" --> ", path));

			Console.ReadLine();
		}
	}
}
