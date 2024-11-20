namespace ROB5_MES_System
{
    partial class ProductionQueueForm
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
            currentOrdersDataGrid = new DataGridView();
            orderRightClickMenuStrip = new ContextMenuStrip(components);
            disableOrderToolStripMenuItem = new ToolStripMenuItem();
            deleteOrderToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            showDetailsToolStripMenuItem = new ToolStripMenuItem();
            DeleteAllOrdersButton = new Button();
            DisableAllOrdersButton = new Button();
            ((System.ComponentModel.ISupportInitialize)currentOrdersDataGrid).BeginInit();
            orderRightClickMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // currentOrdersDataGrid
            // 
            currentOrdersDataGrid.AllowUserToResizeRows = false;
            currentOrdersDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            currentOrdersDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            currentOrdersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            currentOrdersDataGrid.Location = new Point(14, 13);
            currentOrdersDataGrid.Margin = new Padding(3, 4, 3, 4);
            currentOrdersDataGrid.Name = "currentOrdersDataGrid";
            currentOrdersDataGrid.ReadOnly = true;
            currentOrdersDataGrid.RowHeadersVisible = false;
            currentOrdersDataGrid.RowHeadersWidth = 51;
            currentOrdersDataGrid.Size = new Size(805, 429);
            currentOrdersDataGrid.TabIndex = 0;
            currentOrdersDataGrid.CellDoubleClick += currentOrdersDataGrid_CellDoubleClick;
            currentOrdersDataGrid.CellMouseClick += currentOrdersDataGrid_CellMouseClick;
            // 
            // orderRightClickMenuStrip
            // 
            orderRightClickMenuStrip.ImageScalingSize = new Size(20, 20);
            orderRightClickMenuStrip.Items.AddRange(new ToolStripItem[] { disableOrderToolStripMenuItem, deleteOrderToolStripMenuItem, toolStripSeparator1, showDetailsToolStripMenuItem });
            orderRightClickMenuStrip.Name = "orderRightClickMenuStrip";
            orderRightClickMenuStrip.Size = new Size(171, 82);
            // 
            // disableOrderToolStripMenuItem
            // 
            disableOrderToolStripMenuItem.Name = "disableOrderToolStripMenuItem";
            disableOrderToolStripMenuItem.Size = new Size(170, 24);
            disableOrderToolStripMenuItem.Text = "Disable Order";
            disableOrderToolStripMenuItem.MouseUp += disableOrderToolStripMenuItem_MouseUp;
            // 
            // deleteOrderToolStripMenuItem
            // 
            deleteOrderToolStripMenuItem.Name = "deleteOrderToolStripMenuItem";
            deleteOrderToolStripMenuItem.Size = new Size(170, 24);
            deleteOrderToolStripMenuItem.Text = "Delete Order";
            deleteOrderToolStripMenuItem.MouseUp += deleteOrderToolStripMenuItem_MouseUp;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(167, 6);
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(170, 24);
            showDetailsToolStripMenuItem.Text = "Show Details";
            showDetailsToolStripMenuItem.MouseUp += showDetailsToolStripMenuItem_MouseUp;
            // 
            // DeleteAllOrdersButton
            // 
            DeleteAllOrdersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteAllOrdersButton.Location = new Point(14, 449);
            DeleteAllOrdersButton.Name = "DeleteAllOrdersButton";
            DeleteAllOrdersButton.Size = new Size(194, 29);
            DeleteAllOrdersButton.TabIndex = 1;
            DeleteAllOrdersButton.Text = "Delete all orders in queue";
            DeleteAllOrdersButton.UseVisualStyleBackColor = true;
            DeleteAllOrdersButton.MouseClick += DeleteAllOrdersButton_MouseClick;
            // 
            // DisableAllOrdersButton
            // 
            DisableAllOrdersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DisableAllOrdersButton.Location = new Point(214, 449);
            DisableAllOrdersButton.Name = "DisableAllOrdersButton";
            DisableAllOrdersButton.Size = new Size(139, 29);
            DisableAllOrdersButton.TabIndex = 2;
            DisableAllOrdersButton.Text = "Disable all orders";
            DisableAllOrdersButton.UseVisualStyleBackColor = true;
            DisableAllOrdersButton.MouseClick += DisableAllOrdersButton_MouseClick;
            // 
            // ProductionQueueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 488);
            Controls.Add(DisableAllOrdersButton);
            Controls.Add(DeleteAllOrdersButton);
            Controls.Add(currentOrdersDataGrid);
            Name = "ProductionQueueForm";
            Text = "Production Queue";
            ((System.ComponentModel.ISupportInitialize)currentOrdersDataGrid).EndInit();
            orderRightClickMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView currentOrdersDataGrid;
        private ContextMenuStrip orderRightClickMenuStrip;
        private ToolStripMenuItem disableOrderToolStripMenuItem;
        private ToolStripMenuItem deleteOrderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem showDetailsToolStripMenuItem;
        private Button DeleteAllOrdersButton;
        private Button DisableAllOrdersButton;
    }
}