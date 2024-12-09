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
            currentOrdersDataGrid.Location = new Point(12, 10);
            currentOrdersDataGrid.Name = "currentOrdersDataGrid";
            currentOrdersDataGrid.ReadOnly = true;
            currentOrdersDataGrid.RowHeadersVisible = false;
            currentOrdersDataGrid.RowHeadersWidth = 51;
            currentOrdersDataGrid.Size = new Size(708, 334);
            currentOrdersDataGrid.TabIndex = 0;
            currentOrdersDataGrid.CellDoubleClick += currentOrdersDataGrid_CellDoubleClick;
            currentOrdersDataGrid.CellMouseClick += currentOrdersDataGrid_CellMouseClick;
            // 
            // orderRightClickMenuStrip
            // 
            orderRightClickMenuStrip.ImageScalingSize = new Size(20, 20);
            orderRightClickMenuStrip.Items.AddRange(new ToolStripItem[] { disableOrderToolStripMenuItem, deleteOrderToolStripMenuItem, toolStripSeparator1, showDetailsToolStripMenuItem });
            orderRightClickMenuStrip.Name = "orderRightClickMenuStrip";
            orderRightClickMenuStrip.Size = new Size(181, 98);
            // 
            // disableOrderToolStripMenuItem
            // 
            disableOrderToolStripMenuItem.Name = "disableOrderToolStripMenuItem";
            disableOrderToolStripMenuItem.Size = new Size(180, 22);
            disableOrderToolStripMenuItem.Text = "Disable Order";
            disableOrderToolStripMenuItem.Click += disableOrderToolStripMenuItem_Click;
            // 
            // deleteOrderToolStripMenuItem
            // 
            deleteOrderToolStripMenuItem.Name = "deleteOrderToolStripMenuItem";
            deleteOrderToolStripMenuItem.Size = new Size(180, 22);
            deleteOrderToolStripMenuItem.Text = "Delete Order";
            deleteOrderToolStripMenuItem.Click += deleteOrderToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(180, 22);
            showDetailsToolStripMenuItem.Text = "Show Details";
            showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click;
            // 
            // DeleteAllOrdersButton
            // 
            DeleteAllOrdersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteAllOrdersButton.Location = new Point(12, 349);
            DeleteAllOrdersButton.Margin = new Padding(3, 2, 3, 2);
            DeleteAllOrdersButton.Name = "DeleteAllOrdersButton";
            DeleteAllOrdersButton.Size = new Size(170, 22);
            DeleteAllOrdersButton.TabIndex = 1;
            DeleteAllOrdersButton.Text = "Delete all orders in queue";
            DeleteAllOrdersButton.UseVisualStyleBackColor = true;
            DeleteAllOrdersButton.Click += DeleteAllOrdersButton_Click;
            // 
            // DisableAllOrdersButton
            // 
            DisableAllOrdersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DisableAllOrdersButton.Location = new Point(187, 349);
            DisableAllOrdersButton.Margin = new Padding(3, 2, 3, 2);
            DisableAllOrdersButton.Name = "DisableAllOrdersButton";
            DisableAllOrdersButton.Size = new Size(122, 22);
            DisableAllOrdersButton.TabIndex = 2;
            DisableAllOrdersButton.Text = "Disable all orders";
            DisableAllOrdersButton.UseVisualStyleBackColor = true;
            DisableAllOrdersButton.Click += DisableAllOrdersButton_Click;
            // 
            // ProductionQueueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 378);
            Controls.Add(DisableAllOrdersButton);
            Controls.Add(DeleteAllOrdersButton);
            Controls.Add(currentOrdersDataGrid);
            Margin = new Padding(3, 2, 3, 2);
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