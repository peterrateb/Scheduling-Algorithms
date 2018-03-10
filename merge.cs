using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeSort
{
	class merge
	{
		public static void SortMerge(process[] input, int low, int high)
		{
			if (low < high)
			{
				int middle = (low / 2) + (high / 2);
				SortMerge(input, low, middle);
				SortMerge(input, middle + 1, high);
				Merge(input, low, middle, high);
			}
		}

		private static void Merge(process[] input, int low, int middle, int high)
		{

			int left = low;
			int right = middle + 1;
			process[] tmp = new process[(high - low) + 1];
			int tmpIndex = 0;

			while ((left <= middle) && (right <= high))
			{
				if (input[left].arrivalTime < input[right].arrivalTime)
				{
					tmp[tmpIndex] = input[left];
					left = left + 1;
				}
				else
				{
					tmp[tmpIndex] = input[right];
					right = right + 1;
				}
				tmpIndex = tmpIndex + 1;
			}

			if (left <= middle)
			{
				while (left <= middle)
				{
					tmp[tmpIndex] = input[left];
					left = left + 1;
					tmpIndex = tmpIndex + 1;
				}
			}

			if (right <= high)
			{
				while (right <= high)
				{
					tmp[tmpIndex] = input[right];
					right = right + 1;
					tmpIndex = tmpIndex + 1;
				}
			}

			for (int i = 0; i < tmp.Length; i++)
			{
				input[low + i] = tmp[i];
			}

		}
	}
}
