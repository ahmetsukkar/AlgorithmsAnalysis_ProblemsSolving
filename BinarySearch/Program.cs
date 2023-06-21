using System;

namespace BinarySearch
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("BinarySearch");
			int[] array = { 17, 18, 4, 5, 19, 8, 9, 10, 2, 11, 12, 13, 6, 7, 14, 3, 20, 1, 15, 16 };

			Console.WriteLine("intpu array: " + string.Join(", ", array));

			MergeSort(array, 0, array.Length - 1);

			Console.WriteLine("Sorted intpu array: " + string.Join(", ", array));

			Console.WriteLine("Enter Search Key between: " + array[0] + " - " + array[array.Length - 1]);
			int key = int.Parse(Console.ReadLine());

			var result = BinarySearch(array, key);
			//var result = BinarySearch_Recursion(array, 0 , array.Length - 1, key);

			Console.WriteLine("Searched key exist at index number: " + result);
			Console.ReadLine();
		}

		private static int BinarySearch(int[] array, int key)
		{
			int low = 0;
			int high = array.Length - 1;

			while (low <= high)
			{
				int midpoint = (low + high) / 2;

				if (key == array[midpoint])
					return midpoint;
				else if (key > array[midpoint])
					low = midpoint + 1;
				else
					high = midpoint - 1;
			}

			return -1;
		}

		private static int BinarySearch_Recursion(int[] array, int low, int high, int key)
		{
			int mid = (low + high) / 2;
			if (key == array[mid])
				return mid;
			else if (key > array[mid])
				return BinarySearch_Recursion(array, mid + 1, high, key);
			else if (key < array[mid])
				return BinarySearch_Recursion(array, low, mid - 1, key);
			else
				return -1;
		}

		public static void MergeSort(int[] array, int start, int end)
		{
			int midpoint = (end + start) / 2;

			if (end <= start) return;

			MergeSort(array, start, midpoint);
			MergeSort(array, midpoint + 1, end);
			Merge(array, start, midpoint, end);
		}

		public static void Merge(int[] array, int start, int midpoint, int end)
		{
			int i, j, k;

			int left_length = midpoint - start + 1;
			int right_length = end - midpoint;

			int[] left_array = new int[left_length];
			int[] right_array = new int[right_length];

			for (i = 0; i < left_length; i++)
				left_array[i] = array[i + start];

			for (j = 0; j < right_length; j++)
				right_array[j] = array[j + 1 + midpoint];

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
