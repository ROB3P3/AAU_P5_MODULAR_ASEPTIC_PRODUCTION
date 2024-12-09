namespace ROB5_MES_System
{
    partial class NewOrderForm
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
            StartOrderButton = new Button();
            ContainerAmountNumeric = new NumericUpDown();
            ContainerTypeComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            MedicineTypeBox = new TextBox();
            label6 = new Label();
            CompanyNameTextBox = new TextBox();
            label5 = new Label();
            OrderNumberDispLabel = new Label();
            label4 = new Label();
            PlanOrderButton = new Button();
            groupBox2 = new GroupBox();
            RemoveOperationButton = new Button();
            AddOperationButton = new Button();
            OperationsComboBox = new ComboBox();
            OperationsListBox = new ListBox();
            ((System.ComponentModel.ISupportInitialize)ContainerAmountNumeric).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // StartOrderButton
            // 
            StartOrderButton.Location = new Point(12, 261);
            StartOrderButton.Name = "StartOrderButton";
            StartOrderButton.Size = new Size(134, 66);
            StartOrderButton.TabIndex = 10;
            StartOrderButton.Text = "Add Order to Queue";
            StartOrderButton.UseVisualStyleBackColor = true;
            StartOrderButton.Click += StartOrderButton_Click;
            // 
            // ContainerAmountNumeric
            // 
            ContainerAmountNumeric.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            ContainerAmountNumeric.Location = new Point(162, 156);
            ContainerAmountNumeric.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            ContainerAmountNumeric.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            ContainerAmountNumeric.Name = "ContainerAmountNumeric";
            ContainerAmountNumeric.ReadOnly = true;
            ContainerAmountNumeric.Size = new Size(74, 27);
            ContainerAmountNumeric.TabIndex = 3;
            ContainerAmountNumeric.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // ContainerTypeComboBox
            // 
            ContainerTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ContainerTypeComboBox.FormattingEnabled = true;
            ContainerTypeComboBox.Items.AddRange(new object[] { "Cartridges", "Syringes" });
            ContainerTypeComboBox.Location = new Point(162, 113);
            ContainerTypeComboBox.Name = "ContainerTypeComboBox";
            ContainerTypeComboBox.Size = new Size(151, 28);
            ContainerTypeComboBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 116);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 5;
            label1.Text = "Container type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 158);
            label2.Name = "label2";
            label2.Size = new Size(131, 20);
            label2.TabIndex = 6;
            label2.Text = "Container amount:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(MedicineTypeBox);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(CompanyNameTextBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(OrderNumberDispLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ContainerAmountNumeric);
            groupBox1.Controls.Add(ContainerTypeComboBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 241);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order";
            // 
            // MedicineTypeBox
            // 
            MedicineTypeBox.Location = new Point(162, 195);
            MedicineTypeBox.MaxLength = 30;
            MedicineTypeBox.Name = "MedicineTypeBox";
            MedicineTypeBox.Size = new Size(125, 27);
            MedicineTypeBox.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 198);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 12;
            label6.Text = "Medicine type:";
            // 
            // CompanyNameTextBox
            // 
            CompanyNameTextBox.Location = new Point(163, 73);
            CompanyNameTextBox.MaxLength = 30;
            CompanyNameTextBox.Name = "CompanyNameTextBox";
            CompanyNameTextBox.Size = new Size(125, 27);
            CompanyNameTextBox.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 73);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 11;
            label5.Text = "Customer:";
            // 
            // OrderNumberDispLabel
            // 
            OrderNumberDispLabel.AutoSize = true;
            OrderNumberDispLabel.BackColor = SystemColors.Window;
            OrderNumberDispLabel.BorderStyle = BorderStyle.Fixed3D;
            OrderNumberDispLabel.Location = new Point(163, 32);
            OrderNumberDispLabel.MinimumSize = new Size(120, 25);
            OrderNumberDispLabel.Name = "OrderNumberDispLabel";
            OrderNumberDispLabel.Size = new Size(120, 25);
            OrderNumberDispLabel.TabIndex = 0;
            OrderNumberDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 33);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 6;
            label4.Text = "Order Number:";
            // 
            // PlanOrderButton
            // 
            PlanOrderButton.Location = new Point(161, 261);
            PlanOrderButton.Name = "PlanOrderButton";
            PlanOrderButton.Size = new Size(134, 66);
            PlanOrderButton.TabIndex = 11;
            PlanOrderButton.Text = "Plan Order";
            PlanOrderButton.UseVisualStyleBackColor = true;
            PlanOrderButton.Click += PlanOrderButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RemoveOperationButton);
            groupBox2.Controls.Add(AddOperationButton);
            groupBox2.Controls.Add(OperationsComboBox);
            groupBox2.Controls.Add(OperationsListBox);
            groupBox2.Location = new Point(382, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 241);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Operations";
            // 
            // RemoveOperationButton
            // 
            RemoveOperationButton.Location = new Point(7, 205);
            RemoveOperationButton.Name = "RemoveOperationButton";
            RemoveOperationButton.Size = new Size(85, 29);
            RemoveOperationButton.TabIndex = 9;
            RemoveOperationButton.Text = "Remove";
            RemoveOperationButton.UseVisualStyleBackColor = true;
            RemoveOperationButton.Click += RemoveOperationButton_Click;
            // 
            // AddOperationButton
            // 
            AddOperationButton.Location = new Point(164, 26);
            AddOperationButton.Name = "AddOperationButton";
            AddOperationButton.Size = new Size(54, 28);
            AddOperationButton.TabIndex = 7;
            AddOperationButton.Text = "Add";
            AddOperationButton.UseVisualStyleBackColor = true;
            AddOperationButton.Click += AddOperationButton_Click;
            // 
            // OperationsComboBox
            // 
            OperationsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            OperationsComboBox.FormattingEnabled = true;
            OperationsComboBox.Location = new Point(7, 26);
            OperationsComboBox.Name = "OperationsComboBox";
            OperationsComboBox.Size = new Size(151, 28);
            OperationsComboBox.TabIndex = 6;
            // 
            // OperationsListBox
            // 
            OperationsListBox.FormattingEnabled = true;
            OperationsListBox.Location = new Point(7, 72);
            OperationsListBox.Name = "OperationsListBox";
            OperationsListBox.Size = new Size(151, 124);
            OperationsListBox.TabIndex = 8;
            // 
            // NewOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 344);
            Controls.Add(groupBox2);
            Controls.Add(PlanOrderButton);
            Controls.Add(groupBox1);
            Controls.Add(StartOrderButton);
            Name = "NewOrderForm";
            Text = "New Order";
            ((System.ComponentModel.ISupportInitialize)ContainerAmountNumeric).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button StartOrderButton;
        private NumericUpDown ContainerAmountNumeric;
        private ComboBox ContainerTypeComboBox;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label4;
        private Label OrderNumberDispLabel;
        private TextBox CompanyNameTextBox;
        private Label label5;
        private Button PlanOrderButton;
        private Label label6;
        private TextBox MedicineTypeBox;
        private GroupBox groupBox2;
        private ListBox OperationsListBox;
        private ComboBox OperationsComboBox;
        private Button RemoveOperationButton;
        private Button AddOperationButton;
    }
}