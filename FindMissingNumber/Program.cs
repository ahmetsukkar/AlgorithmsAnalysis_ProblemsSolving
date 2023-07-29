using System;
using System.Collections.Generic;

namespace FindMissingNumber
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//We have a an order list from 0 to n
			//we will pick up a ramdom number from this list then we will mix the list
			//Find the missing number from the list

			List<int> numbersList = new List<int>();

			for (int i = 0; i <= 5; i++)
			{
				numbersList.Add(i);
			}

			int pickedNumber = 3;
			numbersList.Remove(pickedNumber);

			ShuffleList(numbersList);

			// Find the lost number
			int lostNumber = FindLostNumber(numbersList);

			Console.WriteLine("The lost number is: " + lostNumber);

			Console.ReadLine();
		}

		static int FindLostNumber(List<int> numbers)
		{
			int n = numbers.Count + 1; // Since one number is removed, the list size is reduced by 1
			int expectedSum = (n * (n - 1)) / 2; // Sum of numbers from 0 to n-1

			int actualSum = 0;
			foreach (int num in numbers)
			{
				actualSum += num;
			}

			// The difference between the expected sum and the actual sum will be the lost number
			return expectedSum - actualSum;
		}

		static void ShuffleList<T>(List<T> list)
		{
			Random random = new Random();
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = random.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}
