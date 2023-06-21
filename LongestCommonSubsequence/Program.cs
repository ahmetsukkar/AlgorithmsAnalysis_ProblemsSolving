using System;

namespace LongestCommonSubsequence
{
	class Program
	{
		static void Main(string[] args)
		{
			string text_01 = "HELLOWORLD";
			string text_02 = "OHELOD";

			text_01 = " " + text_01;
			text_02 = " " + text_02;

			int n = text_01.Length;
			int m = text_02.Length;

			int[,] dp = new int[m, n];

			int i = 0;
			int j = 0;

			for (i = 0; i < m; i++)
			{
				for (j = 0; j < n; j++)
				{
					if (i == 0 || j == 0)
					{
						dp[i, j] = 0;
					}
					else if (text_02[i] == text_01[j]) //Match
					{
						dp[i, j] = 1 + dp[i - 1, j - 1];
					}
					else //Not Match
					{
						dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
					}
				}
			}

			Console.WriteLine(dp[m - 1, n - 1]);
			i = 0;
			j = 0;
			for (i = 0; i < m; i++)
			{
				for (j = 0; j < n; j++)
				{
					Console.Write(dp[i, j] + "	");
				}
				Console.WriteLine();
			}

			Console.WriteLine();

			i = m - 1;
			j = n - 1;
			string str = "";

			while (i > 0 && j > 0)
			{
				var currentValue = dp[i, j];
				var leftValue = dp[i, j - 1];
				var topValue = dp[i - 1, j];

				if (currentValue > leftValue)
				{
					if (currentValue == topValue)
					{
						//inherited from the top
						i--;
					}
					else
					{
						str = text_02[i] + str;
						i--;
						j--;
					}
				}
				else
				{
					j--;
				}

			}

			Console.WriteLine("Longest Common subsequence: ");
			Console.WriteLine(str);
			Console.ReadLine();
		}
	}
}
