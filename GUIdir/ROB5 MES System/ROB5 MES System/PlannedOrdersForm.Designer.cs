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
            plannedOrdersDataGrid = new DataGridView();
            DeleteAllOrdersButton = new Button();
            SendOrdersToQueueButton = new Button();
            ((System.ComponentModel.ISupportInitialize)plannedOrdersDataGrid).BeginInit();
            SuspendLayout();
            // 
            // plannedOrdersDataGrid
            // 
            plannedOrdersDataGrid.AllowUserToResizeColumns = false;
            plannedOrdersDataGrid.AllowUserToResizeRows = false;
            plannedOrdersDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            plannedOrdersDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            plannedOrdersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            plannedOrdersDataGrid.Location = new Point(12, 12);
            plannedOrdersDataGrid.Name = "plannedOrdersDataGrid";
            plannedOrdersDataGrid.ReadOnly = true;
            plannedOrdersDataGrid.RowHeadersVisible = false;
            plannedOrdersDataGrid.RowHeadersWidth = 51;
            plannedOrdersDataGrid.Size = new Size(808, 434);
            plannedOrdersDataGrid.TabIndex = 0;
            // 
            // DeleteAllOrdersButton
            // 
            DeleteAllOrdersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DeleteAllOrdersButton.Location = new Point(12, 452);
            DeleteAllOrdersButton.Name = "DeleteAllOrdersButton";
            DeleteAllOrdersButton.Size = new Size(136, 29);
            DeleteAllOrdersButton.TabIndex = 2;
            DeleteAllOrdersButton.Text = "Delete all orders";
            DeleteAllOrdersButton.UseVisualStyleBackColor = true;
            DeleteAllOrdersButton.MouseClick += DeleteAllOrdersButton_MouseClick;
            // 
            // SendOrdersToQueueButton
            // 
            SendOrdersToQueueButton.Location = new Point(154, 452);
            SendOrdersToQueueButton.Name = "SendOrdersToQueueButton";
            SendOrdersToQueueButton.Size = new Size(257, 29);
            SendOrdersToQueueButton.TabIndex = 3;
            SendOrdersToQueueButton.Text = "Send all orders to production queue";
            SendOrdersToQueueButton.UseVisualStyleBackColor = true;
            SendOrdersToQueueButton.MouseClick += SendOrdersToQueueButton_MouseClick;
            // 
            // PlannedOrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 488);
            Controls.Add(SendOrdersToQueueButton);
            Controls.Add(DeleteAllOrdersButton);
            Controls.Add(plannedOrdersDataGrid);
            Name = "PlannedOrdersForm";
            Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)plannedOrdersDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView plannedOrdersDataGrid;
        private Button DeleteAllOrdersButton;
        private Button SendOrdersToQueueButton;
    }
}