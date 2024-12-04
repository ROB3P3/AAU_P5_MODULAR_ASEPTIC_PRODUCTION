namespace ROB5_MES_System.Forms
{
    partial class AddOperationForm
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
            label1 = new Label();
            OperationNumberNumeric = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            OperationDescriptionTextBox = new TextBox();
            OperationNameTextBox = new TextBox();
            AddOperationButton = new Button();
            ((System.ComponentModel.ISupportInitialize)OperationNumberNumeric).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 2;
            label1.Text = "Operation Number:";
            // 
            // OperationNumberNumeric
            // 
            OperationNumberNumeric.Location = new Point(176, 6);
            OperationNumberNumeric.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            OperationNumberNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            OperationNumberNumeric.Name = "OperationNumberNumeric";
            OperationNumberNumeric.Size = new Size(66, 27);
            OperationNumberNumeric.TabIndex = 3;
            OperationNumberNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 49);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 4;
            label2.Text = "Operation Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 89);
            label3.Name = "label3";
            label3.Size = new Size(159, 20);
            label3.TabIndex = 5;
            label3.Text = "Operation Description:";
            // 
            // OperationDescriptionTextBox
            // 
            OperationDescriptionTextBox.Location = new Point(176, 86);
            OperationDescriptionTextBox.MaxLength = 100;
            OperationDescriptionTextBox.Multiline = true;
            OperationDescriptionTextBox.Name = "OperationDescriptionTextBox";
            OperationDescriptionTextBox.Size = new Size(125, 66);
            OperationDescriptionTextBox.TabIndex = 8;
            // 
            // OperationNameTextBox
            // 
            OperationNameTextBox.Location = new Point(176, 46);
            OperationNameTextBox.MaxLength = 30;
            OperationNameTextBox.Name = "OperationNameTextBox";
            OperationNameTextBox.Size = new Size(125, 27);
            OperationNameTextBox.TabIndex = 7;
            // 
            // AddOperationButton
            // 
            AddOperationButton.Location = new Point(10, 159);
            AddOperationButton.Name = "AddOperationButton";
            AddOperationButton.Size = new Size(135, 29);
            AddOperationButton.TabIndex = 9;
            AddOperationButton.Text = "Add Operation";
            AddOperationButton.UseVisualStyleBackColor = true;
            AddOperationButton.Click += AddOperationButton_Click;
            // 
            // AddOperationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 198);
            Controls.Add(AddOperationButton);
            Controls.Add(OperationDescriptionTextBox);
            Controls.Add(OperationNameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(OperationNumberNumeric);
            Controls.Add(label1);
            Name = "AddOperationForm";
            Text = "Add Operation";
            ((System.ComponentModel.ISupportInitialize)OperationNumberNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown OperationNumberNumeric;
        private Label label2;
        private Label label3;
        private TextBox OperationDescriptionTextBox;
        private TextBox OperationNameTextBox;
        private Button AddOperationButton;
    }
}