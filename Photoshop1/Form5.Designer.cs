
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
            this.Matrix = new System.Windows.Forms.DataGridView();
            this.ReadyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // Matrix
            // 
            this.Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Matrix.Location = new System.Drawing.Point(17, 14);
            this.Matrix.Name = "Matrix";
            this.Matrix.Size = new System.Drawing.Size(711, 412);
            this.Matrix.TabIndex = 0;
            // 
            // ReadyButton
            // 
            this.ReadyButton.Location = new System.Drawing.Point(734, 14);
            this.ReadyButton.Name = "ReadyButton";
            this.ReadyButton.Size = new System.Drawing.Size(56, 38);
            this.ReadyButton.TabIndex = 1;
            this.ReadyButton.Text = "OK!";
            this.ReadyButton.UseVisualStyleBackColor = true;
            // 
            // CreateMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReadyButton);
            this.Controls.Add(this.Matrix);
            this.Name = "CreateMatrix";
            this.Text = "CreateMatrix";
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Matrix;
        private System.Windows.Forms.Button ReadyButton;
    }
}