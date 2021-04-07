
namespace Photoshop1
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainPic = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.GR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GI = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GI)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPic
            // 
            this.MainPic.Location = new System.Drawing.Point(404, 39);
            this.MainPic.Name = "MainPic";
            this.MainPic.Size = new System.Drawing.Size(389, 293);
            this.MainPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainPic.TabIndex = 4;
            this.MainPic.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(12, 39);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(386, 293);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Return to Main";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GR
            // 
            chartArea1.AxisX.Maximum = 255D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "GR";
            this.GR.ChartAreas.Add(chartArea1);
            this.GR.Location = new System.Drawing.Point(12, 338);
            this.GR.Name = "GR";
            series1.ChartArea = "GR";
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "GR";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.GR.Series.Add(series1);
            this.GR.Size = new System.Drawing.Size(190, 100);
            this.GR.TabIndex = 7;
            this.GR.Text = "chart1";
            // 
            // GG
            // 
            chartArea2.AxisX.Maximum = 255D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.Name = "GG";
            this.GG.ChartAreas.Add(chartArea2);
            this.GG.Location = new System.Drawing.Point(208, 338);
            this.GG.Name = "GG";
            series2.ChartArea = "GG";
            series2.Color = System.Drawing.Color.Green;
            series2.Name = "GG";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.GG.Series.Add(series2);
            this.GG.Size = new System.Drawing.Size(190, 100);
            this.GG.TabIndex = 8;
            this.GG.Text = "chart2";
            // 
            // GB
            // 
            chartArea3.AxisX.Maximum = 255D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.Name = "GB";
            this.GB.ChartAreas.Add(chartArea3);
            this.GB.Location = new System.Drawing.Point(404, 338);
            this.GB.Name = "GB";
            series3.ChartArea = "GB";
            series3.Color = System.Drawing.Color.Blue;
            series3.Name = "GB";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.GB.Series.Add(series3);
            this.GB.Size = new System.Drawing.Size(190, 100);
            this.GB.TabIndex = 9;
            this.GB.Text = "chart3";
            // 
            // GI
            // 
            chartArea4.AxisX.Maximum = 255D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.Name = "GI";
            this.GI.ChartAreas.Add(chartArea4);
            this.GI.Location = new System.Drawing.Point(600, 338);
            this.GI.Name = "GI";
            series4.ChartArea = "GI";
            series4.Color = System.Drawing.Color.Gray;
            series4.Name = "GI";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.GI.Series.Add(series4);
            this.GI.Size = new System.Drawing.Size(190, 100);
            this.GI.TabIndex = 10;
            this.GI.Text = "chart4";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GI);
            this.Controls.Add(this.GB);
            this.Controls.Add(this.GG);
            this.Controls.Add(this.GR);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.MainPic);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox MainPic;
        public System.Windows.Forms.DataVisualization.Charting.Chart GR;
        public System.Windows.Forms.DataVisualization.Charting.Chart GG;
        public System.Windows.Forms.DataVisualization.Charting.Chart GB;
        public System.Windows.Forms.DataVisualization.Charting.Chart GI;
    }
}