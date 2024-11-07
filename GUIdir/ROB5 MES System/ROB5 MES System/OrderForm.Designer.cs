namespace ROB5_MES_System
{
    partial class OrderForm
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
            TreeNode treeNode1 = new TreeNode("Process: Filling | State: DONE | Start: 00/00/00 00:00:00 | End: 00/00/00 00:00:00 ");
            TreeNode treeNode2 = new TreeNode("Process: Stoppering | State: DONE | Start: 00/00/00 00:00:00 | End: 00/00/00 00:00:00 ");
            TreeNode treeNode3 = new TreeNode("CID: 1 | Amount: 5 | State: DONE | Start: 00/00/00 00:00:00 | End: 00/00/00 00:00:00", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Process: Filling | State: DONE | Start: 00/00/00 00:00:00 | End: 00/00/00 00:00:00");
            TreeNode treeNode5 = new TreeNode("Process: Stoppering | State: BUSY | Start: 00/00/00 00:00:00");
            TreeNode treeNode6 = new TreeNode("CID: 2 | Amount: 5 | State: BUSY | Start: 00/00/00 00:00:00", new TreeNode[] { treeNode4, treeNode5 });
            TreeNode treeNode7 = new TreeNode("Process: Filling | State: PEND");
            TreeNode treeNode8 = new TreeNode("Process: Stoppering | State: PEND");
            TreeNode treeNode9 = new TreeNode("CID: 3 | Amount: 3 | State: PEND", new TreeNode[] { treeNode7, treeNode8 });
            groupBox1 = new GroupBox();
            ContainerTypeDispLabel = new Label();
            ContainerTypeLabel = new Label();
            ContainerAmountDispLabel = new Label();
            ContainerAmountLabel = new Label();
            PlannedEndTimeDispLabel = new Label();
            PlannedEndTimeLabel = new Label();
            PlannedStartTimeLabel = new Label();
            PlannedStartTimeDispLabel = new Label();
            OrderNumberDispLabel = new Label();
            OrderNumberLabel = new Label();
            groupBox2 = new GroupBox();
            treeView1 = new TreeView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ContainerTypeDispLabel);
            groupBox1.Controls.Add(ContainerTypeLabel);
            groupBox1.Controls.Add(ContainerAmountDispLabel);
            groupBox1.Controls.Add(ContainerAmountLabel);
            groupBox1.Controls.Add(PlannedEndTimeDispLabel);
            groupBox1.Controls.Add(PlannedEndTimeLabel);
            groupBox1.Controls.Add(PlannedStartTimeLabel);
            groupBox1.Controls.Add(PlannedStartTimeDispLabel);
            groupBox1.Controls.Add(OrderNumberDispLabel);
            groupBox1.Controls.Add(OrderNumberLabel);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(336, 341);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order Info";
            // 
            // ContainerTypeDispLabel
            // 
            ContainerTypeDispLabel.AutoSize = true;
            ContainerTypeDispLabel.BackColor = SystemColors.Window;
            ContainerTypeDispLabel.BorderStyle = BorderStyle.Fixed3D;
            ContainerTypeDispLabel.Location = new Point(165, 155);
            ContainerTypeDispLabel.MinimumSize = new Size(150, 25);
            ContainerTypeDispLabel.Name = "ContainerTypeDispLabel";
            ContainerTypeDispLabel.Size = new Size(150, 25);
            ContainerTypeDispLabel.TabIndex = 9;
            ContainerTypeDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContainerTypeLabel
            // 
            ContainerTypeLabel.AutoSize = true;
            ContainerTypeLabel.Location = new Point(6, 160);
            ContainerTypeLabel.Name = "ContainerTypeLabel";
            ContainerTypeLabel.Size = new Size(108, 20);
            ContainerTypeLabel.TabIndex = 8;
            ContainerTypeLabel.Text = "Container Type";
            // 
            // ContainerAmountDispLabel
            // 
            ContainerAmountDispLabel.AutoSize = true;
            ContainerAmountDispLabel.BackColor = SystemColors.Window;
            ContainerAmountDispLabel.BorderStyle = BorderStyle.Fixed3D;
            ContainerAmountDispLabel.Location = new Point(165, 204);
            ContainerAmountDispLabel.MinimumSize = new Size(150, 25);
            ContainerAmountDispLabel.Name = "ContainerAmountDispLabel";
            ContainerAmountDispLabel.Size = new Size(150, 25);
            ContainerAmountDispLabel.TabIndex = 7;
            ContainerAmountDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContainerAmountLabel
            // 
            ContainerAmountLabel.AutoSize = true;
            ContainerAmountLabel.Location = new Point(6, 204);
            ContainerAmountLabel.Name = "ContainerAmountLabel";
            ContainerAmountLabel.Size = new Size(130, 20);
            ContainerAmountLabel.TabIndex = 6;
            ContainerAmountLabel.Text = "Container Amount";
            // 
            // PlannedEndTimeDispLabel
            // 
            PlannedEndTimeDispLabel.AutoSize = true;
            PlannedEndTimeDispLabel.BackColor = SystemColors.Window;
            PlannedEndTimeDispLabel.BorderStyle = BorderStyle.Fixed3D;
            PlannedEndTimeDispLabel.Location = new Point(165, 106);
            PlannedEndTimeDispLabel.MinimumSize = new Size(150, 25);
            PlannedEndTimeDispLabel.Name = "PlannedEndTimeDispLabel";
            PlannedEndTimeDispLabel.Size = new Size(150, 25);
            PlannedEndTimeDispLabel.TabIndex = 5;
            PlannedEndTimeDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PlannedEndTimeLabel
            // 
            PlannedEndTimeLabel.AutoSize = true;
            PlannedEndTimeLabel.Location = new Point(6, 111);
            PlannedEndTimeLabel.Name = "PlannedEndTimeLabel";
            PlannedEndTimeLabel.Size = new Size(128, 20);
            PlannedEndTimeLabel.TabIndex = 4;
            PlannedEndTimeLabel.Text = "Planned End Time";
            // 
            // PlannedStartTimeLabel
            // 
            PlannedStartTimeLabel.AutoSize = true;
            PlannedStartTimeLabel.Location = new Point(6, 64);
            PlannedStartTimeLabel.Name = "PlannedStartTimeLabel";
            PlannedStartTimeLabel.Size = new Size(134, 20);
            PlannedStartTimeLabel.TabIndex = 3;
            PlannedStartTimeLabel.Text = "Planned Start Time";
            // 
            // PlannedStartTimeDispLabel
            // 
            PlannedStartTimeDispLabel.AutoSize = true;
            PlannedStartTimeDispLabel.BackColor = SystemColors.Window;
            PlannedStartTimeDispLabel.BorderStyle = BorderStyle.Fixed3D;
            PlannedStartTimeDispLabel.Location = new Point(165, 63);
            PlannedStartTimeDispLabel.MinimumSize = new Size(150, 25);
            PlannedStartTimeDispLabel.Name = "PlannedStartTimeDispLabel";
            PlannedStartTimeDispLabel.Size = new Size(150, 25);
            PlannedStartTimeDispLabel.TabIndex = 2;
            PlannedStartTimeDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderNumberDispLabel
            // 
            OrderNumberDispLabel.AutoSize = true;
            OrderNumberDispLabel.BackColor = SystemColors.Window;
            OrderNumberDispLabel.BorderStyle = BorderStyle.Fixed3D;
            OrderNumberDispLabel.Location = new Point(165, 23);
            OrderNumberDispLabel.MinimumSize = new Size(150, 25);
            OrderNumberDispLabel.Name = "OrderNumberDispLabel";
            OrderNumberDispLabel.Size = new Size(150, 25);
            OrderNumberDispLabel.TabIndex = 1;
            OrderNumberDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderNumberLabel
            // 
            OrderNumberLabel.AutoSize = true;
            OrderNumberLabel.Location = new Point(6, 23);
            OrderNumberLabel.Name = "OrderNumberLabel";
            OrderNumberLabel.Size = new Size(108, 20);
            OrderNumberLabel.TabIndex = 0;
            OrderNumberLabel.Text = "Order Number:\r\n";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(treeView1);
            groupBox2.Location = new Point(12, 369);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(655, 262);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Carrier Queue";
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(6, 26);
            treeView1.Name = "treeView1";
            treeNode1.BackColor = Color.FromArgb(128, 128, 255);
            treeNode1.Name = "Node1";
            treeNode1.Text = "Process: Filling | State: DONE | Start: 00/00/00 00:00:00 | End: 00/00/00 00:00:00 ";
            treeNode2.BackColor = Color.FromArgb(128, 128, 255);
            treeNode2.Name = "Node2";
            treeNode2.Text = "Process: Stoppering | State: DONE | Start: 00/00/00 00:00:00 | End: 00/00/00 00:00:00 ";
            treeNode3.BackColor = Color.FromArgb(128, 128, 255);
            treeNode3.Name = "Node0";
            treeNode3.Text = "CID: 1 | Amount: 5 | State: DONE | Start: 00/00/00 00:00:00 | End: 00/00/00 00:00:00";
            treeNode4.BackColor = Color.FromArgb(128, 128, 255);
            treeNode4.Name = "Node4";
            treeNode4.Text = "Process: Filling | State: DONE | Start: 00/00/00 00:00:00 | End: 00/00/00 00:00:00";
            treeNode5.BackColor = Color.FromArgb(255, 255, 128);
            treeNode5.Name = "Node5";
            treeNode5.Text = "Process: Stoppering | State: BUSY | Start: 00/00/00 00:00:00";
            treeNode6.BackColor = Color.FromArgb(255, 255, 128);
            treeNode6.Name = "Node3";
            treeNode6.Text = "CID: 2 | Amount: 5 | State: BUSY | Start: 00/00/00 00:00:00";
            treeNode7.BackColor = Color.White;
            treeNode7.Name = "Node7";
            treeNode7.Text = "Process: Filling | State: PEND";
            treeNode8.BackColor = Color.White;
            treeNode8.Name = "Node8";
            treeNode8.Text = "Process: Stoppering | State: PEND";
            treeNode9.BackColor = Color.White;
            treeNode9.Name = "Node6";
            treeNode9.Text = "CID: 3 | Amount: 3 | State: PEND";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode6, treeNode9 });
            treeView1.Size = new Size(643, 228);
            treeView1.TabIndex = 0;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 636);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "OrderForm";
            Text = "OrderForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label OrderNumberLabel;
        private Label OrderNumberDispLabel;
        private Label PlannedStartTimeLabel;
        private Label PlannedStartTimeDispLabel;
        private Label PlannedEndTimeDispLabel;
        private Label PlannedEndTimeLabel;
        private Label ContainerTypeDispLabel;
        private Label ContainerTypeLabel;
        private Label ContainerAmountDispLabel;
        private Label ContainerAmountLabel;
        private GroupBox groupBox2;
        private TreeView treeView1;
    }
}