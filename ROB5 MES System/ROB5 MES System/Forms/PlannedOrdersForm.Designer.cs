namespace ROB5_MES_System
{
    partial class PlannedOrdersForm
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
            components = new System.ComponentModel.Container();
            plannedOrdersDataGrid = new DataGridView();
            DeleteAllOrdersButton = new Button();
            SendOrdersToQueueButton = new Button();
            orderRightClickMenuStrip = new ContextMenuStrip(components);
            enableOrderToolMenuStripItem = new ToolStripMenuItem();
            deleteOrderToolMenuStripItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            showDetailsToolMenuStripItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)plannedOrdersDataGrid).BeginInit();
            orderRightClickMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // plannedOrdersDataGrid
            // 
            plannedOrdersDataGrid.AllowUserToResizeRows = false;
            plannedOrdersDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            plannedOrdersDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            plannedOrdersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            plannedOrdersDataGrid.Location = new Point(10, 9);
            plannedOrdersDataGrid.Margin = new Padding(3, 2, 3, 2);
            plannedOrdersDataGrid.Name = "plannedOrdersDataGrid";
            plannedOrdersDataGrid.ReadOnly = true;
            plannedOrdersDataGrid.RowHeadersVisible = false;
            plannedOrdersDataGrid.RowHeadersWidth = 51;
            plannedOrdersDataGrid.Size = new Size(714, 350);
            plannedOrdersDataGrid.TabIndex = 0;
            plannedOrdersDataGrid.CellDoubleClick += plannedOrdersDataGrid_CellDoubleClick;
            plannedOrdersDataGrid.CellMouseClick += plannedOrdersDataGrid_CellMouseClick;
            // 
            // DeleteAllOrdersButton
            // 
            DeleteAllOrdersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteAllOrdersButton.Location = new Point(10, 363);
            DeleteAllOrdersButton.Margin = new Padding(3, 2, 3, 2);
            DeleteAllOrdersButton.Name = "DeleteAllOrdersButton";
            DeleteAllOrdersButton.Size = new Size(169, 22);
            DeleteAllOrdersButton.TabIndex = 1;
            DeleteAllOrdersButton.Text = "Delete all planned orders";
            DeleteAllOrdersButton.UseVisualStyleBackColor = true;
            DeleteAllOrdersButton.Click += DeleteAllOrdersButton_Click;
            // 
            // SendOrdersToQueueButton
            // 
            SendOrdersToQueueButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SendOrdersToQueueButton.Location = new Point(185, 363);
            SendOrdersToQueueButton.Margin = new Padding(3, 2, 3, 2);
            SendOrdersToQueueButton.Name = "SendOrdersToQueueButton";
            SendOrdersToQueueButton.Size = new Size(225, 22);
            SendOrdersToQueueButton.TabIndex = 2;
            SendOrdersToQueueButton.Text = "Send all orders to production queue";
            SendOrdersToQueueButton.UseVisualStyleBackColor = true;
            SendOrdersToQueueButton.Click += SendOrdersToQueueButton_Click;
            // 
            // orderRightClickMenuStrip
            // 
            orderRightClickMenuStrip.ImageScalingSize = new Size(20, 20);
            orderRightClickMenuStrip.Items.AddRange(new ToolStripItem[] { enableOrderToolMenuStripItem, deleteOrderToolMenuStripItem, toolStripSeparator1, showDetailsToolMenuStripItem });
            orderRightClickMenuStrip.Name = "orderRightClickMenuStrip";
            orderRightClickMenuStrip.Size = new Size(143, 76);
            // 
            // enableOrderToolMenuStripItem
            // 
            enableOrderToolMenuStripItem.Name = "enableOrderToolMenuStripItem";
            enableOrderToolMenuStripItem.Size = new Size(142, 22);
            enableOrderToolMenuStripItem.Text = "Enable Order";
            enableOrderToolMenuStripItem.Click += enableOrderToolMenuStripItem_Click;
            // 
            // deleteOrderToolMenuStripItem
            // 
            deleteOrderToolMenuStripItem.Name = "deleteOrderToolMenuStripItem";
            deleteOrderToolMenuStripItem.Size = new Size(142, 22);
            deleteOrderToolMenuStripItem.Text = "Delete Order";
            deleteOrderToolMenuStripItem.Click += deleteOrderToolMenuStripItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(139, 6);
            // 
            // showDetailsToolMenuStripItem
            // 
            showDetailsToolMenuStripItem.Name = "showDetailsToolMenuStripItem";
            showDetailsToolMenuStripItem.Size = new Size(142, 22);
            showDetailsToolMenuStripItem.Text = "Show Details";
            showDetailsToolMenuStripItem.Click += showDetailsToolMenuStripItem_Click;
            // 
            // PlannedOrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 390);
            Controls.Add(SendOrdersToQueueButton);
            Controls.Add(DeleteAllOrdersButton);
            Controls.Add(plannedOrdersDataGrid);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PlannedOrdersForm";
            Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)plannedOrdersDataGrid).EndInit();
            orderRightClickMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView plannedOrdersDataGrid;
        private Button DeleteAllOrdersButton;
        private Button SendOrdersToQueueButton;
        private ContextMenuStrip orderRightClickMenuStrip;
        private ToolStripMenuItem enableOrderToolMenuStripItem;
        private ToolStripMenuItem deleteOrderToolMenuStripItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem showDetailsToolMenuStripItem;
    }
}