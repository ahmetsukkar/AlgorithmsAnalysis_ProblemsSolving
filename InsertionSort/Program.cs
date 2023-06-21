using System;

namespace InsertionSort
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Insertion Sort");
			int[] unsortedArray = { 9, 5, 1, 4 };

			Console.WriteLine("Orginal List: " + string.Join(", ", unsortedArray));

			int[] result = InsertionSort(unsortedArray);

			Console.WriteLine("Sorted List: " + string.Join(", ", result));
			Console.ReadLine();
		}

		public static int[] InsertionSort(int[] array)
		{
			int i, j;
			for (i = 1; i < array.Length; i++)
			{
				int tmp = array[i];

				for (j = i - 1; j >= 0; j--)
				{
					if (array[j] > tmp)
						array[j + 1] = array[j];
					else
						break;
				}
				array[j + 1] = tmp;
			}

			return array;
		}
	}
}
