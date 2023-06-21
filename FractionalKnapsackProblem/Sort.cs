using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalKnapsackProblem
{
	public static class Sort
	{
		public static Item[] MergeSort(Item[] items, SortType sortType)
		{
			SortItems(items, 0, items.Length - 1, sortType);
			return items;
		}

		private static void SortItems(Item[] items, int start, int end, SortType sortType)
		{
			if (end <= start) return;

			int midpoint = (start + end) / 2;

			SortItems(items, start, midpoint, sortType);
			SortItems(items, midpoint + 1, end, sortType);
			MergeSort(items, start, midpoint, end, sortType);
		}

		private static void MergeSort(Item[] items, int start, int midpoint, int end, SortType sortType)
		{
			int i, j, k;

			int left_length = midpoint - start + 1;
			int right_length = end - midpoint;

			Item[] left_item = new Item[left_length];
			Item[] right_item = new Item[right_length];

			for (i = 0; i < left_length; i++)
				left_item[i] = items[i + start];

			for (j = 0; j < right_length; j++)
				right_item[j] = items[j + 1 + midpoint];

			i = 0;
			j = 0;
			k = start;

			while (i < left_length && j < right_length)
			{
				if (sortType == SortType.Ascending)
				{
					if (left_item[i].Ratio < right_item[j].Ratio)
					{
						items[k] = left_item[i];
						i++;
					}
					else
					{
						items[k] = right_item[j];
						j++;
					}
				}
				else
				{
					if (left_item[i].Ratio > right_item[j].Ratio)
					{
						items[k] = left_item[i];
						i++;
					}
					else
					{
						items[k] = right_item[j];
						j++;
					}
				}
				k++;
			}

			while (i < left_length)
			{
				items[k] = left_item[i];
				i++;
				k++;
			}

			while (i < right_length)
			{
				items[k] = right_item[j];
				j++;
				k++;
			}

		}
	}

	public enum SortType
	{
		Ascending = 0,
		Descending = 1
	}
}
