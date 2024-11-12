namespace ROB5_MES_System
{
    partial class ReplanOrderForm
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
            PlannedEndTimeLabel = new Label();
            PlannedStartTimeLabel = new Label();
            OrderNumberDispLabel = new Label();
            OrderNumberLabel = new Label();
            plannedStartDateTimePicker = new DateTimePicker();
            plannedEndDateTimePicker = new DateTimePicker();
            replanOrderButton = new Button();
            SuspendLayout();
            // 
            // PlannedEndTimeLabel
            // 
            PlannedEndTimeLabel.AutoSize = true;
            PlannedEndTimeLabel.Location = new Point(12, 112);
            PlannedEndTimeLabel.Name = "PlannedEndTimeLabel";
            PlannedEndTimeLabel.Size = new Size(94, 20);
            PlannedEndTimeLabel.TabIndex = 4;
            PlannedEndTimeLabel.Text = "Planned end:";
            // 
            // PlannedStartTimeLabel
            // 
            PlannedStartTimeLabel.AutoSize = true;
            PlannedStartTimeLabel.Location = new Point(12, 62);
            PlannedStartTimeLabel.Name = "PlannedStartTimeLabel";
            PlannedStartTimeLabel.Size = new Size(98, 20);
            PlannedStartTimeLabel.TabIndex = 3;
            PlannedStartTimeLabel.Text = "Planned start:";
            // 
            // OrderNumberDispLabel
            // 
            OrderNumberDispLabel.AutoSize = true;
            OrderNumberDispLabel.BackColor = SystemColors.Window;
            OrderNumberDispLabel.BorderStyle = BorderStyle.Fixed3D;
            OrderNumberDispLabel.Location = new Point(154, 8);
            OrderNumberDispLabel.MinimumSize = new Size(170, 25);
            OrderNumberDispLabel.Name = "OrderNumberDispLabel";
            OrderNumberDispLabel.Size = new Size(170, 25);
            OrderNumberDispLabel.TabIndex = 1;
            OrderNumberDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderNumberLabel
            // 
            OrderNumberLabel.AutoSize = true;
            OrderNumberLabel.Location = new Point(12, 9);
            OrderNumberLabel.Name = "OrderNumberLabel";
            OrderNumberLabel.Size = new Size(108, 20);
            OrderNumberLabel.TabIndex = 0;
            OrderNumberLabel.Text = "Order Number:";
            // 
            // plannedStartDateTimePicker
            // 
            plannedStartDateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            plannedStartDateTimePicker.Format = DateTimePickerFormat.Custom;
            plannedStartDateTimePicker.Location = new Point(154, 57);
            plannedStartDateTimePicker.MinDate = new DateTime(2024, 11, 12, 0, 0, 0, 0);
            plannedStartDateTimePicker.Name = "plannedStartDateTimePicker";
            plannedStartDateTimePicker.ShowUpDown = true;
            plannedStartDateTimePicker.Size = new Size(170, 27);
            plannedStartDateTimePicker.TabIndex = 5;
            plannedStartDateTimePicker.ValueChanged += plannedStartDateTimePicker_ValueChanged;
            // 
            // plannedEndDateTimePicker
            // 
            plannedEndDateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            plannedEndDateTimePicker.Enabled = false;
            plannedEndDateTimePicker.Format = DateTimePickerFormat.Custom;
            plannedEndDateTimePicker.Location = new Point(154, 112);
            plannedEndDateTimePicker.MinDate = new DateTime(2024, 11, 12, 0, 0, 0, 0);
            plannedEndDateTimePicker.Name = "plannedEndDateTimePicker";
            plannedEndDateTimePicker.ShowUpDown = true;
            plannedEndDateTimePicker.Size = new Size(170, 27);
            plannedEndDateTimePicker.TabIndex = 6;
            // 
            // replanOrderButton
            // 
            replanOrderButton.Location = new Point(12, 156);
            replanOrderButton.Name = "replanOrderButton";
            replanOrderButton.Size = new Size(158, 29);
            replanOrderButton.TabIndex = 7;
            replanOrderButton.Text = "Confirm replanning";
            replanOrderButton.UseVisualStyleBackColor = true;
            replanOrderButton.Click += replanOrderButton_Click;
            // 
            // ReplanOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 197);
            Controls.Add(replanOrderButton);
            Controls.Add(plannedEndDateTimePicker);
            Controls.Add(plannedStartDateTimePicker);
            Controls.Add(PlannedEndTimeLabel);
            Controls.Add(OrderNumberLabel);
            Controls.Add(PlannedStartTimeLabel);
            Controls.Add(OrderNumberDispLabel);
            Name = "ReplanOrderForm";
            Text = "Replan Order";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PlannedEndTimeLabel;
        private Label PlannedStartTimeLabel;
        private Label OrderNumberDispLabel;
        private Label OrderNumberLabel;
        private DateTimePicker plannedStartDateTimePicker;
        private DateTimePicker plannedEndDateTimePicker;
        private Button replanOrderButton;
    }
}