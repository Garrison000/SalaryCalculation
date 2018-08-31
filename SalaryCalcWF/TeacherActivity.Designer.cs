namespace SalaryCalcWF
{
    partial class TeacherActivity
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddOcc = new System.Windows.Forms.Button();
            this.btnAddMon = new System.Windows.Forms.Button();
            this.tbxType = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbxValue = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lstTeacherActivity = new System.Windows.Forms.ListBox();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnDelete);
            this.groupBox8.Controls.Add(this.btnAdd);
            this.groupBox8.Controls.Add(this.btnAddOcc);
            this.groupBox8.Controls.Add(this.btnAddMon);
            this.groupBox8.Controls.Add(this.tbxType);
            this.groupBox8.Controls.Add(this.label24);
            this.groupBox8.Controls.Add(this.tbxValue);
            this.groupBox8.Controls.Add(this.label23);
            this.groupBox8.Controls.Add(this.tbxName);
            this.groupBox8.Controls.Add(this.label22);
            this.groupBox8.Location = new System.Drawing.Point(466, 47);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(578, 677);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "活动信息";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(163, 267);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(242, 50);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "将该教师移除活动";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(163, 519);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(242, 50);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "添加活动...";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnAddOcc
            // 
            this.btnAddOcc.Location = new System.Drawing.Point(163, 435);
            this.btnAddOcc.Name = "btnAddOcc";
            this.btnAddOcc.Size = new System.Drawing.Size(242, 50);
            this.btnAddOcc.TabIndex = 12;
            this.btnAddOcc.Text = "添加任职";
            this.btnAddOcc.UseVisualStyleBackColor = true;
            // 
            // btnAddMon
            // 
            this.btnAddMon.Location = new System.Drawing.Point(163, 349);
            this.btnAddMon.Name = "btnAddMon";
            this.btnAddMon.Size = new System.Drawing.Size(242, 50);
            this.btnAddMon.TabIndex = 11;
            this.btnAddMon.Text = "添加监考";
            this.btnAddMon.UseVisualStyleBackColor = true;
            this.btnAddMon.Click += new System.EventHandler(this.btnAddMon_Click);
            // 
            // tbxType
            // 
            this.tbxType.Location = new System.Drawing.Point(185, 168);
            this.tbxType.Name = "tbxType";
            this.tbxType.ReadOnly = true;
            this.tbxType.Size = new System.Drawing.Size(301, 35);
            this.tbxType.TabIndex = 5;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(60, 171);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 24);
            this.label24.TabIndex = 4;
            this.label24.Text = "类型";
            // 
            // tbxValue
            // 
            this.tbxValue.Location = new System.Drawing.Point(185, 116);
            this.tbxValue.Name = "tbxValue";
            this.tbxValue.ReadOnly = true;
            this.tbxValue.Size = new System.Drawing.Size(301, 35);
            this.tbxValue.TabIndex = 3;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(60, 119);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 24);
            this.label23.TabIndex = 2;
            this.label23.Text = "课时";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(185, 61);
            this.tbxName.Name = "tbxName";
            this.tbxName.ReadOnly = true;
            this.tbxName.Size = new System.Drawing.Size(301, 35);
            this.tbxName.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(60, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 24);
            this.label22.TabIndex = 0;
            this.label22.Text = "名称";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lstTeacherActivity);
            this.groupBox7.Location = new System.Drawing.Point(44, 47);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(373, 677);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "教师的活动列表";
            // 
            // lstTeacherActivity
            // 
            this.lstTeacherActivity.FormattingEnabled = true;
            this.lstTeacherActivity.ItemHeight = 24;
            this.lstTeacherActivity.Location = new System.Drawing.Point(40, 64);
            this.lstTeacherActivity.Name = "lstTeacherActivity";
            this.lstTeacherActivity.Size = new System.Drawing.Size(270, 556);
            this.lstTeacherActivity.TabIndex = 5;
            this.lstTeacherActivity.SelectedValueChanged += new System.EventHandler(this.lstTeacherActivity_SelectedValueChanged);
            // 
            // TeacherActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 771);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Name = "TeacherActivity";
            this.Text = "TeacherActivity";
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddOcc;
        private System.Windows.Forms.Button btnAddMon;
        private System.Windows.Forms.TextBox tbxType;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbxValue;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox lstTeacherActivity;
    }
}