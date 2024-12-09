namespace ROB5_MES_System
{
    partial class SystemStatusForm
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
            systemStatusDataGrid = new DataGridView();
            startProductionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)systemStatusDataGrid).BeginInit();
            SuspendLayout();
            // 
            // systemStatusDataGrid
            // 
            systemStatusDataGrid.AllowUserToResizeColumns = false;
            systemStatusDataGrid.AllowUserToResizeRows = false;
            systemStatusDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            systemStatusDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            systemStatusDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            systemStatusDataGrid.Location = new Point(10, 9);
            systemStatusDataGrid.Margin = new Padding(3, 2, 3, 2);
            systemStatusDataGrid.Name = "systemStatusDataGrid";
            systemStatusDataGrid.ReadOnly = true;
            systemStatusDataGrid.RowHeadersVisible = false;
            systemStatusDataGrid.RowHeadersWidth = 51;
            systemStatusDataGrid.Size = new Size(594, 162);
            systemStatusDataGrid.TabIndex = 0;
            // 
            // startProductionButton
            // 
            startProductionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            startProductionButton.Location = new Point(10, 184);
            startProductionButton.Margin = new Padding(3, 2, 3, 2);
            startProductionButton.Name = "startProductionButton";
            startProductionButton.Size = new Size(166, 44);
            startProductionButton.TabIndex = 1;
            startProductionButton.Text = "Start production";
            startProductionButton.UseVisualStyleBackColor = true;
            startProductionButton.Click += startProductionButton_Click;
            // 
            // SystemStatusForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 236);
            Controls.Add(startProductionButton);
            Controls.Add(systemStatusDataGrid);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SystemStatusForm";
            Text = "System Status";
            ((System.ComponentModel.ISupportInitialize)systemStatusDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView systemStatusDataGrid;
        private Button startProductionButton;
    }
}