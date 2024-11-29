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
            replanOrderToolMenuStripItem = new ToolStripMenuItem();
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
            plannedOrdersDataGrid.Location = new Point(12, 12);
            plannedOrdersDataGrid.Name = "plannedOrdersDataGrid";
            plannedOrdersDataGrid.ReadOnly = true;
            plannedOrdersDataGrid.RowHeadersVisible = false;
            plannedOrdersDataGrid.RowHeadersWidth = 51;
            plannedOrdersDataGrid.Size = new Size(812, 450);
            plannedOrdersDataGrid.TabIndex = 0;
            plannedOrdersDataGrid.CellDoubleClick += plannedOrdersDataGrid_CellDoubleClick;
            plannedOrdersDataGrid.CellMouseClick += plannedOrdersDataGrid_CellMouseClick;
            // 
            // DeleteAllOrdersButton
            // 
            DeleteAllOrdersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteAllOrdersButton.Location = new Point(12, 468);
            DeleteAllOrdersButton.Name = "DeleteAllOrdersButton";
            DeleteAllOrdersButton.Size = new Size(193, 29);
            DeleteAllOrdersButton.TabIndex = 1;
            DeleteAllOrdersButton.Text = "Delete all planned orders";
            DeleteAllOrdersButton.UseVisualStyleBackColor = true;
            DeleteAllOrdersButton.MouseClick += DeleteAllOrdersButton_MouseClick;
            // 
            // SendOrdersToQueueButton
            // 
            SendOrdersToQueueButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SendOrdersToQueueButton.Location = new Point(211, 468);
            SendOrdersToQueueButton.Name = "SendOrdersToQueueButton";
            SendOrdersToQueueButton.Size = new Size(257, 29);
            SendOrdersToQueueButton.TabIndex = 2;
            SendOrdersToQueueButton.Text = "Send all orders to production queue";
            SendOrdersToQueueButton.UseVisualStyleBackColor = true;
            SendOrdersToQueueButton.MouseClick += SendOrdersToQueueButton_MouseClick;
            // 
            // orderRightClickMenuStrip
            // 
            orderRightClickMenuStrip.ImageScalingSize = new Size(20, 20);
            orderRightClickMenuStrip.Items.AddRange(new ToolStripItem[] { enableOrderToolMenuStripItem, deleteOrderToolMenuStripItem, replanOrderToolMenuStripItem, toolStripSeparator1, showDetailsToolMenuStripItem });
            orderRightClickMenuStrip.Name = "orderRightClickMenuStrip";
            orderRightClickMenuStrip.Size = new Size(167, 106);
            // 
            // enableOrderToolMenuStripItem
            // 
            enableOrderToolMenuStripItem.Name = "enableOrderToolMenuStripItem";
            enableOrderToolMenuStripItem.Size = new Size(166, 24);
            enableOrderToolMenuStripItem.Text = "Enable Order";
            enableOrderToolMenuStripItem.MouseUp += enableOrderToolMenuStripItem_MouseUp;
            // 
            // deleteOrderToolMenuStripItem
            // 
            deleteOrderToolMenuStripItem.Name = "deleteOrderToolMenuStripItem";
            deleteOrderToolMenuStripItem.Size = new Size(166, 24);
            deleteOrderToolMenuStripItem.Text = "Delete Order";
            deleteOrderToolMenuStripItem.MouseUp += deleteOrderToolMenuStripItem_MouseUp;
            // 
            // replanOrderToolMenuStripItem
            // 
            replanOrderToolMenuStripItem.Name = "replanOrderToolMenuStripItem";
            replanOrderToolMenuStripItem.Size = new Size(166, 24);
            replanOrderToolMenuStripItem.Text = "Replan Order";
            replanOrderToolMenuStripItem.MouseUp += replanOrderToolMenuStripItem_MouseUp;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(163, 6);
            // 
            // showDetailsToolMenuStripItem
            // 
            showDetailsToolMenuStripItem.Name = "showDetailsToolMenuStripItem";
            showDetailsToolMenuStripItem.Size = new Size(166, 24);
            showDetailsToolMenuStripItem.Text = "Show Details";
            showDetailsToolMenuStripItem.MouseUp += showDetailsToolMenuStripItem_MouseUp;
            // 
            // PlannedOrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 504);
            Controls.Add(SendOrdersToQueueButton);
            Controls.Add(DeleteAllOrdersButton);
            Controls.Add(plannedOrdersDataGrid);
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
        private ToolStripMenuItem replanOrderToolMenuStripItem;
    }
}