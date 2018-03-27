using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dataTypes;
namespace MergeSort
{
	class merge
	{
		public static void SortMerge(process[] input, int low, int high,sort type)
		{
			if (low < high)
			{
				int middle = (low / 2) + (high / 2);
				SortMerge(input, low, middle,type);
				SortMerge(input, middle + 1, high,type);
				Merge(input, low, middle, high,type);
			}
		}

		private static void Merge(process[] input, int low, int middle, int high,sort type)
		{

			int left = low;
			int right = middle + 1;
			process[] tmp = new process[(high - low) + 1];
			int tmpIndex = 0;

			while ((left <= middle) && (right <= high))
			{
				if ((input[left].arrivalTime < input[right].arrivalTime) && type == sort.arrivalTime)
				{
					tmp[tmpIndex] = input[left];
					left = left + 1;
				}
				else if ((input[left].priority < input[right].priority)&& type == sort.priority)
				{
					tmp[tmpIndex] = input[left];
					left = left + 1;
				}
				else if ((input[left].index < input[right].index) && type == sort.index)
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
