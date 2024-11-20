namespace ROB5_MES_System
{
    partial class FinishedOrdersForm
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
            finishedOrdersDataGrid = new DataGridView();
            label1 = new Label();
            fromDateTimePicker = new DateTimePicker();
            label2 = new Label();
            toDateTimePicker = new DateTimePicker();
            showAllCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)finishedOrdersDataGrid).BeginInit();
            SuspendLayout();
            // 
            // finishedOrdersDataGrid
            // 
            finishedOrdersDataGrid.AllowUserToResizeRows = false;
            finishedOrdersDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            finishedOrdersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            finishedOrdersDataGrid.Location = new Point(12, 48);
            finishedOrdersDataGrid.Name = "finishedOrdersDataGrid";
            finishedOrdersDataGrid.ReadOnly = true;
            finishedOrdersDataGrid.RowHeadersVisible = false;
            finishedOrdersDataGrid.RowHeadersWidth = 51;
            finishedOrdersDataGrid.Size = new Size(574, 381);
            finishedOrdersDataGrid.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 1;
            label1.Text = "From:";
            // 
            // fromDateTimePicker
            // 
            fromDateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            fromDateTimePicker.Format = DateTimePickerFormat.Custom;
            fromDateTimePicker.Location = new Point(62, 15);
            fromDateTimePicker.Name = "fromDateTimePicker";
            fromDateTimePicker.Size = new Size(190, 27);
            fromDateTimePicker.TabIndex = 0;
            fromDateTimePicker.Value = new DateTime(2024, 11, 14, 11, 23, 11, 0);
            fromDateTimePicker.ValueChanged += fromDateTimePicker_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(295, 18);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 3;
            label2.Text = "To:";
            // 
            // toDateTimePicker
            // 
            toDateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            toDateTimePicker.Format = DateTimePickerFormat.Custom;
            toDateTimePicker.Location = new Point(328, 15);
            toDateTimePicker.Name = "toDateTimePicker";
            toDateTimePicker.Size = new Size(190, 27);
            toDateTimePicker.TabIndex = 1;
            toDateTimePicker.ValueChanged += toDateTimePicker_ValueChanged;
            // 
            // showAllCheckBox
            // 
            showAllCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            showAllCheckBox.AutoSize = true;
            showAllCheckBox.Location = new Point(12, 442);
            showAllCheckBox.Name = "showAllCheckBox";
            showAllCheckBox.Size = new Size(189, 24);
            showAllCheckBox.TabIndex = 5;
            showAllCheckBox.Text = "Show all finished orders";
            showAllCheckBox.UseVisualStyleBackColor = true;
            showAllCheckBox.CheckedChanged += showAllCheckBox_CheckedChanged;
            // 
            // FinishedOrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 478);
            Controls.Add(showAllCheckBox);
            Controls.Add(toDateTimePicker);
            Controls.Add(label2);
            Controls.Add(fromDateTimePicker);
            Controls.Add(label1);
            Controls.Add(finishedOrdersDataGrid);
            Name = "FinishedOrdersForm";
            Text = "Finished Orders";
            Load += FinishedOrders_Load;
            ((System.ComponentModel.ISupportInitialize)finishedOrdersDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView finishedOrdersDataGrid;
        private Label label1;
        private DateTimePicker fromDateTimePicker;
        private Label label2;
        private DateTimePicker toDateTimePicker;
        private CheckBox showAllCheckBox;
    }
}