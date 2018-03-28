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
using SchedulingAlgorithmsProject;

namespace SchedulingAlgorithmsProject
{

	public partial class Form1 : Form
	{
		/// <summary>
		/// for data validation
		/// </summary>
		int algorithm = -1, n = -1;
		int check1 = 0, check2 = 0, check3 = 0;

		/// <summary>
		/// for data input interface
		/// </summary>
		TextBox[] arrivaltimes;
		TextBox[] bursts;
		TextBox[] priorities;
		Label[] processesNames;
		Label[] titles;
		process[] processes;
		float quantum;
		ComboBox cont;
		Label avgWaitingTime = new Label();

		/// <summary>
		/// for ganttchart display
		/// </summary>
		Label[] Rect;
		Label[] time;
		public int nolines = 0;


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
			comboBox1.Items.Add("Reschedule the same processes with an other algorithm");
			comboBox1.Items.Add("Go to home page to schedule new processes");

		}


		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			check1++;
			if (Algorithm.SelectedIndex != -1 && check1 >= 1 && check2 >= 1 && ((check3 >= 1 && algorithm == 5) || algorithm != 5))
			{
				button1.Enabled = true;
				check1 = 0; check2 = 0; check3 = 0;
			}
			else if (button1.Text == "execute")
			{
				if (Algorithm.SelectedIndex != -1 && check1 >= 1 )
				{
					if (algorithm != 5)
					{
						button1.Enabled = true;
						check1 = 0; check2 = 0; check3 = 0;
					}
					if (algorithm == 5 && QuantumTime.Text != "Quantum Time") {
						button1.Enabled = true;
						check1 = 0; check2 = 0; check3 = 0;
					}
				}
			}
			if (Algorithm.SelectedIndex == 5)
			{
				QuantumTime.Enabled = true;
			}
			else
			{
				QuantumTime.Text = "Quantum Time";
				QuantumTime.Enabled = false;
			}
		}

		private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex >= 0)
			{
				button2.Enabled = true;
			}
		}


		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (processNo.Text != "please write the number of processes")
			{
				check2++;
			}
			if (Algorithm.SelectedIndex != -1 && check1 >= 1 && check2 >= 1)
			{
				if ((algorithm == 5 && QuantumTime.Text != "Quantum Time") || (!QuantumTime.Enabled))
				{
					button1.Enabled = true;
					check1 = 0; check2 = 0; check3 = 0;
				}
			}
		}

		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{
			check3++;
			if (button1.Text == "Next")
			{
				if (Algorithm.SelectedIndex != -1 && check1 >= 1 && check2 >= 1 )
				{
					if (algorithm != 5)
					{
						button1.Enabled = true;
						check1 = 0; check2 = 0; check3 = 0;
					}
					if (algorithm == 5 && QuantumTime.Text != "Quantum Time")
					{
						button1.Enabled = true;
						check1 = 0; check2 = 0; check3 = 0;
					}
				}
			}
			else if (button1.Text == "execute")
			{
				if (Algorithm.SelectedIndex != -1 && check1 >= 1)
				{
					if (algorithm != 5)
					{
						button1.Enabled = true;
						check1 = 0; check2 = 0; check3 = 0;
					}
					if (algorithm == 5 && QuantumTime.Text != "Quantum Time")
					{
						button1.Enabled = true;
						check1 = 0; check2 = 0; check3 = 0;
					}
				}
			}
		}



		private void button1_Click(object sender, EventArgs e)
		{
			nolines = 0;
			//first input
			if (button1.Text == "Next")
			{
				Boolean _checked = true;
				algorithm = Algorithm.SelectedIndex;
				
				string var;
				var = processNo.Text;

				bool parsed = Int32.TryParse(var, out n);
				if (!parsed || n <= 0)
				{
					_checked = false;
					MessageBox.Show("number of processes must be integer larger than zero", "error");

				}
				else if (algorithm == 5)
				{
					parsed = float.TryParse(QuantumTime.Text, out quantum);
					if (!parsed || quantum <= 0)
					{
						_checked = false;
						MessageBox.Show("Quantum Time must be postive number", "error");
					}
				}
				if (_checked)
				{
					
					this.AutoScroll = false;
					comboBox1.Visible = false;
					button2.Visible = false;
					displayTableOfProcesses();
					this.AutoScroll = true;

				}


			}
			//second input
			else if (button1.Text == "Execute")
			{
				algorithm = Algorithm.SelectedIndex;
				if (algorithm == 5)
				{
					Boolean parsed = float.TryParse(QuantumTime.Text, out quantum);
					if (!parsed || quantum <= 0)
					{
						MessageBox.Show("Quantum Time must be postive number", "error");
					}
				}
				if (validateData())
				{
					takeData();
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
							nolines = schedulingAlgorithms.RR(processes, n, quantum);
							break;
					}

					clearForm();

					/* show the output */
					
					ganttChart ganttform = new ganttChart(nolines, avgWaitingTimeDisplay(), n);
					ganttform.Show();

					/*show the continue form */ 
					 
					this.AutoScroll = false;
					displayContForm();
					this.AutoScroll = true;





				}

			}
			//reschedule
			else if (button1.Text == "execute")
			{
				int prevalgorithm = algorithm;Boolean flag = true;
				algorithm = Algorithm.SelectedIndex;
				if (algorithm == 5)
				{
					Boolean parsed = float.TryParse(QuantumTime.Text, out quantum);
					if (!parsed || quantum <= 0)
					{
						flag = false;
						MessageBox.Show("Quantum Time must be postive number", "error");
					}
				}
				if(flag)
				{
					button1.Text = "Execute";
					merge.SortMerge(processes, 0, n - 1, sort.index);
					this.AutoScroll = false;
					displayTableOfProcesses();
					this.AutoScroll = true;
					for (int i = 0; i < n; i++)
					{
						arrivaltimes[i].Text = processes[i].arrivalTime.ToString();
						bursts[i].Text = processes[i].burstTime.ToString();
						if (prevalgorithm == 3 || prevalgorithm == 4 && (algorithm == 3 || algorithm == 4))
						{
							priorities[i].Text = processes[i].priority.ToString();
						}

					}
				}



			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (button2.Text == "OK")
			{
				int index = comboBox1.SelectedIndex;
				if (index < 0)
				{
					MessageBox.Show("you must select one choice then press Ok", "error");
				}
				else
				{
					button2.Visible = false;
					comboBox1.Visible = false;
					avgWaitingTime.Visible = false;
					//deleteChart(nolines);

				}
				if (index == 0 || index == 1)
				{
					this.AutoScroll = false;
					Algorithm.Visible = true;
					Algorithm.Text = "Select the needing Schedule Algorithm";
					QuantumTime.Visible = true;
					QuantumTime.Enabled = false;
					this.Controls.Add(QuantumTime);
					QuantumTime.Text = "Quantum Time";
					this.button1.Location = new System.Drawing.Point(113, 169);
					this.button1.Size = new System.Drawing.Size(75, 23);
					button1.Visible = true;
					this.AutoScroll = true;
				}
				if (index == 0)//reschedule
				{
					button1.Text = "execute";
				}

				else if (index == 1)//home page
				{
					this.AutoScroll = false;
					processNo.Visible = true;
					processNo.Text = "please write the number of processes";
					button1.Text = "Next";
					this.AutoScroll = true;
				}
			}
		}


		private void clearForm()
		{
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
			if (algorithm == 5)
			{
				this.Controls.Remove(QuantumTime);
			}
			button1.Visible = false;
			button1.Enabled = false;
			Algorithm.Visible = false;
			QuantumTime.Visible = false;
			avgWaitingTime.Visible = false;
			this.Controls.Remove(avgWaitingTime);

		}

		private void displayContForm()
		{
			button2.Visible = true;
			button2.Text = "OK";
			button2.Left = 140;
			button2.Top = 180;
			button2.Enabled = false;

			comboBox1.Visible = true;
			comboBox1.AllowDrop = true;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(38, 150);
			comboBox1.Size = new System.Drawing.Size(340, 21);
			comboBox1.TabIndex = 0;
			comboBox1.Text = "Select your choice to continue then press OK";
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
					if (algorithm == 3 || algorithm == 4)
					{
						titles[i].Left = 300;
						titles[i].Text = "Priority No.";
					}
				}
				this.Controls.Add(titles[i]);
			}

			button1.Top = n * 25 + 50;
			button1.Left = 110;
			button1.Text = "Execute";
			button1.Enabled = true;
			if (algorithm == 3 || algorithm == 4)
			{
				button1.Left = 170;
			}

			Algorithm.Visible = false;
			processNo.Visible = false;
			QuantumTime.Visible = false;

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

		private float avgWaitingTimeDisplay()
		{
			float totalwaitingtime = 0;
			for (int i = 0; i < n; i++)
			{
				processes[i].waitingTime = processes[i].finishTime - processes[i].arrivalTime - processes[i].burstTime;
				totalwaitingtime += processes[i].waitingTime;
			}
			return totalwaitingtime;

		}

		private bool validateData()
		{
			float x, y; int z; bool parsed1, parsed2, parsed3, priority = false;
			Boolean check = true;
			for (int i = 0; i < n; i++)
			{
				parsed1 = float.TryParse(arrivaltimes[i].Text, out x);
				parsed2 = float.TryParse(bursts[i].Text, out y);
				parsed3 = Int32.TryParse(priorities[i].Text, out z);
				if (algorithm == 3 || algorithm == 4)
				{
					priority = true;
				}
				if (!parsed1 || x < 0)
				{
					MessageBox.Show("All arrival time boxes must be filled with positive floats", "error");
					return false;
				}
				if (!parsed2 || y <= 0)
				{
					MessageBox.Show("All burst time boxes must be filled with floats higher than zero", "error");
					return false;
				}

				if ((!parsed3 || z < 0) && priority)
				{
					MessageBox.Show("priority boxes must be filled with positive integers", "error");
					return false;
				}

			}

			return true;
		}

		private void takeData()
		{
			processes = new process[n];

			for (int i = 0; i < n; i++)
			{
				processes[i] = new process();
				processes[i].name = processesNames[i].Text;
				processes[i].arrivalTime = float.Parse(arrivaltimes[i].Text);
				processes[i].burstTime = float.Parse(bursts[i].Text);
				processes[i].index = i;
				if (algorithm == 3 || algorithm == 4)
				{
					processes[i].priority = Int32.Parse(priorities[i].Text);
				}
			}
		}



	}

}