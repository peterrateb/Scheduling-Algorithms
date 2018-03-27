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
			for (int i = 0; i < n; i++) {
				processes[i].priority = processes[i].arrivalTime;
			}
			return priority_NP( processes, n);
		}
		static public int SJF_NP(process[] processes, int n){
			for (int i = 0; i < n; i++)
			{
				processes[i].priority = processes[i].burstTime;
			}
			return priority_NP(processes, n);
		}
		static public int SJF_P(process[] processes, int n){
			return 0;
		}
		static public int priority_NP(process[] processes, int n)
		{
			int linesCount = 0;
			Boolean idle = true;
			StreamWriter file = new StreamWriter(@"ganttChart.txt", false);
			merge.SortMerge(processes, 0, n - 1,sort.arrivalTime);
			float arrivalneeded =0;int served = 0, index = 0;
			do
			{
				for (int i = n - 1; i >= served; i--)
				{
					if (processes[i].arrivalTime <= arrivalneeded)
					{
						idle = false;
						index = i; break;
					}
				}
				if (idle) {
					for (int i = served; i< n; i++)
					{
						if (processes[i].arrivalTime > arrivalneeded)
						{
							file.WriteLine("IDLE " + processes[i].arrivalTime);
							linesCount++;
							arrivalneeded = processes[i].arrivalTime;
							index = i; break;
						}
					}

				}
				merge.SortMerge(processes, served, index, sort.priority);
				if (served != n - 1 && processes[served].priority == processes[served + 1].priority)
				{

					int start = served, end = 0;float priority = processes[served].priority;
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

							merge.SortMerge(processes, start, end, sort.arrivalTime);
							break;
						}
					}
				}
				processes[served].startTime = arrivalneeded;
				arrivalneeded += processes[served].burstTime;
				processes[served].finishTime = arrivalneeded;
				file.WriteLine(processes[served].name + " " + (processes[served].finishTime).ToString());
				linesCount++;
				served++;
			} while (served < n);
			file.Close();
			return linesCount;
		}
		static public int priority_P(process[] processes, int n){
			return 0;
		}
		static public int RR(process[] processes, int n, float q)
		{
			merge.SortMerge(processes, 0, n - 1, sort.arrivalTime);
			StreamWriter file = new StreamWriter(@"ganttChart.txt", false);
			file.Flush();
			float time = 0;
			int line_count = 0;
			bool burstflag;
			int finishflag = 0;
			do
			{

				burstflag = false;
				for (int i = 0; i < n; i++)
				{
					if (processes[i].arrivalTime <= time && processes[i].burstTime != 0)
					{
						burstflag = true;
						if (processes[i].burstTime < q)
						{
							time += processes[i].burstTime;
							processes[i].burstTime = 0;
						}
						else
						{
							time += q;
							processes[i].burstTime -= q;
						}
						if (processes[i].burstTime == 0 && finishflag != n - 1) finishflag++;
						file.WriteLine(processes[i].name + " " + time);
						line_count++;
					}
				}
				if (processes[finishflag].arrivalTime > time && burstflag == false)
				{
					burstflag = true;
					time = processes[finishflag].arrivalTime;
					file.WriteLine("IDLE " + time);
				}
			}
			while (burstflag);
			file.Close();
			return line_count;
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
