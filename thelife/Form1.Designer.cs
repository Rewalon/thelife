﻿namespace thelife
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBoxColorizingAge = new System.Windows.Forms.CheckBox();
            this.nudMaxAge = new System.Windows.Forms.NumericUpDown();
            this.nudMinAge = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDiesByAge = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.nudDensity = new System.Windows.Forms.NumericUpDown();
            this.nudResolution = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelGenerations = new System.Windows.Forms.Label();
            this.labelLifeCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxColorizingAge);
            this.splitContainer1.Panel1.Controls.Add(this.nudMaxAge);
            this.splitContainer1.Panel1.Controls.Add(this.nudMinAge);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxDiesByAge);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStop);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStart);
            this.splitContainer1.Panel1.Controls.Add(this.nudDensity);
            this.splitContainer1.Panel1.Controls.Add(this.nudResolution);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(1078, 494);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // checkBoxColorizingAge
            // 
            this.checkBoxColorizingAge.AutoSize = true;
            this.checkBoxColorizingAge.Location = new System.Drawing.Point(13, 165);
            this.checkBoxColorizingAge.Name = "checkBoxColorizingAge";
            this.checkBoxColorizingAge.Size = new System.Drawing.Size(50, 17);
            this.checkBoxColorizingAge.TabIndex = 7;
            this.checkBoxColorizingAge.Text = "Color";
            this.checkBoxColorizingAge.UseVisualStyleBackColor = true;
            // 
            // nudMaxAge
            // 
            this.nudMaxAge.Location = new System.Drawing.Point(74, 128);
            this.nudMaxAge.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMaxAge.Name = "nudMaxAge";
            this.nudMaxAge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudMaxAge.Size = new System.Drawing.Size(59, 20);
            this.nudMaxAge.TabIndex = 6;
            this.nudMaxAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxAge.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // nudMinAge
            // 
            this.nudMinAge.Location = new System.Drawing.Point(13, 128);
            this.nudMinAge.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMinAge.Name = "nudMinAge";
            this.nudMinAge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudMinAge.Size = new System.Drawing.Size(59, 20);
            this.nudMinAge.TabIndex = 6;
            this.nudMinAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMinAge.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBoxDiesByAge
            // 
            this.checkBoxDiesByAge.AutoSize = true;
            this.checkBoxDiesByAge.Location = new System.Drawing.Point(13, 104);
            this.checkBoxDiesByAge.Name = "checkBoxDiesByAge";
            this.checkBoxDiesByAge.Size = new System.Drawing.Size(80, 17);
            this.checkBoxDiesByAge.TabIndex = 1;
            this.checkBoxDiesByAge.Text = "dies by age";
            this.checkBoxDiesByAge.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStop.Location = new System.Drawing.Point(13, 227);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(120, 33);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(13, 188);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(120, 33);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // nudDensity
            // 
            this.nudDensity.Location = new System.Drawing.Point(13, 78);
            this.nudDensity.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudDensity.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDensity.Name = "nudDensity";
            this.nudDensity.Size = new System.Drawing.Size(120, 20);
            this.nudDensity.TabIndex = 3;
            this.nudDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDensity.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // nudResolution
            // 
            this.nudResolution.Location = new System.Drawing.Point(13, 26);
            this.nudResolution.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudResolution.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudResolution.Name = "nudResolution";
            this.nudResolution.Size = new System.Drawing.Size(120, 20);
            this.nudResolution.TabIndex = 2;
            this.nudResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudResolution.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Density";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolution";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(920, 490);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelLifeCount);
            this.groupBox1.Controls.Add(this.labelGenerations);
            this.groupBox1.Location = new System.Drawing.Point(13, 267);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 213);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistic";
            // 
            // labelGenerations
            // 
            this.labelGenerations.AutoSize = true;
            this.labelGenerations.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGenerations.Location = new System.Drawing.Point(3, 16);
            this.labelGenerations.Name = "labelGenerations";
            this.labelGenerations.Size = new System.Drawing.Size(64, 13);
            this.labelGenerations.TabIndex = 0;
            this.labelGenerations.Text = "Generations";
            // 
            // labelLifeCount
            // 
            this.labelLifeCount.AutoSize = true;
            this.labelLifeCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLifeCount.Location = new System.Drawing.Point(3, 29);
            this.labelLifeCount.Name = "labelLifeCount";
            this.labelLifeCount.Size = new System.Drawing.Size(32, 13);
            this.labelLifeCount.TabIndex = 1;
            this.labelLifeCount.Text = "Lifes:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 494);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "The Life Game";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown nudDensity;
        private System.Windows.Forms.NumericUpDown nudResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxDiesByAge;
        private System.Windows.Forms.NumericUpDown nudMaxAge;
        private System.Windows.Forms.NumericUpDown nudMinAge;
        private System.Windows.Forms.CheckBox checkBoxColorizingAge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelLifeCount;
        private System.Windows.Forms.Label labelGenerations;
    }
}

