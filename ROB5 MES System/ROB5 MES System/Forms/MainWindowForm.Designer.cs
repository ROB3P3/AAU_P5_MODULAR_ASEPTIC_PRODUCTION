namespace ROB5_MES_System
{
    partial class MainWindowForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            dataToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            DateLabel = new Label();
            SystemStatusSubMenuItem = new ToolStripMenuItem();
            OrderManagementMenuItem = new ToolStripMenuItem();
            CurrentOrdersSubMenuItem = new ToolStripMenuItem();
            PlannedOrdersSubMenuItem = new ToolStripMenuItem();
            NewOrderSubMenuItem = new ToolStripMenuItem();
            FinishedOrdersSubMenuItem = new ToolStripMenuItem();
            OperationsSubMenuItem = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            ProductionControlMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dataToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1218, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            dataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            dataToolStripMenuItem.Size = new Size(55, 24);
            dataToolStripMenuItem.Text = "Data";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.MouseUp += exitToolStripMenuItem_MouseUp;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(183, 26);
            exportToolStripMenuItem.Text = "Export to CSV";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configurationToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(183, 26);
            configurationToolStripMenuItem.Text = "Configuration";
            // 
            // button1
            // 
            button1.Location = new Point(11, 233);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(11, 77);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(11, 123);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(11, 169);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 4;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // DateLabel
            // 
            DateLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(21, 784);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(39, 20);
            DateLabel.TabIndex = 6;
            DateLabel.Text = "date";
            // 
            // SystemStatusSubMenuItem
            // 
            SystemStatusSubMenuItem.Margin = new Padding(35, 0, 0, 0);
            SystemStatusSubMenuItem.Name = "SystemStatusSubMenuItem";
            SystemStatusSubMenuItem.Padding = new Padding(6, 2, 6, 2);
            SystemStatusSubMenuItem.Size = new Size(113, 23);
            SystemStatusSubMenuItem.Text = "System Status";
            SystemStatusSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            SystemStatusSubMenuItem.Visible = false;
            SystemStatusSubMenuItem.Click += SystemStatusSubMenuItem_Click;
            // 
            // OrderManagementMenuItem
            // 
            OrderManagementMenuItem.Font = new Font("Segoe UI", 10F);
            OrderManagementMenuItem.Margin = new Padding(0, 10, 0, 0);
            OrderManagementMenuItem.Name = "OrderManagementMenuItem";
            OrderManagementMenuItem.Padding = new Padding(6, 10, 6, 10);
            OrderManagementMenuItem.Size = new Size(148, 43);
            OrderManagementMenuItem.Text = "Order Management";
            OrderManagementMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            OrderManagementMenuItem.Click += OrderManagementMenuItem_Click;
            // 
            // CurrentOrdersSubMenuItem
            // 
            CurrentOrdersSubMenuItem.Margin = new Padding(35, 0, 0, 0);
            CurrentOrdersSubMenuItem.Name = "CurrentOrdersSubMenuItem";
            CurrentOrdersSubMenuItem.Padding = new Padding(6, 2, 6, 2);
            CurrentOrdersSubMenuItem.Size = new Size(113, 23);
            CurrentOrdersSubMenuItem.Text = "Production Queue";
            CurrentOrdersSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            CurrentOrdersSubMenuItem.Visible = false;
            CurrentOrdersSubMenuItem.Click += CurrentOrdersSubMenuItem_Click;
            // 
            // PlannedOrdersSubMenuItem
            // 
            PlannedOrdersSubMenuItem.Margin = new Padding(35, 0, 0, 0);
            PlannedOrdersSubMenuItem.Name = "PlannedOrdersSubMenuItem";
            PlannedOrdersSubMenuItem.Padding = new Padding(6, 2, 6, 2);
            PlannedOrdersSubMenuItem.Size = new Size(113, 23);
            PlannedOrdersSubMenuItem.Text = "Orders";
            PlannedOrdersSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            PlannedOrdersSubMenuItem.Visible = false;
            PlannedOrdersSubMenuItem.Click += PlannedOrdersSubMenuItem_Click;
            // 
            // NewOrderSubMenuItem
            // 
            NewOrderSubMenuItem.Margin = new Padding(35, 0, 0, 0);
            NewOrderSubMenuItem.Name = "NewOrderSubMenuItem";
            NewOrderSubMenuItem.Padding = new Padding(6, 2, 6, 2);
            NewOrderSubMenuItem.Size = new Size(113, 23);
            NewOrderSubMenuItem.Text = "New Order";
            NewOrderSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            NewOrderSubMenuItem.Visible = false;
            NewOrderSubMenuItem.Click += NewOrderSubMenuItem_Click;
            // 
            // FinishedOrdersSubMenuItem
            // 
            FinishedOrdersSubMenuItem.Margin = new Padding(35, 0, 0, 0);
            FinishedOrdersSubMenuItem.Name = "FinishedOrdersSubMenuItem";
            FinishedOrdersSubMenuItem.Padding = new Padding(6, 2, 6, 2);
            FinishedOrdersSubMenuItem.Size = new Size(113, 23);
            FinishedOrdersSubMenuItem.Text = "Finished Orders";
            FinishedOrdersSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            FinishedOrdersSubMenuItem.Visible = false;
            FinishedOrdersSubMenuItem.Click += FinishedOrdersSubMenuItem_Click;
            // 
            // OperationsSubMenuItem
            // 
            OperationsSubMenuItem.Margin = new Padding(35, 0, 0, 0);
            OperationsSubMenuItem.Name = "OperationsSubMenuItem";
            OperationsSubMenuItem.Padding = new Padding(6, 2, 6, 2);
            OperationsSubMenuItem.Size = new Size(113, 23);
            OperationsSubMenuItem.Text = "Operations";
            OperationsSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            OperationsSubMenuItem.Visible = false;
            OperationsSubMenuItem.Click += OperationsSubMenuItem_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.AutoSize = false;
            menuStrip2.Dock = DockStyle.Left;
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { ProductionControlMenuItem, SystemStatusSubMenuItem, OperationsSubMenuItem, OrderManagementMenuItem, CurrentOrdersSubMenuItem, PlannedOrdersSubMenuItem, NewOrderSubMenuItem, FinishedOrdersSubMenuItem });
            menuStrip2.Location = new Point(0, 30);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Padding = new Padding(5, 2, 0, 2);
            menuStrip2.Size = new Size(154, 541);
            menuStrip2.TabIndex = 5;
            menuStrip2.Text = "menuStrip2";
            // 
            // ProductionControlMenuItem
            // 
            ProductionControlMenuItem.Font = new Font("Segoe UI", 10F);
            ProductionControlMenuItem.Name = "ProductionControlMenuItem";
            ProductionControlMenuItem.Padding = new Padding(6, 10, 6, 10);
            ProductionControlMenuItem.Size = new Size(148, 43);
            ProductionControlMenuItem.Text = "Production Control";
            ProductionControlMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            ProductionControlMenuItem.Click += ProductionControlMenuItem_Click;
            // 
            // MainWindowForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 845);
            Controls.Add(DateLabel);
            Controls.Add(menuStrip2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainWindowForm";
            Text = "MES System";
            FormClosing += MainWindowForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dataToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label DateLabel;
        private ToolStripMenuItem SystemStatusSubMenuItem;
        private ToolStripMenuItem OrderManagementMenuItem;
        private ToolStripMenuItem CurrentOrdersSubMenuItem;
        private ToolStripMenuItem PlannedOrdersSubMenuItem;
        private ToolStripMenuItem NewOrderSubMenuItem;
        private ToolStripMenuItem FinishedOrdersSubMenuItem;
        private ToolStripMenuItem OperationsSubMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem ProductionControlMenuItem;
    }
}
