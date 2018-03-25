using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MergeSort;
using dataTypes;
namespace algorithms
{
	class schedulingAlgorithms
	{
		
		static public int FCFS(process[] processes, int n){
			return 0;
		}
		static public int SJF_NP(process[] processes, int n){
			return 0;
		}
		static public int SJF_P(process[] processes, int n){
			return 0;
		}
		static public int priority_NP(process[] processes, int n)
		{
			string[] lines = new string[n];
			
			merge.SortMerge(processes, 0, n - 1,sort.arrivalTime);
			int arrivalneeded = processes[0].arrivalTime, served = 0, index = 0;
			do
			{
				for (int i = n - 1; i >= 0; i--)
				{
					if (processes[i].arrivalTime <= arrivalneeded)
					{
						index = i; break;
					}
				}
				Console.WriteLine("served= " + served.ToString() + " index= " + index.ToString());
				merge.SortMerge(processes, served, index, sort.priority);
				Console.WriteLine("////////////////");
				for (int i = 0; i < n; i++)
				{
					string line = processes[i].name + " " + processes[i].arrivalTime.ToString() + " " + processes[i].burstTime.ToString() + " " + processes[i].priority.ToString();

					Console.WriteLine(line);
				}
				if (served != n - 1 && processes[served].priority == processes[served + 1].priority)
				{

					int start = served, end = 0, priority = processes[served].priority;
					for (int j = served; j <= index; j++)
					{

						if (processes[j].priority == priority)
						{
							end = j;
						}
						if ((processes[j].priority != priority) || (processes[j].priority == priority && j == index))
						{
							j--;
							if (j == index)
								end = j;

							merge.SortMerge(processes, start, end, sort.index);
							break;
						}
					}
				}
				processes[served].startTime = arrivalneeded;
				arrivalneeded += processes[served].burstTime;
				processes[served].finishTime = arrivalneeded;
				lines[served] = processes[served].name + " " + (processes[served].finishTime).ToString();
				served++;
			} while (served < n);
			File.WriteAllLines(@"ganttChart.txt", lines);

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine(lines[i]);
			}


			return n;
		}
		static public int priority_P(process[] processes, int n){
			return 0;
		}
		static public int RR(process[] processes, int n){
			return 0;
		}

	}
}
