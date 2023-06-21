using System;
using System.Linq;

namespace SegregatePositiveAndNegativeNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Segregate Positive & Negative Numbers");
			int[] array = { 9, -3, 5, -2, -8, -6, 1, 3, -7, 22, -13 };

			Console.WriteLine("intpu array: " + string.Join(", ", array));

			Segregate(array, 0, array.Count() - 1);

			Console.WriteLine("Segregate List: " + string.Join(", ", array));
			Console.ReadLine();
		}

		public static void Segregate(int[] array, int start, int end)
		{
			if (end <= start) return;

			int midpoint = (end + start) / 2;

			Segregate(array, start, midpoint);
			Segregate(array, midpoint + 1, end);
			Merge(array, start, midpoint, end);
		}

		private static void Merge(int[] array, int start, int midpoint, int end)
		{
			int left_length = midpoint - start + 1;
			int right_length = end - midpoint;

			int[] left_array = new int[left_length];
			int[] right_array = new int[right_length];

			int i, j, k;

			for (i = 0; i < left_length; i++)
				left_array[i] = array[start + i];

			for (j = 0; j < right_length; j++)
				right_array[j] = array[j + 1 + midpoint];

			i = j = 0;
			k = start;

			while (i < left_length && left_array[i] <= 0)
			{
				array[k] = left_array[i];
				k++;
				i++;
			}

			while (j < right_length && right_array[j] <= 0)
			{
				array[k] = right_array[j];
				k++;
				j++;
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
