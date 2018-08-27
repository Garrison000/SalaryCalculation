namespace SalaryCalcWF
{
    partial class Lessons
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
            this.lblSort = new System.Windows.Forms.Label();
            this.dgvLesson = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLesson)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(54, 39);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(46, 24);
            this.lblSort.TabIndex = 0;
            this.lblSort.Text = "A类";
            // 
            // dgvLesson
            // 
            this.dgvLesson.AllowUserToOrderColumns = true;
            this.dgvLesson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLesson.Location = new System.Drawing.Point(58, 97);
            this.dgvLesson.Name = "dgvLesson";
            this.dgvLesson.RowTemplate.Height = 37;
            this.dgvLesson.Size = new System.Drawing.Size(624, 334);
            this.dgvLesson.TabIndex = 1;
            // 
            // Lessons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 504);
            this.Controls.Add(this.dgvLesson);
            this.Controls.Add(this.lblSort);
            this.Name = "Lessons";
            this.Text = "Lessons";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLesson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.DataGridView dgvLesson;
    }
}