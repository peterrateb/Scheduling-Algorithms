namespace SchedulingAlgorithmsProject
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.Algorithm = new System.Windows.Forms.ComboBox();
			this.processNo = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.QuantumTime = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Algorithm
			// 
			this.Algorithm.AllowDrop = true;
			this.Algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Algorithm.Location = new System.Drawing.Point(154, 112);
			this.Algorithm.Name = "Algorithm";
			this.Algorithm.Size = new System.Drawing.Size(82, 21);
			this.Algorithm.TabIndex = 0;
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
			this.button1.Location = new System.Drawing.Point(113, 169);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Next";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// QuantumTime
			// 
			this.QuantumTime.Enabled = false;
			this.QuantumTime.Location = new System.Drawing.Point(98, 139);
			this.QuantumTime.Name = "QuantumTime";
			this.QuantumTime.Size = new System.Drawing.Size(100, 20);
			this.QuantumTime.TabIndex = 3;
			this.QuantumTime.Text = "Quantum Time";
			this.QuantumTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.QuantumTime.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(38, 203);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.Visible = false;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(64, 231);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(51, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Select an algorithm";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 203);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(207, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Select a choice to continue then press OK";
			this.label2.Visible = false;
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.QuantumTime);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.processNo);
			this.Controls.Add(this.Algorithm);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
		private System.Windows.Forms.TextBox QuantumTime;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

