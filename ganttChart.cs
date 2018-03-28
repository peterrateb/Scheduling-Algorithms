using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using MergeSort;
using algorithms;
using dataTypes;

namespace WindowsFormsApp1
{
    public partial class ganttChart : Form
    {
        int nolines;
        //process[] processes;
        int n;
        int scale;
        float waitingtime;
        Label[] Rect;
        Label[] time;
        Label avgWaitingTime = new Label();
        public ganttChart(int no, float totalwaitingtime, int k)
        {
            InitializeComponent();
            n = k;
            waitingtime = totalwaitingtime;
            nolines = no;
            //processes = proc;
        }

        private void ganttChart_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            scale = int.Parse(textBox1.Text);
            ganttDisplay(nolines, waitingtime, n, scale);

        }

        private void ganttDisplay(int processno, float totalwaitingtime, int n, int s)
        {
            string[] lines = File.ReadAllLines(@"ganttChart.txt");
            string[] processname = new string[processno];
            float[] processEndTime = new float[processno];
            for (int i = 0; i < processno; i++)
            {
                string[] splitedtext = lines[i].Split(' ');
                processname[i] = splitedtext[0];
                processEndTime[i] = float.Parse(splitedtext[1]);

            }
            time = new Label[processno + 1];
            Rect = new Label[processno];
            float startpoint = 50;
            float timesum = 0;
            time[0] = new Label();
            time[0].Location = new Point((int)startpoint - 5, 70); //startpoint here is the next start point
            time[0].AutoSize = true;
            time[0].BackColor = System.Drawing.Color.Transparent;
            time[0].Text = "0";
            time[0].Font = new Font("Microsoft Sans Serif", 6+s/2);
            time[0].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Controls.Add(time[0]);
            for (int i = 0; i < processno; i++)
            {
                float rectwidth = (processEndTime[i] - timesum) * s;
                bool smallwidth = false;
                if (rectwidth < 20)
                {
                    rectwidth = 20;
                    smallwidth = true;
                }
                Rect[i] = new Label();
                Rect[i].Location = new Point((int)startpoint, 30);
                Rect[i].Size = new System.Drawing.Size((int)rectwidth, 40);
                Rect[i].Text = processname[i];
                Rect[i].Font = new Font("Microsoft Sans Serif", 6 );
                if (Rect[i].Text == "IDLE") Rect[i].BackColor = System.Drawing.Color.Red;
                else Rect[i].BackColor = System.Drawing.Color.Goldenrod;
                Rect[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                Rect[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                startpoint += rectwidth;
                timesum = processEndTime[i];
                time[i + 1] = new Label();
                time[i + 1].Location = new Point((int)startpoint - 5, 70); //startpoint here is the next start point
                time[i + 1].AutoSize = true;
                time[i + 1].BackColor = System.Drawing.Color.Transparent;
                time[i + 1].Text = timesum.ToString();
                time[i + 1].Font = new Font("Microsoft Sans Serif", 6+s/2) ;
                time[i + 1].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Controls.Add(Rect[i]);
                this.Controls.Add(time[i + 1]);
                avgWaitingTime.Text = "Average waiting time = " + (totalwaitingtime / n).ToString();
                avgWaitingTime.Font = new Font("Microsoft Sans Serif", 10 );
                avgWaitingTime.Left = 200;
                avgWaitingTime.Top = 100;
                //avgWaitingTime.Width = 200;
                avgWaitingTime.AutoSize = true;
                avgWaitingTime.Visible = true;
                this.Controls.Add(avgWaitingTime);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            scale = int.Parse(textBox1.Text);
            /*if (scale < 1)
            {
                MessageBox.Show("please Enter a positive integr value","Warning");
            }*/
            deleteChart(nolines);
            ganttDisplay(nolines, waitingtime, n, scale);

        }

        private void deleteChart(int processno)
        {
            this.Controls.Remove(time[0]);
            this.Controls.Remove(avgWaitingTime);
            for (int i = 0; i < processno; i++)
            {
                this.Controls.Remove(Rect[i]);
                this.Controls.Remove(time[i + 1]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(textBox1.Text, out n))
            {
                if (n < 1 || n > 10)
                {
                    button1.Enabled = false;
                }
                else
                    button1.Enabled = true;
            }
        }
    }
}
