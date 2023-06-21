using System;

namespace MergeSort
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Merge Sort");
			int[] array = { 5, 6, 12, 1, 9, 10 };

			Console.WriteLine("Orginal List: " + string.Join(", ", array));

			MergeSort(array, 0, array.Length - 1);

			Console.WriteLine("Sorted List: " + string.Join(", ", array));
			Console.ReadLine();
		}

		static void MergeSort(int[] array, int start, int end)
		{
			if (start >= end) return;

			int midpoint = (start + end) / 2;

			MergeSort(array, start, midpoint);
			MergeSort(array, midpoint + 1, end);
			Merge(array, start, midpoint, end);
		}
		private static void Merge(int[] array, int start, int midpoint, int end)
		{
			int i, j, k;

			int left_length = midpoint - start + 1;
			int right_length = end - midpoint;

			int[] left_array = new int[left_length];
			int[] right_array = new int[right_length];

			for (i = 0; i < left_length; i++)
				left_array[i] = array[start + i];

			for (j = 0; j < right_length; j++)
				right_array[j] = array[midpoint + 1 + j];

			i = j = 0;
			k = start;
			while (i < left_length && j < right_length)
			{
				if (left_array[i] <= right_array[j])
				{
					array[k] = left_array[i];
					i++;
				}
				else
				{
					array[k] = right_array[j];
					j++;
				}
				k++;
			}

			while (i < left_length)
			{
				array[k] = left_array[i];
				i++;
				k++;
			}

			while (j < right_length)
			{
				array[k] = right_array[j];
				j++;
				k++;
			}

		}
	}
}
