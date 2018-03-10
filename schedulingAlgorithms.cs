using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
	class schedulingAlgorithms
	{
		static public void FCFS(process[] processes, int n)
		{
			int burst = 0, finish = 0;
			for (int i = 0; i < n; i++)
			{
				processes[i].startTime = finish;
				processes[i].waitingTime = processes[i].startTime - processes[i].arrivalTime;
				processes[i].finishTime = processes[i].startTime + processes[i].burstTime;

				//burst += processes[i].burstTime;
				finish = processes[i].finishTime;
			}
		}
	}
}
