
namespace Photoshop1
{
    partial class Form4
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
            this.MidA = new System.Windows.Forms.TextBox();
            this.LinA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.FilterPic = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeMethod = new System.Windows.Forms.Label();
            this.TimeOperation = new System.Windows.Forms.Label();
            this.LinButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPic)).BeginInit();
            this.SuspendLayout();
            // 
            // MidA
            // 
            this.MidA.Location = new System.Drawing.Point(653, 36);
            this.MidA.Name = "MidA";
            this.MidA.Size = new System.Drawing.Size(128, 20);
            this.MidA.TabIndex = 0;
            // 
            // LinA
            // 
            this.LinA.Location = new System.Drawing.Point(653, 118);
            this.LinA.Name = "LinA";
            this.LinA.Size = new System.Drawing.Size(127, 20);
            this.LinA.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Медианная фильтрация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Линейная фильтрация";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(653, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 24);
            this.button2.TabIndex = 7;
            this.button2.Text = "Создать матрицу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(659, 390);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Return to MainForm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(659, 354);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 25);
            this.button4.TabIndex = 9;
            this.button4.Text = "GoToBinar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FilterPic
            // 
            this.FilterPic.Location = new System.Drawing.Point(12, 20);
            this.FilterPic.Name = "FilterPic";
            this.FilterPic.Size = new System.Drawing.Size(636, 392);
            this.FilterPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FilterPic.TabIndex = 10;
            this.FilterPic.TabStop = false;
            this.FilterPic.Click += new System.EventHandler(this.FilterPic_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Время метода";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(655, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Время операции";
            // 
            // TimeMethod
            // 
            this.TimeMethod.AutoSize = true;
            this.TimeMethod.Location = new System.Drawing.Point(655, 241);
            this.TimeMethod.Name = "TimeMethod";
            this.TimeMethod.Size = new System.Drawing.Size(13, 13);
            this.TimeMethod.TabIndex = 13;
            this.TimeMethod.Text = "0";
            // 
            // TimeOperation
            // 
            this.TimeOperation.AutoSize = true;
            this.TimeOperation.Location = new System.Drawing.Point(655, 302);
            this.TimeOperation.Name = "TimeOperation";
            this.TimeOperation.Size = new System.Drawing.Size(13, 13);
            this.TimeOperation.TabIndex = 14;
            this.TimeOperation.Text = "0";
            // 
            // LinButton
            // 
            this.LinButton.Location = new System.Drawing.Point(653, 177);
            this.LinButton.Name = "LinButton";
            this.LinButton.Size = new System.Drawing.Size(128, 23);
            this.LinButton.TabIndex = 15;
            this.LinButton.Text = "ЛОВИИ ЯДРО!";
            this.LinButton.UseVisualStyleBackColor = true;
            this.LinButton.Click += new System.EventHandler(this.LinButton_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LinButton);
            this.Controls.Add(this.TimeOperation);
            this.Controls.Add(this.TimeMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FilterPic);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LinA);
            this.Controls.Add(this.MidA);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FilterPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MidA;
        private System.Windows.Forms.TextBox LinA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.PictureBox FilterPic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TimeMethod;
        private System.Windows.Forms.Label TimeOperation;
        private System.Windows.Forms.Button LinButton;
    }
}