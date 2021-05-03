
namespace Photoshop1
{
    partial class CreateMatrix
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
            this.ReadyButton = new System.Windows.Forms.Button();
            this.Matrix = new System.Windows.Forms.DataGridView();
            this.Gauss = new System.Windows.Forms.Button();
            this.Sigma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadyButton
            // 
            this.ReadyButton.Location = new System.Drawing.Point(734, 14);
            this.ReadyButton.Name = "ReadyButton";
            this.ReadyButton.Size = new System.Drawing.Size(56, 38);
            this.ReadyButton.TabIndex = 1;
            this.ReadyButton.Text = "OK!";
            this.ReadyButton.UseVisualStyleBackColor = true;
            this.ReadyButton.Click += new System.EventHandler(this.ReadyButton_Click);
            // 
            // Matrix
            // 
            this.Matrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Matrix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Matrix.ColumnHeadersVisible = false;
            this.Matrix.Location = new System.Drawing.Point(12, 12);
            this.Matrix.Name = "Matrix";
            this.Matrix.RowHeadersVisible = false;
            this.Matrix.Size = new System.Drawing.Size(716, 426);
            this.Matrix.TabIndex = 2;
            // 
            // Gauss
            // 
            this.Gauss.Location = new System.Drawing.Point(734, 401);
            this.Gauss.Name = "Gauss";
            this.Gauss.Size = new System.Drawing.Size(54, 37);
            this.Gauss.TabIndex = 3;
            this.Gauss.Text = "OK! Gauss";
            this.Gauss.UseVisualStyleBackColor = true;
            this.Gauss.Click += new System.EventHandler(this.Gauss_Click);
            // 
            // Sigma
            // 
            this.Sigma.Location = new System.Drawing.Point(734, 375);
            this.Sigma.Name = "Sigma";
            this.Sigma.Size = new System.Drawing.Size(56, 20);
            this.Sigma.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sum= ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // CreateMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sigma);
            this.Controls.Add(this.Gauss);
            this.Controls.Add(this.Matrix);
            this.Controls.Add(this.ReadyButton);
            this.Name = "CreateMatrix";
            this.Text = "CreateMatrix";
            this.Load += new System.EventHandler(this.CreateMatrix_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ReadyButton;
        public System.Windows.Forms.DataGridView Matrix;
        public System.Windows.Forms.Button Gauss;
        public System.Windows.Forms.TextBox Sigma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}