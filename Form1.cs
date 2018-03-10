using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MergeSort;
using algorithms;
struct process{
	public string name;
	public int arrivalTime;
	public int burstTime;
	public int priority;
	public int startTime;
	public int waitingTime;
	public int finishTime;
}

namespace WindowsFormsApp1
{
	
	public partial class Form1 : Form
	{
		int algorithm = -1, n = -1;//for data validation
		int check=0;
		TextBox[] arrivaltimes;
		TextBox[] bursts;
		TextBox[] priorities;
		Label[] processesNames;
		process[] processes;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			processNo.BorderStyle = BorderStyle.Fixed3D;
			Algorithm.Items.Add("FCFS");
			Algorithm.Items.Add("SJF(P)");
			Algorithm.Items.Add("SJF(NP)");
			Algorithm.Items.Add("Priority(P)");
			Algorithm.Items.Add("Priority(NP)");
			Algorithm.Items.Add("RR");
		
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			check++;
			if (check == 2)
			{
				button1.Enabled = true;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			check++;
			if (check == 2)
			{
				button1.Enabled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (button1.Text == "Next")//first input
			{
				algorithm = Algorithm.SelectedIndex;
				//MessageBox.Show(algorithm.ToString());
				string var;
				var = processNo.Text;
				//MessageBox.Show(var);

				bool parsed = Int32.TryParse(var, out n);
				if (!parsed||n<=0)
				{
					MessageBox.Show("number of processes must be integer larger than zero", "error");
				}
				else
				{
					//MessageBox.Show("n=" + n.ToString());
					displayTableOfProcesses();

				}

			}
			else if (button1.Text == "execute")//second input
			{
				MessageBox.Show("execute");
				if (validateData()) {
				takeData();
					merge.SortMerge(processes, 0, n - 1);
					for (int i = 0; i < n; i++) {
							string line = processes[i].name + " " + processes[i].arrivalTime.ToString() + " " + processes[i].burstTime.ToString() + " " + processes[i].priority.ToString();

							Console.WriteLine(line); 
					}
					schedulingAlgorithms.FCFS(processes, n);
					double waiting = 0;
					for (int i = 0; i < n; i++)
					{
						waiting = processes[i].waitingTime;
					}
					waiting /= n;

				}

			}
			
		}


		private void displayTableOfProcesses()
		{
			int no = 2;
			if (algorithm == 3 || algorithm == 4)
			{
				//priority
				no = 3;
			}
			Label[] titles = new Label[no];
			for (int i = 0; i < no; i++)
			{
				titles[i] = new Label();
				titles[i].Width = 80;
				titles[i].Left = (i + 1) * 90;
				titles[i].Top = 10;
				if (i == 0)
				{
					titles[i].Left = 55;
					titles[i].Text = "Arrival Time";
				}
				else if (i == 1)
				{
					titles[i].Left =  180;
					titles[i].Text = "Burst Time";
				}
				else if (i == 2)
				{
					titles[i].Left = 300;
					titles[i].Text = "Priority No.";
				}
				this.Controls.Add(titles[i]);
			}

			button1.Top = n * 25 + 50;
			button1.Left = 110;
			button1.Text = "execute";
			if (algorithm == 3 || algorithm == 4)
			{
				button1.Left = 170;
			}

			this.Controls.Remove(Algorithm);
			this.Controls.Remove(processNo);
			//button1.Enabled = false;
			arrivaltimes = new TextBox[n];
			bursts = new TextBox[n];
			priorities= new TextBox[n];
			processesNames = new Label[n];

			for (int i = 0; i < n; i++)
			{
				arrivaltimes[i] = new TextBox();
				bursts[i] = new TextBox();
				priorities[i] = new TextBox();
				processesNames[i] = new Label();


				arrivaltimes[i].Left = 40;
				arrivaltimes[i].Top = (i + 1) * 25 + 15;
				bursts[i].Left = 160;
				bursts[i].Top = (i + 1) * 25 + 15;
				priorities[i].Left = 280;
				priorities[i].Top = (i + 1) * 25 + 15;
				processesNames[i].Left = 10;
				processesNames[i].Top = (i + 1) * 25 + 15;
				if (i == 0)
				{
					arrivaltimes[i].Top = 40;
					bursts[i].Top = 40;
					processesNames[i].Top = 40;
				}
				processesNames[i].Text = "P" + (i + 1).ToString();



				this.Controls.Add(arrivaltimes[i]);
				this.Controls.Add(bursts[i]);
				if (algorithm == 3 || algorithm == 4)
				{
					this.Controls.Add(priorities[i]);
				}
				this.Controls.Add(processesNames[i]);
			}
		}

		private bool validateData() {
			int x,y,z; bool parsed1, parsed2, parsed3,priority=false;
			for (int i = 0; i < n; i++) {
				 parsed1 = Int32.TryParse(arrivaltimes[i].Text, out x);
				 parsed2 = Int32.TryParse(bursts[i].Text, out y);
				 parsed3 = Int32.TryParse(priorities[i].Text, out z);
				if (algorithm == 3 || algorithm == 4)
				{
					priority = true;
				}
					if (!parsed1 || !parsed2 || (!parsed3&& priority))
				{
					MessageBox.Show("All text boxes must filled with integers","error");
					return false;
				}
				else if (x < 0 || y < 0 || (z < 0 && priority))
				{
					MessageBox.Show("All text boxes must be filled with positive integers", "error");
					return false;
				}
				else if (y == 0) {
					MessageBox.Show("Burst time text boxes must be filled with integers larger than zero", "error");
					return false;
				}
				
			}
			return true;
		}

		private void takeData() {
			MessageBox.Show(n.ToString());
			processes = new process[n];
			for (int i = 0; i < n; i++) {
				processes[i] = new process();
				processes[i].name = processesNames[i].Text;
				processes[i].arrivalTime = Int32.Parse(arrivaltimes[i].Text);
				processes[i].burstTime = Int32.Parse(bursts[i].Text);
				if (algorithm == 3 || algorithm == 4)
				{
					processes[i].priority = Int32.Parse(priorities[i].Text);
				}
				//System.IO.StreamWriter processinfo;
				//using ( processinfo = new System.IO.StreamWriter(@"D:\Beshoy\engineer\projects\WriteLines2.txt"));
				//{
					/*string line = processes[i].name + " " + processes[i].arrivalTime.ToString() + " " + processes[i].burstTime.ToString() + " " + processes[i].priority.ToString();
					
					Console.WriteLine(line);*/
				//}
			}
		}

		
	}
	
}
