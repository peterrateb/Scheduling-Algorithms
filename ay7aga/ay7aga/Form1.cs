using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ay7aga
{
    public partial class Form1 : Form
    {
        string[] lines = File.ReadAllLines(@"C:\Users\Peter\Documents\Visual Studio 2012\Projects\ay7aga\ay7aga\inputProcess.txt");
        static int processno = 4;
        string[] processname = new string[processno];
        int[] processEndTime = new int[processno];

        public Form1()
        {
            for(int i=0 ; i<processno ; i++)
            {
                string[] splitedtext = lines[i].Split(' ');
                processname[i] = splitedtext[0];
                processEndTime[i] = int.Parse(splitedtext[1]);

            }
            /*processes[0] = 130;
            processes[1] = 200;
            processes[2] = 340;
            processes[3] = 120;*/
           
            InitializeComponent();

        }
        
        bool lockflag =false;
        //Label[] L = new Label[processno];
        Label[] Rect = new Label[processno];
        Label[] time = new Label[processno + 1]; 
        private void Form1_Load(object sender, EventArgs e)
        {

            if (!lockflag)
            {
                lockflag = true;
                //Graphics G = e.Graphics;
                int startpoint = 50;
                int timesum = 0;
                time[0] = new Label();
                time[0].Location = new Point(startpoint-5, 70); //startpoint here is the next start point
                time[0].AutoSize = true;
                time[0].BackColor = System.Drawing.Color.Transparent;
                time[0].Text = "0";
                time[0].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                panel1.Controls.Add(time[0]);
                for (int i = 0; i < processno; i++)
                {
                    //GraphicObject.DrawRectangle(WhitePen, startpoint, 50, i * 50, 85);
                    Rect[i] = new Label ();
                    Rect[i].Location  = new Point(startpoint, 30);
                    Rect[i].Size = new System.Drawing.Size(processEndTime[i] - timesum, 40);
                    Rect[i].Text = processname[i];
                    Rect[i].BackColor = System.Drawing.Color.Maroon;
                    Rect[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    Rect[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    startpoint = processEndTime[i]+50;
                    timesum = processEndTime[i];
                    time[i] = new Label();
                    time[i].Location = new Point(startpoint-5, 70); //startpoint here is the next start point
                    time[i].AutoSize = true;
                    time[i].BackColor = System.Drawing.Color.Transparent;
                    time[i].Text = timesum.ToString();
                    time[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    //G.DrawRectangle(WhitePen, Rect[i - 1]);
                    //G.FillRectangle(fillMaroon, Rect[i - 1]);
                    //L[i - 1] = new Label();
                    //L[i - 1].Text = "P" + i;
                    //L[i - 1].Location = new Point(startpoint - 8 + i * 25, 89);
                    //L[i - 1].AutoSize = true;
                    panel1.Controls.Add(Rect[i]);
                    panel1.Controls.Add(time[i]);
                    //Label L = new Label();
                    //L[0].Text="P";
                    //L[0].Location = new Point(50 + ((i - 1) * 50 ) + i*25, 85);
                    
                }
                this.Controls.Add(panel1);

            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
     
  




    }
}
