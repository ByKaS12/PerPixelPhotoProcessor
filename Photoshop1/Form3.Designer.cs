
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainPic = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Gist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Lx = new System.Windows.Forms.Label();
            this.Ly = new System.Windows.Forms.Label();
            this.Stream = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
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
            // Gist
            // 
            chartArea3.AxisX.Maximum = 255D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.Name = "Gist";
            this.Gist.ChartAreas.Add(chartArea3);
            this.Gist.Location = new System.Drawing.Point(12, 338);
            this.Gist.Name = "Gist";
            series9.ChartArea = "Gist";
            series9.Color = System.Drawing.Color.Red;
            series9.Name = "GR";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series10.ChartArea = "Gist";
            series10.Color = System.Drawing.Color.Green;
            series10.Name = "GG";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series10.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series11.ChartArea = "Gist";
            series11.Color = System.Drawing.Color.Blue;
            series11.Name = "GB";
            series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series11.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series12.ChartArea = "Gist";
            series12.Color = System.Drawing.Color.Gray;
            series12.Name = "GI";
            series12.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series12.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.Gist.Series.Add(series9);
            this.Gist.Series.Add(series10);
            this.Gist.Series.Add(series11);
            this.Gist.Series.Add(series12);
            this.Gist.Size = new System.Drawing.Size(781, 100);
            this.Gist.TabIndex = 7;
            this.Gist.Text = "chart1";
            // 
            // MainChart
            // 
            chartArea4.AxisX.Maximum = 255D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisY.Maximum = 255D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.Name = "Func";
            this.MainChart.ChartAreas.Add(chartArea4);
            this.MainChart.Location = new System.Drawing.Point(12, 39);
            this.MainChart.Name = "MainChart";
            series13.ChartArea = "Func";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series13.Color = System.Drawing.Color.Gray;
            series13.Name = "Func";
            series14.ChartArea = "Func";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series14.Color = System.Drawing.Color.Red;
            series14.Name = "RedStream";
            series15.ChartArea = "Func";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series15.Color = System.Drawing.Color.Green;
            series15.Name = "GreenStream";
            series16.ChartArea = "Func";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series16.Color = System.Drawing.Color.Blue;
            series16.Name = "BlueStream";
            this.MainChart.Series.Add(series13);
            this.MainChart.Series.Add(series14);
            this.MainChart.Series.Add(series15);
            this.MainChart.Series.Add(series16);
            this.MainChart.Size = new System.Drawing.Size(386, 293);
            this.MainChart.TabIndex = 11;
            this.MainChart.Text = "MainFunc";
            this.MainChart.Click += new System.EventHandler(this.MainChart_Click);
            // 
            // Lx
            // 
            this.Lx.AutoSize = true;
            this.Lx.Location = new System.Drawing.Point(479, 20);
            this.Lx.Name = "Lx";
            this.Lx.Size = new System.Drawing.Size(18, 13);
            this.Lx.TabIndex = 12;
            this.Lx.Text = "x=";
            // 
            // Ly
            // 
            this.Ly.AutoSize = true;
            this.Ly.Location = new System.Drawing.Point(658, 23);
            this.Ly.Name = "Ly";
            this.Ly.Size = new System.Drawing.Size(18, 13);
            this.Ly.TabIndex = 13;
            this.Ly.Text = "y=";
            // 
            // Stream
            // 
            this.Stream.FormattingEnabled = true;
            this.Stream.Items.AddRange(new object[] {
            "Яркость",
            "Красный канал",
            "Зеленый канал",
            "Синий канал",
            "Серый канал"});
            this.Stream.Location = new System.Drawing.Point(12, 12);
            this.Stream.Name = "Stream";
            this.Stream.Size = new System.Drawing.Size(107, 21);
            this.Stream.TabIndex = 15;
            this.Stream.Text = "Яркость";
            this.Stream.SelectedIndexChanged += new System.EventHandler(this.Stream_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Stream);
            this.Controls.Add(this.Ly);
            this.Controls.Add(this.Lx);
            this.Controls.Add(this.MainChart);
            this.Controls.Add(this.Gist);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MainPic);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox MainPic;
        public System.Windows.Forms.DataVisualization.Charting.Chart Gist;
        public System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        public System.Windows.Forms.Label Lx;
        public System.Windows.Forms.Label Ly;
        public System.Windows.Forms.ComboBox Stream;
    }
}