using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MergeSort;
using algorithms;
using dataTypes;
namespace WindowsFormsApp1
{

	public partial class Form1 : Form
	{
		int algorithm = -1, n = -1;//for data validation
		int check = 0;
		TextBox[] arrivaltimes;
		TextBox[] bursts;
		TextBox[] priorities;
		Label[] processesNames;
		Label[] titles;
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
			int nolines=0;
			//first input
			if (button1.Text == "Next")
			{
				algorithm = Algorithm.SelectedIndex;
				//MessageBox.Show(algorithm.ToString());
				string var;
				var = processNo.Text;
				//MessageBox.Show(var);

				bool parsed = Int32.TryParse(var, out n);
				if (!parsed || n <= 0)
				{
					MessageBox.Show("number of processes must be integer larger than zero", "error");
				}
				else
				{
					//MessageBox.Show("n=" + n.ToString());
					displayTableOfProcesses();

				}

			}
			//second input
			else if (button1.Text == "execute")
			{
				MessageBox.Show("execute"); 
				if (validateData())
				{
					takeData();
					Console.WriteLine(algorithm.ToString());
					switch (algorithm)
					{
						case 0:
							nolines = schedulingAlgorithms.FCFS(processes, n);
							break;
						case 1:
							nolines = schedulingAlgorithms.SJF_P(processes, n);
							break;
						case 2:
							nolines = schedulingAlgorithms.SJF_NP(processes, n);
							break;
						case 3:
							nolines = schedulingAlgorithms.priority_P(processes, n);
							break;
						case 4:
							nolines = schedulingAlgorithms.priority_NP(processes, n);
							break;
						case 5:
							nolines = schedulingAlgorithms.RR(processes, n);
							break;
					}
					/* clear the form */
					for (int i = 0; i < n; i++)
					{
						this.Controls.Remove(arrivaltimes[i]);
						this.Controls.Remove(bursts[i]);
						if (algorithm == 3 || algorithm == 4)
						{
							this.Controls.Remove(priorities[i]);
						}
						this.Controls.Remove(processesNames[i]);
					}
					this.Controls.Remove(titles[0]);
					this.Controls.Remove(titles[1]);
					if (algorithm == 3 || algorithm == 4)
					{
						this.Controls.Remove(titles[2]);
					}
					this.Controls.Remove(button1);

					/* show the output */
					//Console.WriteLine(nolines.ToString());
					ganttDisplay(nolines);
					
					
						for (int i = 0; i < n; i++)
						{
							string line = processes[i].name + " " + processes[i].arrivalTime.ToString() + " " + processes[i].burstTime.ToString() + " " + processes[i].priority.ToString();

							Console.WriteLine(line);
						}
						

					

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
			 titles = new Label[no];
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
					titles[i].Left = 180;
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
			priorities = new TextBox[n];
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
			float x, y;int z; bool parsed1, parsed2, parsed3, priority = false;
			for (int i = 0; i < n; i++) {
				parsed1 = float.TryParse(arrivaltimes[i].Text, out x);
				parsed2 = float.TryParse(bursts[i].Text, out y);
				parsed3 = Int32.TryParse(priorities[i].Text, out z);
				Console.WriteLine("p1="+parsed1.ToString()+" p2="+ parsed2+" p3="+ parsed3);
				if (algorithm == 3 || algorithm == 4)
				{
					priority = true;
				}
				if (!parsed1 || x < 0)
				{
					MessageBox.Show("All arrival time boxes must be filled with positive floats", "error");
					return false;
				}
				else if (!parsed2 || y <= 0)
				{
					MessageBox.Show("All burst time boxes must be filled with floats higher than zero", "error");
					return false;
				}

				else if (!parsed3 && priority && z < 0 )
				{
					MessageBox.Show("priority boxes must be filled with positive integers", "error");
					return false;
				}

			}
			return true;
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void takeData() {
			MessageBox.Show(n.ToString());
			processes = new process[n];
			for (int i = 0; i < n; i++) {
				processes[i] = new process();
				processes[i].name = processesNames[i].Text;
				processes[i].arrivalTime = float.Parse(arrivaltimes[i].Text);
				processes[i].burstTime = float.Parse(bursts[i].Text);
				if (algorithm == 3 || algorithm == 4)
				{
					processes[i].priority = Int32.Parse(priorities[i].Text);
				}
			}
		}

		private void ganttDisplay(int processno)
		{
			string[] lines = File.ReadAllLines(@"ganttChart.txt");
			string[] processname = new string[processno];
			int[] processEndTime = new int[processno];
			for (int i = 0; i < processno; i++)
			{
				string[] splitedtext = lines[i].Split(' ');
				processname[i] = splitedtext[0];
				processEndTime[i] = int.Parse(splitedtext[1]);

			}
			Label[] Rect = new Label[processno];
			Label[] time = new Label[processno + 1];

			int startpoint = 50;
			int timesum = 0;
			time[0] = new Label();
			time[0].Location = new Point(startpoint - 5, 70); //startpoint here is the next start point
			time[0].AutoSize = true;
			time[0].BackColor = System.Drawing.Color.Transparent;
			time[0].Text = "0";
			time[0].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.panel2.Visible = true;
			panel2.Controls.Add(time[0]);
			for (int i = 0; i < processno; i++)
			{
				Rect[i] = new Label();
				Rect[i].Location = new Point(startpoint, 30);
				Rect[i].Size = new System.Drawing.Size(processEndTime[i] - timesum, 40);
				Rect[i].Text = processname[i];
				Rect[i].BackColor = System.Drawing.Color.Maroon;
				Rect[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				Rect[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				startpoint = processEndTime[i] + 50;
				timesum = processEndTime[i];
				time[i] = new Label();
				time[i].Location = new Point(startpoint - 5, 70); //startpoint here is the next start point
				time[i].AutoSize = true;
				time[i].BackColor = System.Drawing.Color.Transparent;
				time[i].Text = timesum.ToString();
				time[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				panel2.Controls.Add(Rect[i]);
				panel2.Controls.Add(time[i]);
			}
			this.Controls.Add(panel2);
		}


	}

}

	

