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
			for (int i = 0; i < n; i++)
			{
				string line = processes[i].name + " " + processes[i].arrivalTime.ToString() + " " + processes[i].burstTime.ToString() + " " + processes[i].priority.ToString();

				Console.WriteLine(line);
			}
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









		/*

			//Boolean cont = false; int start = 0, end = 0,arrivalTime = 0;
			for (int i = 0; i < n; i++) {
					if (i!=n-1&&processes[i].arrivalTime == processes[i+1].arrivalTime&&!cont) {
						cont = true;
						start = i;
						arrivalTime = processes[i].arrivalTime;
					}
					else if (processes[i].arrivalTime == arrivalTime && cont)
					{
						end = i;
					}
					if (((processes[i].arrivalTime != arrivalTime) || (i == n - 1 && processes[i].arrivalTime == arrivalTime)) && cont)
					{ 
						i--;
						if (i == n - 1)
							end = i;
						cont = false;
						merge.SortMerge(processes, start, end, 1);

						Boolean cont1 = false; int start1 = 0, end1 = 0,priority = 0;
						for (int j = start; j <= end; j++)
						{
							if (j!=end&&processes[j].priority == processes[j + 1].priority && !cont1)
							{
								cont1 = true;
								start1 = j;
								priority = processes[j].priority;
							}
							else if (processes[j].priority == priority && cont1)
							{
								end1 = j;
							}
							if (((processes[j].priority != priority)||(processes[j].priority == priority&& j ==end)) && cont1)
							{
								j--;
								if (j == end)
									end1 = j;
								cont1 = false;
								merge.SortMerge(processes, start1, end1, 2);
							}
						}
					}
			}
		/*int burst = 0, finish = 0;
		for (int i = 0; i < n; i++)
		{
			if (processes[i].priority == processes[i + 1].priority && processes[i].arrivalTime == processes[i + 1].arrivalTime && !cont)
			{
				start = i;
				cont = true;
				priority = processes[i].priority;
				arrivalTime = processes[i].arrivalTime;
			}
			else if (processes[i].priority == priority && processes[i].arrivalTime == arrivalTime && cont)
			{
				end = i;
			}
			else if (processes[i].priority != priority || processes[i].arrivalTime != arrivalTime && cont)
			{
				cont = false;
				merge.SortMerge(processes, start, end, 2);
			}
		}*/
		/*
			processes[i].startTime = finish;
			processes[i].waitingTime = processes[i].startTime - processes[i].arrivalTime;
			processes[i].finishTime = processes[i].startTime + processes[i].burstTime;

			//burst += processes[i].burstTime;
			finish = processes[i].finishTime;*/



	}
}
