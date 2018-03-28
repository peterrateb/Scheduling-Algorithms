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

		static public int FCFS(process[] processes, int n)
		{
			for (int i = 0; i < n; i++)
			{
				processes[i].priority = processes[i].arrivalTime;
			}
			return priority_NP(processes, n);
		}

		static public int SJF_NP(process[] processes, int n)
		{
			for (int i = 0; i < n; i++)
			{
				processes[i].priority = processes[i].burstTime;
			}
			return priority_NP(processes, n);
		}

		static public int SJF_P(process[] processes, int n)
		{
			StreamWriter file = new StreamWriter(@"ganttChart.txt", false);
			file.Flush();
			float time = 0;
			int line_count = 0;
			for (int i = 0; i < n; i++)
			{
				processes[i].priority = processes[i].burstTime;
			}
			merge.SortMerge(processes, 0, n - 1, sort.priority);
			merge.SortMerge(processes, 0, n - 1, sort.arrivalTime);
			int served = 0;
			bool burstflag;
			float[] tempburst = new float[n];
			for (int i = 0; i < n; i++)
			{
				tempburst[i] = processes[i].burstTime; //copy burst data
			}
			float arrivalneeded = processes[0].arrivalTime;
			processes[0].startTime = processes[0].arrivalTime;
			if (arrivalneeded != 0) //idle
			{
				time = processes[0].arrivalTime;
				file.WriteLine("IDLE " + time);
				line_count++;
			}
			bool idleflag;
			do
			{
				idleflag = false;
				burstflag = false;

				for (int i = 0; i < n; i++)
				{
					if ((tempburst[served] + time) > processes[i].arrivalTime
						&& tempburst[served] > tempburst[i]
						&& tempburst[i] != 0)
					{
						//do preemptive periorty interrubt 
						burstflag = true; idleflag = false;

						if (time < processes[i].arrivalTime) //pass if the current process not excuted
						{
							tempburst[served] -= processes[i].arrivalTime - time;
							time = processes[i].arrivalTime;
							file.WriteLine(processes[served].name + " " + time);
							line_count++;
						}
						served = i;
						processes[served].startTime = time;
						break;
					}
					else if ((tempburst[served] + time) >= processes[i].arrivalTime && tempburst[served] == 0 && tempburst[i] != 0)
					{
						//if process finished , take a not finished process
						burstflag = true; idleflag = false;
						served = i;
						break;
					}
					else if (time < processes[i].arrivalTime && tempburst[i] != 0)
					{
						idleflag = true;
					}
				}

				if (burstflag == false && tempburst[served] != 0) //if the process didn't interrupted and finished
				{
					burstflag = true;
					time += tempburst[served];
					tempburst[served] = 0;
					processes[served].finishTime = time;
					file.WriteLine(processes[served].name + " " + time);
					line_count++;
				}
				//idle burst
				if (idleflag && burstflag == false)
				{
					for (int i = 0; i < n; i++)
					{
						if (processes[i].arrivalTime > time && tempburst[i] != 0)
						{
							burstflag = true;
							time = processes[i].arrivalTime;
							file.WriteLine("IDLE " + time);
							line_count++;
							break;
						}
					}
				}
			} while (burstflag);
			file.Close();
			return line_count;
		}

		static public int priority_NP(process[] processes, int n)
		{
			int linesCount = 0;
			Boolean idle = true;
			StreamWriter file = new StreamWriter(@"ganttChart.txt", false);
			merge.SortMerge(processes, 0, n - 1, sort.arrivalTime);
			float arrivalneeded = 0; int served = 0, index = 0;
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
				if (idle)
				{
					for (int i = served; i < n; i++)
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

					int start = served, end = 0; float priority = processes[served].priority;
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
				idle = true;
			} while (served < n);
			file.Close();
			return linesCount;
		}

		static public int priority_P(process[] processes, int n)
		{
			//string[] lines = new string[n];
			StreamWriter file = new StreamWriter(@"ganttChart.txt", false);
			file.Flush();
			float time = 0;
			int line_count = 0;
			merge.SortMerge(processes, 0, n - 1, sort.priority);
			merge.SortMerge(processes, 0, n - 1, sort.arrivalTime);
			int served = 0;
			bool burstflag;
			float[] tempburst = new float[n];
			for (int i = 0; i < n; i++)
			{
				tempburst[i] = processes[i].burstTime; //copy burst data
			}
			float arrivalneeded = processes[0].arrivalTime;
			processes[0].startTime = processes[0].arrivalTime;
			if (arrivalneeded != 0) //idle
			{
				time = processes[0].arrivalTime;
				file.WriteLine("IDLE " + time);
				line_count++;
			}
			bool idleflag;
			do
			{
				idleflag = false;
				burstflag = false;

				for (int i = 0; i < n; i++)
				{
					if ((tempburst[served] + time) > processes[i].arrivalTime
						&& processes[served].priority > processes[i].priority
						&& tempburst[i] != 0)
					{
						//do preemptive periorty interrubt 
						burstflag = true; idleflag = false;

						if (time < processes[i].arrivalTime) //pass if the current process not excuted
						{
							tempburst[served] -= processes[i].arrivalTime - time;
							time = processes[i].arrivalTime;
							file.WriteLine(processes[served].name + " " + time);
							line_count++;
						}
						served = i;
						processes[served].startTime = time;
						break;
					}
					else if ((tempburst[served] + time) >= processes[i].arrivalTime && tempburst[served] == 0 && tempburst[i] != 0)
					{
						//if process finished , take a not finished process
						burstflag = true; idleflag = false;
						served = i;
						break;
					}
					else if (time < processes[i].arrivalTime && tempburst[i] != 0)
					{
						idleflag = true;
					}
				}

				if (burstflag == false && tempburst[served] != 0) //if the process didn't interrupted and finished
				{
					burstflag = true;
					time += tempburst[served];
					tempburst[served] = 0;
					processes[served].finishTime = time;
					file.WriteLine(processes[served].name + " " + time);
					line_count++;
				}
				//idle burst
				if (idleflag && burstflag == false)
				{
					for (int i = 0; i < n; i++)
					{
						if (processes[i].arrivalTime > time && tempburst[i] != 0)
						{
							burstflag = true;
							time = processes[i].arrivalTime;
							file.WriteLine("IDLE " + time);
							line_count++;
							break;
						}
					}
				}
			} while (burstflag);
			file.Close();
			return line_count;
		}

		static public int RR(process[] processes, int n, float q)
		{
			merge.SortMerge(processes, 0, n - 1, sort.arrivalTime);
			StreamWriter file = new StreamWriter(@"ganttChart.txt", false);
			file.Flush();
			float time = 0;
			int line_count = 0;
			bool burstflag;
			int finishflag = 0; //using to detect idle
			float[] tempburst = new float[n];
			for (int i = 0; i < n; i++)
			{
				tempburst[i] = processes[i].burstTime; //copy burst data
			}
			float arrivalneeded = processes[0].arrivalTime;
			processes[0].startTime = processes[0].arrivalTime;
			if (arrivalneeded != 0) //initial idle
			{
				time = processes[0].arrivalTime;
				file.WriteLine("IDLE " + time);
				line_count++;
			}
			do
			{
				burstflag = false;
				for (int i = 0; i < n; i++)
				{
					if (processes[i].arrivalTime <= time && tempburst[i] != 0)
					{
						burstflag = true;
						if (tempburst[i] == processes[i].burstTime) processes[i].startTime = time; //get start time
						if (tempburst[i] < q)
						{
							time += tempburst[i];
							tempburst[i] = 0;
						}
						else
						{
							time += q;
							tempburst[i] -= q;
						}
						if (tempburst[i] == 0 && finishflag != n - 1)
						{
							processes[i].finishTime = time;
							finishflag++;
						}
						else if (tempburst[i] == 0 && finishflag == n - 1)
						{
							processes[i].finishTime = time;
						}
						file.WriteLine(processes[i].name + " " + time);
						line_count++;
					}
				}
				if (processes[finishflag].arrivalTime > time && burstflag == false)
				{
					burstflag = true;
					time = processes[finishflag].arrivalTime;
					file.WriteLine("IDLE " + time);
					line_count++;
				}
			}
			while (burstflag);
			file.Close();
			return line_count;
		}













	}
}
