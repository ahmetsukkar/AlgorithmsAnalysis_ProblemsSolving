using System;
using System.Collections;
using System.Collections.Generic;

namespace TraversalAlgorithm
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Select the Algorithms:");
			Console.WriteLine("1- Breadth First Search");
			Console.WriteLine("2- Depth First Search");
			Console.WriteLine("3- Dijkstra’s Shortest Path");
			Console.WriteLine();

			Console.Write("Enter Your Selection: ");

			var selection = int.Parse(Console.ReadLine());

			Console.WriteLine();

			switch (selection)
			{
				case 1:
					Console.WriteLine("Breadth First Search");
					//BreadthFirstSearchByHashTableSolution();
					BreadthFirstSearch();
					break;
				case 2:
					Console.WriteLine("Depth First Search");
					DepthFirstSearch();
					break;
				case 3:
					Console.WriteLine("Dijkstra’s Shortest Path");
					DijkstraShortestPath();
					break;
				default:
					Console.WriteLine("Nothing");
					break;
			}

			Console.ReadLine();
		}

		private static void BreadthFirstSearchByHashTableSolution()
		{
			int v = 9;
			Hashtable graph = new Hashtable(v);
			graph.Add('A', new char[] { 'B', 'C' });
			graph.Add('B', new char[] { 'E', 'D', 'A' });
			graph.Add('C', new char[] { 'D', 'F', 'A' });
			graph.Add('D', new char[] { 'B', 'C', 'F' });
			graph.Add('E', new char[] { 'B', 'F' });
			graph.Add('F', new char[] { 'C', 'D', 'E', 'H' });
			graph.Add('G', new char[] { 'H', 'I' });
			graph.Add('H', new char[] { 'G', 'I', 'F' });
			graph.Add('I', new char[] { 'G', 'H' });

			Queue<char> q = new Queue<char>(v);
			q.Enqueue('A');

			Hashtable visited = new Hashtable(v);
			visited.Add('A', true);

			char current_vertex;
			char[] destinations;

			while (q.Count > 0)
			{
				current_vertex = q.Dequeue();
				destinations = (char[])graph[current_vertex];

				for (int i = 0; i < destinations.Length; i++)
				{
					if (!visited.ContainsKey(destinations[i]))
					{
						q.Enqueue(destinations[i]);
						visited.Add(destinations[i], true);
						Console.WriteLine(current_vertex + " - " + destinations[i]);
					}
				}
			}
		}

		private static void BreadthFirstSearch()
		{
			//					0	 1	  2	   3	4	 5	  6	   7    8
			string[] nodes = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
			Graph graph = new Graph(nodes);

			graph.AddEdges(Array.IndexOf(nodes, "A"),
				new int[] { Array.IndexOf(nodes, "B"), Array.IndexOf(nodes, "C") });

			graph.AddEdges(Array.IndexOf(nodes, "B"), 
				new int[] { Array.IndexOf(nodes, "A"), Array.IndexOf(nodes, "D"), Array.IndexOf(nodes, "E") });

			graph.AddEdges(Array.IndexOf(nodes, "C"), 
				new int[] { Array.IndexOf(nodes, "A"), Array.IndexOf(nodes, "D"), Array.IndexOf(nodes, "F") });

			graph.AddEdges(Array.IndexOf(nodes, "D"), 
				new int[] { Array.IndexOf(nodes, "B"), Array.IndexOf(nodes, "C"), Array.IndexOf(nodes, "F") });

			graph.AddEdges(Array.IndexOf(nodes, "E"), 
				new int[] { Array.IndexOf(nodes, "B"), Array.IndexOf(nodes, "F") });

			graph.AddEdges(Array.IndexOf(nodes, "F"), 
				new int[] { Array.IndexOf(nodes, "C"), Array.IndexOf(nodes, "D"), Array.IndexOf(nodes, "E"), Array.IndexOf(nodes, "H") });

			graph.AddEdges(Array.IndexOf(nodes, "G"), 
				new int[] { Array.IndexOf(nodes, "H"), Array.IndexOf(nodes, "I") });

			graph.AddEdges(Array.IndexOf(nodes, "H"), 
				new int[] { Array.IndexOf(nodes, "F"), Array.IndexOf(nodes, "G"), Array.IndexOf(nodes, "I") });

			graph.AddEdges(Array.IndexOf(nodes, "I"), 
				new int[] { Array.IndexOf(nodes, "G"), Array.IndexOf(nodes, "H") });

			graph.PrintGraph();
			graph.BFS();
		}

		private static void DepthFirstSearch()
		{
			//					0	 1	  2	   3	4	 5	  6	   7    8
			string[] nodes = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
			Graph graph = new Graph(nodes);

			graph.AddEdges(Array.IndexOf(nodes, "A"), 
				new int[] { Array.IndexOf(nodes, "B"), Array.IndexOf(nodes, "C") });

			graph.AddEdges(Array.IndexOf(nodes, "B"), 
				new int[] { Array.IndexOf(nodes, "A"), Array.IndexOf(nodes, "D"), Array.IndexOf(nodes, "E") });

			graph.AddEdges(Array.IndexOf(nodes, "C"), 
				new int[] { Array.IndexOf(nodes, "A"), Array.IndexOf(nodes, "D"), Array.IndexOf(nodes, "F") });

			graph.AddEdges(Array.IndexOf(nodes, "D"), 
				new int[] { Array.IndexOf(nodes, "B"), Array.IndexOf(nodes, "C"), Array.IndexOf(nodes, "F") });

			graph.AddEdges(Array.IndexOf(nodes, "E"), 
				new int[] { Array.IndexOf(nodes, "B"), Array.IndexOf(nodes, "F") });

			graph.AddEdges(Array.IndexOf(nodes, "F"), 
				new int[] { Array.IndexOf(nodes, "C"), Array.IndexOf(nodes, "D"), Array.IndexOf(nodes, "E"), Array.IndexOf(nodes, "H") });

			graph.AddEdges(Array.IndexOf(nodes, "G"), 
				new int[] { Array.IndexOf(nodes, "H"), Array.IndexOf(nodes, "I") });
			graph.AddEdges(Array.IndexOf(nodes, "H"), 
				new int[] { Array.IndexOf(nodes, "F"), Array.IndexOf(nodes, "G"), Array.IndexOf(nodes, "I") });

			graph.AddEdges(Array.IndexOf(nodes, "I"), 
				new int[] { Array.IndexOf(nodes, "G"), Array.IndexOf(nodes, "H") });

			graph.PrintGraph();
			graph.DFS();
		}

		private static void DijkstraShortestPath()
		{
			//					0	 1	  2	   3	4	 5	  6	   7    8	 9
			string[] nodes = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
			Graph graph = new Graph(nodes);

			graph.AddEdges(Array.IndexOf(nodes, "A"), 
				new int[] { Array.IndexOf(nodes, "B"), Array.IndexOf(nodes, "C"), Array.IndexOf(nodes, "D") }, 
				new double[] { 2, 4, 3 });

			graph.AddEdges(Array.IndexOf(nodes, "B"), 
				new int[] { Array.IndexOf(nodes, "E"), Array.IndexOf(nodes, "F"), Array.IndexOf(nodes, "G") }, 
				new double[] { 7, 4, 6 });
			graph.AddEdges(Array.IndexOf(nodes, "C"), 
				new int[] { Array.IndexOf(nodes, "E"), Array.IndexOf(nodes, "F"), Array.IndexOf(nodes, "G") }, 
				new double[] { 3, 2, 4 });
			graph.AddEdges(Array.IndexOf(nodes, "D"), 
				new int[] { Array.IndexOf(nodes, "E"), Array.IndexOf(nodes, "F"), Array.IndexOf(nodes, "G") }, 
				new double[] { 4, 1, 5 });

			graph.AddEdges(Array.IndexOf(nodes, "E"), 
				new int[] { Array.IndexOf(nodes, "H"), Array.IndexOf(nodes, "I") }, new double[] { 1, 4 });
			graph.AddEdges(Array.IndexOf(nodes, "F"), 
				new int[] { Array.IndexOf(nodes, "H"), Array.IndexOf(nodes, "I") }, new double[] { 6, 3 });
			graph.AddEdges(Array.IndexOf(nodes, "G"), 
				new int[] { Array.IndexOf(nodes, "H"), Array.IndexOf(nodes, "I") }, new double[] { 3, 3 });

			graph.AddEdges(Array.IndexOf(nodes, "H"), 
				new int[] { Array.IndexOf(nodes, "J") }, new double[] { 3 });
			graph.AddEdges(Array.IndexOf(nodes, "I"), 
				new int[] { Array.IndexOf(nodes, "J") }, new double[] { 4 });

			graph.PrintGraph();
			graph.Dijkstra();
		}

	}
}
