using System;

namespace MinimumSpanningTree_Greedy_
{
	class Program
	{
		static void Main(string[] args)
		{
			char[] lables = { '1', '2', '3', '4', '5', '6' };

			//								    1    2    3    4    5    6
			double[,] graph = new double[,] {{ 0.0, 6.7, 5.2, 2.8, 5.6, 3.6 }, //1
											 { 6.7, 0.0, 5.7, 7.3, 5.1, 3.2 }, //2
											 { 5.2, 5.7, 0.0, 3.4, 8.5, 4.0 }, //3
											 { 2.8, 7.3, 3.4, 0.0, 8.0, 4.4 }, //4
											 { 5.6, 5.1, 8.5, 8.0, 0.0, 4.6 }, //5
											 { 3.6, 3.2, 4.0, 4.4, 4.6, 0.0 }};//6

			int v = 6;

			int selected_edges_count = 0;
			bool[] selected = new bool[v];
			selected[0] = true;

			while (selected_edges_count < v - 1)
			{
				double min = double.MaxValue;
				int tmp_from = -1;
				int tmp_to = -1;

				for (int row = 0; row < v; row++)
				{
					if (selected[row] == true)
					{
						for (int col = 0; col < v; col++)
						{
							if (selected[col] == false && graph[row, col] > 0 && graph[row, col] < min)
							{
								min = graph[row, col];
								tmp_from = row;
								tmp_to = col;
							}
						}
					}
				}

				selected[tmp_to] = true;
				selected_edges_count++;

				Console.WriteLine(lables[tmp_from] + " <--> " + lables[tmp_to] + ": " + graph[tmp_from, tmp_to]);
			}

			Console.ReadLine();
		}
	}
}
