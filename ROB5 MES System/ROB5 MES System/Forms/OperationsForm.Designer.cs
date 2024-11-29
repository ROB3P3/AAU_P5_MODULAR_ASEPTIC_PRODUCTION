namespace ROB5_MES_System
{
    partial class OperationsForm
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
            OperationsTreeView = new TreeView();
            label1 = new Label();
            OperationNumberDispLabel = new Label();
            label3 = new Label();
            OperationNameTextBox = new TextBox();
            label4 = new Label();
            OperationDescriptionTextBox = new TextBox();
            AddOperationButton = new Button();
            DeleteOperationButton = new Button();
            groupBox1 = new GroupBox();
            SaveOperationButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsTreeView
            // 
            OperationsTreeView.Location = new Point(12, 12);
            OperationsTreeView.Name = "OperationsTreeView";
            OperationsTreeView.Size = new Size(286, 229);
            OperationsTreeView.TabIndex = 0;
            OperationsTreeView.AfterSelect += OperationsTreeView_AfterSelect;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 1;
            label1.Text = "Operation Number:";
            // 
            // OperationNumberDispLabel
            // 
            OperationNumberDispLabel.AutoSize = true;
            OperationNumberDispLabel.BackColor = SystemColors.Window;
            OperationNumberDispLabel.BorderStyle = BorderStyle.Fixed3D;
            OperationNumberDispLabel.Location = new Point(149, 22);
            OperationNumberDispLabel.MinimumSize = new Size(60, 25);
            OperationNumberDispLabel.Name = "OperationNumberDispLabel";
            OperationNumberDispLabel.Size = new Size(60, 25);
            OperationNumberDispLabel.TabIndex = 3;
            OperationNumberDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 63);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 3;
            label3.Text = "Name:";
            // 
            // OperationNameTextBox
            // 
            OperationNameTextBox.Location = new Point(149, 62);
            OperationNameTextBox.MaxLength = 30;
            OperationNameTextBox.Name = "OperationNameTextBox";
            OperationNameTextBox.Size = new Size(125, 27);
            OperationNameTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 103);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 5;
            label4.Text = "Description:";
            // 
            // OperationDescriptionTextBox
            // 
            OperationDescriptionTextBox.Location = new Point(149, 102);
            OperationDescriptionTextBox.MaxLength = 100;
            OperationDescriptionTextBox.Multiline = true;
            OperationDescriptionTextBox.Name = "OperationDescriptionTextBox";
            OperationDescriptionTextBox.Size = new Size(125, 66);
            OperationDescriptionTextBox.TabIndex = 5;
            // 
            // AddOperationButton
            // 
            AddOperationButton.Location = new Point(12, 247);
            AddOperationButton.Name = "AddOperationButton";
            AddOperationButton.Size = new Size(140, 29);
            AddOperationButton.TabIndex = 1;
            AddOperationButton.Text = "Add Operation";
            AddOperationButton.UseVisualStyleBackColor = true;
            AddOperationButton.Click += AddOperationButton_Click;
            // 
            // DeleteOperationButton
            // 
            DeleteOperationButton.Location = new Point(158, 247);
            DeleteOperationButton.Name = "DeleteOperationButton";
            DeleteOperationButton.Size = new Size(140, 29);
            DeleteOperationButton.TabIndex = 2;
            DeleteOperationButton.Text = "Delete Operation";
            DeleteOperationButton.UseVisualStyleBackColor = true;
            DeleteOperationButton.Click += DeleteOperationButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(OperationNumberDispLabel);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(OperationDescriptionTextBox);
            groupBox1.Controls.Add(OperationNameTextBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(304, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(287, 229);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Operation Info";
            // 
            // SaveOperationButton
            // 
            SaveOperationButton.Location = new Point(539, 247);
            SaveOperationButton.Name = "SaveOperationButton";
            SaveOperationButton.Size = new Size(52, 29);
            SaveOperationButton.TabIndex = 6;
            SaveOperationButton.Text = "Save";
            SaveOperationButton.UseVisualStyleBackColor = true;
            SaveOperationButton.Click += SaveOperationButton_Click;
            // 
            // OperationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 330);
            Controls.Add(SaveOperationButton);
            Controls.Add(groupBox1);
            Controls.Add(DeleteOperationButton);
            Controls.Add(AddOperationButton);
            Controls.Add(OperationsTreeView);
            Name = "OperationsForm";
            Text = "Operations";
            Load += OperationsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TreeView OperationsTreeView;
        private Label label1;
        private Label OperationNumberDispLabel;
        private Label label3;
        private TextBox OperationNameTextBox;
        private Label label4;
        private TextBox OperationDescriptionTextBox;
        private Button AddOperationButton;
        private Button DeleteOperationButton;
        private GroupBox groupBox1;
        private Button SaveOperationButton;
    }
}