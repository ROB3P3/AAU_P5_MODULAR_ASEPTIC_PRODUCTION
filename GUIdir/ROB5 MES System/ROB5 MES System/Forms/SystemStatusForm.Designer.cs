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
            systemStatusDataGrid.Location = new Point(12, 12);
            systemStatusDataGrid.Name = "systemStatusDataGrid";
            systemStatusDataGrid.ReadOnly = true;
            systemStatusDataGrid.RowHeadersVisible = false;
            systemStatusDataGrid.RowHeadersWidth = 51;
            systemStatusDataGrid.Size = new Size(679, 216);
            systemStatusDataGrid.TabIndex = 0;
            // 
            // startProductionButton
            // 
            startProductionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            startProductionButton.Location = new Point(12, 245);
            startProductionButton.Name = "startProductionButton";
            startProductionButton.Size = new Size(190, 58);
            startProductionButton.TabIndex = 1;
            startProductionButton.Text = "Start production";
            startProductionButton.UseVisualStyleBackColor = true;
            startProductionButton.MouseClick += startProductionButton_MouseClick;
            // 
            // SystemStatusForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 315);
            Controls.Add(startProductionButton);
            Controls.Add(systemStatusDataGrid);
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