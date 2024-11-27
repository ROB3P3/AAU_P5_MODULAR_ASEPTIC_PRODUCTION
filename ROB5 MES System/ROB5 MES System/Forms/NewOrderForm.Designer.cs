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
            StartTimePicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            MedicineTypeBox = new TextBox();
            label6 = new Label();
            CompanyNameTextBox = new TextBox();
            label5 = new Label();
            OrderNumberDispLabel = new Label();
            label4 = new Label();
            PlanOrderButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ContainerAmountNumeric).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // StartOrderButton
            // 
            StartOrderButton.Location = new Point(449, 22);
            StartOrderButton.Name = "StartOrderButton";
            StartOrderButton.Size = new Size(134, 66);
            StartOrderButton.TabIndex = 6;
            StartOrderButton.Text = "Add Order to Queue";
            StartOrderButton.UseVisualStyleBackColor = true;
            StartOrderButton.MouseUp += StartOrderButton_MouseUp;
            // 
            // ContainerAmountNumeric
            // 
            ContainerAmountNumeric.Location = new Point(162, 156);
            ContainerAmountNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ContainerAmountNumeric.Name = "ContainerAmountNumeric";
            ContainerAmountNumeric.Size = new Size(74, 27);
            ContainerAmountNumeric.TabIndex = 3;
            ContainerAmountNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ContainerTypeComboBox
            // 
            ContainerTypeComboBox.FormattingEnabled = true;
            ContainerTypeComboBox.Items.AddRange(new object[] { "Vials", "Syringes" });
            ContainerTypeComboBox.Location = new Point(162, 113);
            ContainerTypeComboBox.Name = "ContainerTypeComboBox";
            ContainerTypeComboBox.Size = new Size(151, 28);
            ContainerTypeComboBox.TabIndex = 2;
            // 
            // StartTimePicker
            // 
            StartTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            StartTimePicker.Format = DateTimePickerFormat.Custom;
            StartTimePicker.Location = new Point(162, 234);
            StartTimePicker.MinDate = new DateTime(2024, 11, 5, 0, 0, 0, 0);
            StartTimePicker.Name = "StartTimePicker";
            StartTimePicker.ShowUpDown = true;
            StartTimePicker.Size = new Size(164, 27);
            StartTimePicker.TabIndex = 5;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 234);
            label3.Name = "label3";
            label3.Size = new Size(140, 20);
            label3.TabIndex = 7;
            label3.Text = "Start time and date:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(MedicineTypeBox);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(CompanyNameTextBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(OrderNumberDispLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(StartTimePicker);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ContainerAmountNumeric);
            groupBox1.Controls.Add(ContainerTypeComboBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 298);
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
            label6.Size = new Size(103, 20);
            label6.TabIndex = 12;
            label6.Text = "Medicine type";
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
            PlanOrderButton.Location = new Point(449, 105);
            PlanOrderButton.Name = "PlanOrderButton";
            PlanOrderButton.Size = new Size(134, 66);
            PlanOrderButton.TabIndex = 7;
            PlanOrderButton.Text = "Plan Order";
            PlanOrderButton.UseVisualStyleBackColor = true;
            PlanOrderButton.Click += PlanOrderButton_Click;
            // 
            // NewOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 322);
            Controls.Add(PlanOrderButton);
            Controls.Add(groupBox1);
            Controls.Add(StartOrderButton);
            Name = "NewOrderForm";
            Text = "New Order";
            ((System.ComponentModel.ISupportInitialize)ContainerAmountNumeric).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button StartOrderButton;
        private NumericUpDown ContainerAmountNumeric;
        private ComboBox ContainerTypeComboBox;
        private DateTimePicker StartTimePicker;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private Label label4;
        private Label OrderNumberDispLabel;
        private TextBox CompanyNameTextBox;
        private Label label5;
        private Button PlanOrderButton;
        private Label label6;
        private TextBox MedicineTypeBox;
    }
}