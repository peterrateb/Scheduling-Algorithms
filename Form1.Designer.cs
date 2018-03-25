namespace WindowsFormsApp1
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Algorithm = new System.Windows.Forms.ComboBox();
			this.processNo = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// Algorithm
			// 
			this.Algorithm.AllowDrop = true;
			this.Algorithm.FormattingEnabled = true;
			this.Algorithm.Location = new System.Drawing.Point(38, 112);
			this.Algorithm.Name = "Algorithm";
			this.Algorithm.Size = new System.Drawing.Size(219, 21);
			this.Algorithm.TabIndex = 0;
			this.Algorithm.Text = "Select the needing Schedule Algorithm";
			this.Algorithm.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// processNo
			// 
			this.processNo.Location = new System.Drawing.Point(54, 86);
			this.processNo.Name = "processNo";
			this.processNo.Size = new System.Drawing.Size(185, 20);
			this.processNo.TabIndex = 1;
			this.processNo.Text = "please write the number of processes";
			this.processNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(100, 160);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Next";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click); 
			// 
			// panel2
			// 
			this.panel2 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel2.Visible = false;
			this.panel2.AutoScroll = true;
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel2.ForeColor = System.Drawing.Color.White;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(632, 250);
			this.panel2.TabIndex = 0;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632,250);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.processNo);
			this.Controls.Add(this.Algorithm);
			this.Name = "Form1";
			this.Text = "Scheduling Algorithms";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox Algorithm;
		private System.Windows.Forms.TextBox processNo;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel2;
	}
}

