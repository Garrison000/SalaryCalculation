namespace SalaryCalcWF
{
    partial class ClassLesson
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("一年级", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("二年级");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("三年级");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("四年级");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("五年级");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("六年级");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("初一");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("初二");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("初三");
            this.tvwClass = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlpLesson = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvwClass
            // 
            this.tvwClass.Location = new System.Drawing.Point(27, 53);
            this.tvwClass.Name = "tvwClass";
            treeNode1.Name = "节点1";
            treeNode1.Text = "节点1";
            treeNode2.Name = "节点0";
            treeNode2.Text = "一年级";
            treeNode3.Name = "节点2";
            treeNode3.Text = "二年级";
            treeNode4.Name = "节点3";
            treeNode4.Text = "三年级";
            treeNode5.Name = "节点4";
            treeNode5.Text = "四年级";
            treeNode6.Name = "节点5";
            treeNode6.Text = "五年级";
            treeNode7.Name = "节点6";
            treeNode7.Text = "六年级";
            treeNode8.Name = "节点7";
            treeNode8.Text = "初一";
            treeNode9.Name = "节点8";
            treeNode9.Text = "初二";
            treeNode10.Name = "节点9";
            treeNode10.Text = "初三";
            this.tvwClass.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.tvwClass.Size = new System.Drawing.Size(148, 416);
            this.tvwClass.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvwClass);
            this.groupBox1.Location = new System.Drawing.Point(35, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 528);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择班级";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tlpLesson);
            this.groupBox2.Location = new System.Drawing.Point(270, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1017, 528);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "课表";
            // 
            // tlpLesson
            // 
            this.tlpLesson.ColumnCount = 6;
            this.tlpLesson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpLesson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpLesson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpLesson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpLesson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpLesson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpLesson.Location = new System.Drawing.Point(21, 34);
            this.tlpLesson.Name = "tlpLesson";
            this.tlpLesson.RowCount = 12;
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpLesson.Size = new System.Drawing.Size(959, 475);
            this.tlpLesson.TabIndex = 5;
            // 
            // ClassLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 635);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClassLesson";
            this.Text = "ClassLesson";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvwClass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tlpLesson;
    }
}