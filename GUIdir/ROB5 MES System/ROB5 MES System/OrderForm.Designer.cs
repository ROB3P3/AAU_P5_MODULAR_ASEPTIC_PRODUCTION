namespace ROB5_MES_System
{
    partial class OrderForm
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
            groupBox1 = new GroupBox();
            ContainerTypeDispLabel = new Label();
            ContainerTypeLabel = new Label();
            ContainerAmountDispLabel = new Label();
            ContainerAmountLabel = new Label();
            PlannedEndTimeDispLabel = new Label();
            PlannedEndTimeLabel = new Label();
            PlannedStartTimeLabel = new Label();
            PlannedStartTimeDispLabel = new Label();
            OrderNumberDispLabel = new Label();
            OrderNumberLabel = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ContainerTypeDispLabel);
            groupBox1.Controls.Add(ContainerTypeLabel);
            groupBox1.Controls.Add(ContainerAmountDispLabel);
            groupBox1.Controls.Add(ContainerAmountLabel);
            groupBox1.Controls.Add(PlannedEndTimeDispLabel);
            groupBox1.Controls.Add(PlannedEndTimeLabel);
            groupBox1.Controls.Add(PlannedStartTimeLabel);
            groupBox1.Controls.Add(PlannedStartTimeDispLabel);
            groupBox1.Controls.Add(OrderNumberDispLabel);
            groupBox1.Controls.Add(OrderNumberLabel);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(473, 341);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order Info";
            // 
            // ContainerTypeDispLabel
            // 
            ContainerTypeDispLabel.AutoSize = true;
            ContainerTypeDispLabel.BackColor = SystemColors.Window;
            ContainerTypeDispLabel.BorderStyle = BorderStyle.Fixed3D;
            ContainerTypeDispLabel.Location = new Point(165, 200);
            ContainerTypeDispLabel.MinimumSize = new Size(120, 25);
            ContainerTypeDispLabel.Name = "ContainerTypeDispLabel";
            ContainerTypeDispLabel.Size = new Size(120, 25);
            ContainerTypeDispLabel.TabIndex = 9;
            ContainerTypeDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContainerTypeLabel
            // 
            ContainerTypeLabel.AutoSize = true;
            ContainerTypeLabel.Location = new Point(6, 200);
            ContainerTypeLabel.Name = "ContainerTypeLabel";
            ContainerTypeLabel.Size = new Size(108, 20);
            ContainerTypeLabel.TabIndex = 8;
            ContainerTypeLabel.Text = "Container Type";
            // 
            // ContainerAmountDispLabel
            // 
            ContainerAmountDispLabel.AutoSize = true;
            ContainerAmountDispLabel.BackColor = SystemColors.Window;
            ContainerAmountDispLabel.BorderStyle = BorderStyle.Fixed3D;
            ContainerAmountDispLabel.Location = new Point(165, 155);
            ContainerAmountDispLabel.MinimumSize = new Size(120, 25);
            ContainerAmountDispLabel.Name = "ContainerAmountDispLabel";
            ContainerAmountDispLabel.Size = new Size(120, 25);
            ContainerAmountDispLabel.TabIndex = 7;
            ContainerAmountDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContainerAmountLabel
            // 
            ContainerAmountLabel.AutoSize = true;
            ContainerAmountLabel.Location = new Point(6, 155);
            ContainerAmountLabel.Name = "ContainerAmountLabel";
            ContainerAmountLabel.Size = new Size(130, 20);
            ContainerAmountLabel.TabIndex = 6;
            ContainerAmountLabel.Text = "Container Amount";
            // 
            // PlannedEndTimeDispLabel
            // 
            PlannedEndTimeDispLabel.AutoSize = true;
            PlannedEndTimeDispLabel.BackColor = SystemColors.Window;
            PlannedEndTimeDispLabel.BorderStyle = BorderStyle.Fixed3D;
            PlannedEndTimeDispLabel.Location = new Point(165, 106);
            PlannedEndTimeDispLabel.MinimumSize = new Size(120, 25);
            PlannedEndTimeDispLabel.Name = "PlannedEndTimeDispLabel";
            PlannedEndTimeDispLabel.Size = new Size(120, 25);
            PlannedEndTimeDispLabel.TabIndex = 5;
            PlannedEndTimeDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PlannedEndTimeLabel
            // 
            PlannedEndTimeLabel.AutoSize = true;
            PlannedEndTimeLabel.Location = new Point(6, 111);
            PlannedEndTimeLabel.Name = "PlannedEndTimeLabel";
            PlannedEndTimeLabel.Size = new Size(128, 20);
            PlannedEndTimeLabel.TabIndex = 4;
            PlannedEndTimeLabel.Text = "Planned End Time";
            // 
            // PlannedStartTimeLabel
            // 
            PlannedStartTimeLabel.AutoSize = true;
            PlannedStartTimeLabel.Location = new Point(6, 64);
            PlannedStartTimeLabel.Name = "PlannedStartTimeLabel";
            PlannedStartTimeLabel.Size = new Size(134, 20);
            PlannedStartTimeLabel.TabIndex = 3;
            PlannedStartTimeLabel.Text = "Planned Start Time";
            // 
            // PlannedStartTimeDispLabel
            // 
            PlannedStartTimeDispLabel.AutoSize = true;
            PlannedStartTimeDispLabel.BackColor = SystemColors.Window;
            PlannedStartTimeDispLabel.BorderStyle = BorderStyle.Fixed3D;
            PlannedStartTimeDispLabel.Location = new Point(165, 63);
            PlannedStartTimeDispLabel.MinimumSize = new Size(120, 25);
            PlannedStartTimeDispLabel.Name = "PlannedStartTimeDispLabel";
            PlannedStartTimeDispLabel.Size = new Size(120, 25);
            PlannedStartTimeDispLabel.TabIndex = 2;
            PlannedStartTimeDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderNumberDispLabel
            // 
            OrderNumberDispLabel.AutoSize = true;
            OrderNumberDispLabel.BackColor = SystemColors.Window;
            OrderNumberDispLabel.BorderStyle = BorderStyle.Fixed3D;
            OrderNumberDispLabel.Location = new Point(165, 23);
            OrderNumberDispLabel.MinimumSize = new Size(120, 25);
            OrderNumberDispLabel.Name = "OrderNumberDispLabel";
            OrderNumberDispLabel.Size = new Size(120, 25);
            OrderNumberDispLabel.TabIndex = 1;
            OrderNumberDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderNumberLabel
            // 
            OrderNumberLabel.AutoSize = true;
            OrderNumberLabel.Location = new Point(6, 23);
            OrderNumberLabel.Name = "OrderNumberLabel";
            OrderNumberLabel.Size = new Size(153, 20);
            OrderNumberLabel.TabIndex = 0;
            OrderNumberLabel.Text = "Order Number (ONo):\r\n";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 450);
            Controls.Add(groupBox1);
            Name = "OrderForm";
            Text = "OrderForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label OrderNumberLabel;
        private Label OrderNumberDispLabel;
        private Label PlannedStartTimeLabel;
        private Label PlannedStartTimeDispLabel;
        private Label PlannedEndTimeDispLabel;
        private Label PlannedEndTimeLabel;
        private Label ContainerTypeDispLabel;
        private Label ContainerTypeLabel;
        private Label ContainerAmountDispLabel;
        private Label ContainerAmountLabel;
    }
}