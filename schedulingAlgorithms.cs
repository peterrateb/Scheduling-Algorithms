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
            return 0;
        }
        static public int SJF_NP(process[] processes, int n)
        {
            return 0;
        }
        static public int SJF_P(process[] processes, int n)
        {
            return 0;
        }
        static public int priority_NP(process[] processes, int n)
        {
            string[] lines = new string[n];

            merge.SortMerge(processes, 0, n - 1, sort.arrivalTime);
            float arrivalneeded = processes[0].arrivalTime; int served = 0, index = 0;
            do
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    if (processes[i].arrivalTime <= arrivalneeded)
                    {
                        index = i; break;
                    }
                }
                merge.SortMerge(processes, served, index, sort.priority);
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

                            merge.SortMerge(processes, start, end, sort.arrivalTime);
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

            return n;
        }
        static public int priority_P(process[] processes, int n)
        {
            return 0;
        }
        static public int RR(process[] processes, int n ,float q)
        {
            merge.SortMerge(processes , 0 , n-1 , sort.arrivalTime);
            StreamWriter file = new StreamWriter(@"ganttChart.txt", false);
            file.Flush();
            float time=0;
            int line_count = 0;
            bool burstflag;
            int finishflag=0;
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
                        if (processes[i].burstTime == 0 && finishflag!=n-1) finishflag++;
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

    }
}
