namespace SalaryCalcWF
{
    partial class AddActivity
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
            this.cbxActType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxActName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnActTime = new System.Windows.Forms.Button();
            this.chbxActOverride = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtActAuto = new System.Windows.Forms.RadioButton();
            this.rbtActMannual = new System.Windows.Forms.RadioButton();
            this.lblActMannual = new System.Windows.Forms.Label();
            this.lblActAuto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnActTeachers = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxActType
            // 
            this.cbxActType.FormattingEnabled = true;
            this.cbxActType.Location = new System.Drawing.Point(280, 79);
            this.cbxActType.Name = "cbxActType";
            this.cbxActType.Size = new System.Drawing.Size(215, 32);
            this.cbxActType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "活动类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "活动名称";
            // 
            // tbxActName
            // 
            this.tbxActName.Location = new System.Drawing.Point(280, 157);
            this.tbxActName.Name = "tbxActName";
            this.tbxActName.Size = new System.Drawing.Size(215, 35);
            this.tbxActName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "活动时间";
            // 
            // btnActTime
            // 
            this.btnActTime.Location = new System.Drawing.Point(280, 230);
            this.btnActTime.Name = "btnActTime";
            this.btnActTime.Size = new System.Drawing.Size(215, 39);
            this.btnActTime.TabIndex = 5;
            this.btnActTime.Text = "...";
            this.btnActTime.UseVisualStyleBackColor = true;
            // 
            // chbxActOverride
            // 
            this.chbxActOverride.AutoSize = true;
            this.chbxActOverride.Checked = true;
            this.chbxActOverride.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxActOverride.Location = new System.Drawing.Point(280, 298);
            this.chbxActOverride.Name = "chbxActOverride";
            this.chbxActOverride.Size = new System.Drawing.Size(210, 28);
            this.chbxActOverride.TabIndex = 6;
            this.chbxActOverride.Text = "覆盖同时段课程";
            this.chbxActOverride.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "活动课时";
            // 
            // rbtActAuto
            // 
            this.rbtActAuto.AutoSize = true;
            this.rbtActAuto.Location = new System.Drawing.Point(280, 428);
            this.rbtActAuto.Name = "rbtActAuto";
            this.rbtActAuto.Size = new System.Drawing.Size(137, 28);
            this.rbtActAuto.TabIndex = 8;
            this.rbtActAuto.TabStop = true;
            this.rbtActAuto.Text = "自动计算";
            this.rbtActAuto.UseVisualStyleBackColor = true;
            // 
            // rbtActMannual
            // 
            this.rbtActMannual.AutoSize = true;
            this.rbtActMannual.Location = new System.Drawing.Point(280, 507);
            this.rbtActMannual.Name = "rbtActMannual";
            this.rbtActMannual.Size = new System.Drawing.Size(137, 28);
            this.rbtActMannual.TabIndex = 9;
            this.rbtActMannual.TabStop = true;
            this.rbtActMannual.Text = "手动输入";
            this.rbtActMannual.UseVisualStyleBackColor = true;
            // 
            // lblActMannual
            // 
            this.lblActMannual.AutoSize = true;
            this.lblActMannual.Location = new System.Drawing.Point(276, 547);
            this.lblActMannual.Name = "lblActMannual";
            this.lblActMannual.Size = new System.Drawing.Size(82, 24);
            this.lblActMannual.TabIndex = 10;
            this.lblActMannual.Text = "label5";
            // 
            // lblActAuto
            // 
            this.lblActAuto.AutoSize = true;
            this.lblActAuto.Location = new System.Drawing.Point(276, 470);
            this.lblActAuto.Name = "lblActAuto";
            this.lblActAuto.Size = new System.Drawing.Size(82, 24);
            this.lblActAuto.TabIndex = 11;
            this.lblActAuto.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "活动教师";
            // 
            // btnActTeachers
            // 
            this.btnActTeachers.Location = new System.Drawing.Point(280, 354);
            this.btnActTeachers.Name = "btnActTeachers";
            this.btnActTeachers.Size = new System.Drawing.Size(215, 39);
            this.btnActTeachers.TabIndex = 13;
            this.btnActTeachers.Text = "...";
            this.btnActTeachers.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(373, 610);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(185, 55);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(106, 610);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(185, 55);
            this.btnConfirm.TabIndex = 18;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // AddActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 766);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnActTeachers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblActAuto);
            this.Controls.Add(this.lblActMannual);
            this.Controls.Add(this.rbtActMannual);
            this.Controls.Add(this.rbtActAuto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbxActOverride);
            this.Controls.Add(this.btnActTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxActName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxActType);
            this.Name = "AddActivity";
            this.Text = "添加活动";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxActType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxActName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnActTime;
        private System.Windows.Forms.CheckBox chbxActOverride;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtActAuto;
        private System.Windows.Forms.RadioButton rbtActMannual;
        private System.Windows.Forms.Label lblActMannual;
        private System.Windows.Forms.Label lblActAuto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnActTeachers;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
    }
}