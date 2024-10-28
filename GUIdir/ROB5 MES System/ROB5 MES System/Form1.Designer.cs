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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            dataToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            whaToolStripMenuItem = new ToolStripMenuItem();
            windowsToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            menuStrip2 = new MenuStrip();
            ProductionControlMenuItem = new ToolStripMenuItem();
            ResourcesSubMenuItem = new ToolStripMenuItem();
            OrderManagementMenuItem = new ToolStripMenuItem();
            CurrentOrdersSubMenuItem = new ToolStripMenuItem();
            PlannedOrdersSubMenuItem = new ToolStripMenuItem();
            NewOrderSubMenuItem = new ToolStripMenuItem();
            FinishedOrdersSubMenuItem = new ToolStripMenuItem();
            QualityManagementMenuItem = new ToolStripMenuItem();
            EfficiencyReportSubMenuItem = new ToolStripMenuItem();
            OEEReportSubMenuItem = new ToolStripMenuItem();
            MasterDataMenuItem = new ToolStripMenuItem();
            PartsSubMenuItem = new ToolStripMenuItem();
            WorkPlansSubMenuItem = new ToolStripMenuItem();
            ResourcesSubMenuItem2 = new ToolStripMenuItem();
            OperationsSubMenuItem = new ToolStripMenuItem();
            DateLabel = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dataToolStripMenuItem, toolsToolStripMenuItem, windowsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1002, 28);
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
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { whaToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // whaToolStripMenuItem
            // 
            whaToolStripMenuItem.Name = "whaToolStripMenuItem";
            whaToolStripMenuItem.Size = new Size(119, 26);
            whaToolStripMenuItem.Text = "wha";
            // 
            // windowsToolStripMenuItem
            // 
            windowsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            windowsToolStripMenuItem.Size = new Size(84, 24);
            windowsToolStripMenuItem.Text = "Windows";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(122, 26);
            saveToolStripMenuItem.Text = "save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(122, 26);
            loadToolStripMenuItem.Text = "load";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // button1
            // 
            button1.Location = new Point(12, 233);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 77);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(12, 123);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 169);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 4;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // menuStrip2
            // 
            menuStrip2.AutoSize = false;
            menuStrip2.Dock = DockStyle.Left;
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { ProductionControlMenuItem, ResourcesSubMenuItem, OrderManagementMenuItem, CurrentOrdersSubMenuItem, PlannedOrdersSubMenuItem, NewOrderSubMenuItem, FinishedOrdersSubMenuItem, QualityManagementMenuItem, EfficiencyReportSubMenuItem, OEEReportSubMenuItem, MasterDataMenuItem, PartsSubMenuItem, WorkPlansSubMenuItem, ResourcesSubMenuItem2, OperationsSubMenuItem });
            menuStrip2.Location = new Point(0, 28);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(180, 625);
            menuStrip2.TabIndex = 5;
            menuStrip2.Text = "menuStrip2";
            // 
            // ProductionControlMenuItem
            // 
            ProductionControlMenuItem.AutoSize = false;
            ProductionControlMenuItem.Name = "ProductionControlMenuItem";
            ProductionControlMenuItem.Size = new Size(165, 60);
            ProductionControlMenuItem.Text = "Production Control";
            ProductionControlMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            ProductionControlMenuItem.TextDirection = ToolStripTextDirection.Horizontal;
            ProductionControlMenuItem.Click += ProductionControlMenuItem_Click;
            ProductionControlMenuItem.MouseUp += ProductionControlMenuItem_MouseUp;
            // 
            // ResourcesSubMenuItem
            // 
            ResourcesSubMenuItem.AutoSize = false;
            ResourcesSubMenuItem.Name = "ResourcesSubMenuItem";
            ResourcesSubMenuItem.Size = new Size(130, 30);
            ResourcesSubMenuItem.Text = "Resources";
            ResourcesSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            ResourcesSubMenuItem.Visible = false;
            // 
            // OrderManagementMenuItem
            // 
            OrderManagementMenuItem.AutoSize = false;
            OrderManagementMenuItem.Name = "OrderManagementMenuItem";
            OrderManagementMenuItem.Size = new Size(165, 60);
            OrderManagementMenuItem.Text = "Order Management";
            OrderManagementMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            OrderManagementMenuItem.MouseUp += OrderManagementMenuItem_MouseUp;
            // 
            // CurrentOrdersSubMenuItem
            // 
            CurrentOrdersSubMenuItem.AutoSize = false;
            CurrentOrdersSubMenuItem.Name = "CurrentOrdersSubMenuItem";
            CurrentOrdersSubMenuItem.Size = new Size(130, 30);
            CurrentOrdersSubMenuItem.Text = "Current Orders";
            CurrentOrdersSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            CurrentOrdersSubMenuItem.Visible = false;
            CurrentOrdersSubMenuItem.MouseUp += CurrentOrdersSubMenuItem_MouseUp;
            // 
            // PlannedOrdersSubMenuItem
            // 
            PlannedOrdersSubMenuItem.AutoSize = false;
            PlannedOrdersSubMenuItem.Name = "PlannedOrdersSubMenuItem";
            PlannedOrdersSubMenuItem.Size = new Size(130, 30);
            PlannedOrdersSubMenuItem.Text = "Planned Orders";
            PlannedOrdersSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            PlannedOrdersSubMenuItem.Visible = false;
            // 
            // NewOrderSubMenuItem
            // 
            NewOrderSubMenuItem.AutoSize = false;
            NewOrderSubMenuItem.Name = "NewOrderSubMenuItem";
            NewOrderSubMenuItem.Size = new Size(130, 30);
            NewOrderSubMenuItem.Text = "New Order";
            NewOrderSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            NewOrderSubMenuItem.Visible = false;
            NewOrderSubMenuItem.MouseUp += NewOrderSubMenuItem_MouseUp;
            // 
            // FinishedOrdersSubMenuItem
            // 
            FinishedOrdersSubMenuItem.AutoSize = false;
            FinishedOrdersSubMenuItem.Name = "FinishedOrdersSubMenuItem";
            FinishedOrdersSubMenuItem.Size = new Size(130, 30);
            FinishedOrdersSubMenuItem.Text = "Finished Orders";
            FinishedOrdersSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            FinishedOrdersSubMenuItem.Visible = false;
            // 
            // QualityManagementMenuItem
            // 
            QualityManagementMenuItem.AutoSize = false;
            QualityManagementMenuItem.Name = "QualityManagementMenuItem";
            QualityManagementMenuItem.Size = new Size(165, 60);
            QualityManagementMenuItem.Text = "Quality Management";
            QualityManagementMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            QualityManagementMenuItem.MouseUp += QualityManagementMenuItem_MouseUp;
            // 
            // EfficiencyReportSubMenuItem
            // 
            EfficiencyReportSubMenuItem.AutoSize = false;
            EfficiencyReportSubMenuItem.Name = "EfficiencyReportSubMenuItem";
            EfficiencyReportSubMenuItem.Size = new Size(130, 30);
            EfficiencyReportSubMenuItem.Text = "Efficiency Report";
            EfficiencyReportSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            EfficiencyReportSubMenuItem.Visible = false;
            // 
            // OEEReportSubMenuItem
            // 
            OEEReportSubMenuItem.AutoSize = false;
            OEEReportSubMenuItem.Name = "OEEReportSubMenuItem";
            OEEReportSubMenuItem.Size = new Size(130, 30);
            OEEReportSubMenuItem.Text = "OEE Report";
            OEEReportSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            OEEReportSubMenuItem.Visible = false;
            // 
            // MasterDataMenuItem
            // 
            MasterDataMenuItem.AutoSize = false;
            MasterDataMenuItem.Name = "MasterDataMenuItem";
            MasterDataMenuItem.Size = new Size(165, 60);
            MasterDataMenuItem.Text = "Master Data";
            MasterDataMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            MasterDataMenuItem.MouseUp += MasterDataMenuItem_MouseUp;
            // 
            // PartsSubMenuItem
            // 
            PartsSubMenuItem.AutoSize = false;
            PartsSubMenuItem.Name = "PartsSubMenuItem";
            PartsSubMenuItem.Size = new Size(130, 30);
            PartsSubMenuItem.Text = "Parts";
            PartsSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            PartsSubMenuItem.Visible = false;
            // 
            // WorkPlansSubMenuItem
            // 
            WorkPlansSubMenuItem.AutoSize = false;
            WorkPlansSubMenuItem.Name = "WorkPlansSubMenuItem";
            WorkPlansSubMenuItem.Size = new Size(130, 30);
            WorkPlansSubMenuItem.Text = "Work Plans";
            WorkPlansSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            WorkPlansSubMenuItem.Visible = false;
            // 
            // ResourcesSubMenuItem2
            // 
            ResourcesSubMenuItem2.AutoSize = false;
            ResourcesSubMenuItem2.Name = "ResourcesSubMenuItem2";
            ResourcesSubMenuItem2.Size = new Size(130, 30);
            ResourcesSubMenuItem2.Text = "Resources";
            ResourcesSubMenuItem2.TextAlign = ContentAlignment.MiddleLeft;
            ResourcesSubMenuItem2.Visible = false;
            // 
            // OperationsSubMenuItem
            // 
            OperationsSubMenuItem.AutoSize = false;
            OperationsSubMenuItem.Name = "OperationsSubMenuItem";
            OperationsSubMenuItem.Size = new Size(130, 30);
            OperationsSubMenuItem.Text = "Operations";
            OperationsSubMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            OperationsSubMenuItem.Visible = false;
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(912, 44);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(39, 20);
            DateLabel.TabIndex = 6;
            DateLabel.Text = "date";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // MainWindowForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 653);
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
        private ToolStripMenuItem whaToolStripMenuItem;
        private ToolStripMenuItem windowsToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem ProductionControlMenuItem;
        private ToolStripMenuItem OrderManagementMenuItem;
        private ToolStripMenuItem QualityManagementMenuItem;
        private ToolStripMenuItem MasterDataMenuItem;
        private ToolStripMenuItem ResourcesSubMenuItem;
        private ToolStripMenuItem CurrentOrdersSubMenuItem;
        private ToolStripMenuItem PlannedOrdersSubMenuItem;
        private ToolStripMenuItem NewOrderSubMenuItem;
        private ToolStripMenuItem FinishedOrdersSubMenuItem;
        private ToolStripMenuItem EfficiencyReportSubMenuItem;
        private ToolStripMenuItem OEEReportSubMenuItem;
        private ToolStripMenuItem PartsSubMenuItem;
        private ToolStripMenuItem WorkPlansSubMenuItem;
        private ToolStripMenuItem ResourcesSubMenuItem2;
        private ToolStripMenuItem OperationsSubMenuItem;
        private Label DateLabel;
        private ContextMenuStrip contextMenuStrip1;
    }
}
