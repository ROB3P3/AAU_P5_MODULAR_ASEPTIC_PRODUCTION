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
            MedicineDispLabel = new Label();
            MedicineLabel = new Label();
            ActualEndDispLabel = new Label();
            ActualEndLabel = new Label();
            ActualStartDispLabel = new Label();
            ActualStartLabel = new Label();
            CustomerDispLabel = new Label();
            CustomerLabel = new Label();
            OrderStateDispLabel = new Label();
            OrderStateLabel = new Label();
            CarrierAmountDispLabel = new Label();
            CarrierAmountLabel = new Label();
            ContainerTypeDispLabel = new Label();
            ContainerTypeLabel = new Label();
            ContainerAmountDispLabel = new Label();
            ContainerAmountLabel = new Label();
            OrderNumberDispLabel = new Label();
            OrderNumberLabel = new Label();
            groupBox2 = new GroupBox();
            CarrierTreeView = new TreeView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(MedicineDispLabel);
            groupBox1.Controls.Add(MedicineLabel);
            groupBox1.Controls.Add(ActualEndDispLabel);
            groupBox1.Controls.Add(ActualEndLabel);
            groupBox1.Controls.Add(ActualStartDispLabel);
            groupBox1.Controls.Add(ActualStartLabel);
            groupBox1.Controls.Add(CustomerDispLabel);
            groupBox1.Controls.Add(CustomerLabel);
            groupBox1.Controls.Add(OrderStateDispLabel);
            groupBox1.Controls.Add(OrderStateLabel);
            groupBox1.Controls.Add(CarrierAmountDispLabel);
            groupBox1.Controls.Add(CarrierAmountLabel);
            groupBox1.Controls.Add(ContainerTypeDispLabel);
            groupBox1.Controls.Add(ContainerTypeLabel);
            groupBox1.Controls.Add(ContainerAmountDispLabel);
            groupBox1.Controls.Add(ContainerAmountLabel);
            groupBox1.Controls.Add(OrderNumberDispLabel);
            groupBox1.Controls.Add(OrderNumberLabel);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(631, 219);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order Info";
            // 
            // MedicineDispLabel
            // 
            MedicineDispLabel.AutoSize = true;
            MedicineDispLabel.BackColor = SystemColors.Window;
            MedicineDispLabel.BorderStyle = BorderStyle.Fixed3D;
            MedicineDispLabel.Location = new Point(153, 100);
            MedicineDispLabel.MinimumSize = new Size(150, 25);
            MedicineDispLabel.Name = "MedicineDispLabel";
            MedicineDispLabel.Size = new Size(150, 25);
            MedicineDispLabel.TabIndex = 2;
            MedicineDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MedicineLabel
            // 
            MedicineLabel.AutoSize = true;
            MedicineLabel.Location = new Point(6, 105);
            MedicineLabel.Name = "MedicineLabel";
            MedicineLabel.Size = new Size(73, 20);
            MedicineLabel.TabIndex = 20;
            MedicineLabel.Text = "Medicine:";
            // 
            // ActualEndDispLabel
            // 
            ActualEndDispLabel.AutoSize = true;
            ActualEndDispLabel.BackColor = SystemColors.Window;
            ActualEndDispLabel.BorderStyle = BorderStyle.Fixed3D;
            ActualEndDispLabel.Location = new Point(153, 180);
            ActualEndDispLabel.MinimumSize = new Size(150, 25);
            ActualEndDispLabel.Name = "ActualEndDispLabel";
            ActualEndDispLabel.Size = new Size(150, 25);
            ActualEndDispLabel.TabIndex = 10;
            ActualEndDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ActualEndLabel
            // 
            ActualEndLabel.AutoSize = true;
            ActualEndLabel.Location = new Point(6, 185);
            ActualEndLabel.Name = "ActualEndLabel";
            ActualEndLabel.Size = new Size(37, 20);
            ActualEndLabel.TabIndex = 18;
            ActualEndLabel.Text = "End:";
            // 
            // ActualStartDispLabel
            // 
            ActualStartDispLabel.AutoSize = true;
            ActualStartDispLabel.BackColor = SystemColors.Window;
            ActualStartDispLabel.BorderStyle = BorderStyle.Fixed3D;
            ActualStartDispLabel.Location = new Point(152, 140);
            ActualStartDispLabel.MinimumSize = new Size(150, 25);
            ActualStartDispLabel.Name = "ActualStartDispLabel";
            ActualStartDispLabel.Size = new Size(150, 25);
            ActualStartDispLabel.TabIndex = 9;
            ActualStartDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ActualStartLabel
            // 
            ActualStartLabel.AutoSize = true;
            ActualStartLabel.Location = new Point(6, 145);
            ActualStartLabel.Name = "ActualStartLabel";
            ActualStartLabel.Size = new Size(43, 20);
            ActualStartLabel.TabIndex = 16;
            ActualStartLabel.Text = "Start:";
            // 
            // CustomerDispLabel
            // 
            CustomerDispLabel.AutoSize = true;
            CustomerDispLabel.BackColor = SystemColors.Window;
            CustomerDispLabel.BorderStyle = BorderStyle.Fixed3D;
            CustomerDispLabel.Location = new Point(152, 60);
            CustomerDispLabel.MinimumSize = new Size(150, 25);
            CustomerDispLabel.Name = "CustomerDispLabel";
            CustomerDispLabel.Size = new Size(150, 25);
            CustomerDispLabel.TabIndex = 1;
            CustomerDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CustomerLabel
            // 
            CustomerLabel.AutoSize = true;
            CustomerLabel.Location = new Point(6, 65);
            CustomerLabel.Name = "CustomerLabel";
            CustomerLabel.Size = new Size(75, 20);
            CustomerLabel.TabIndex = 14;
            CustomerLabel.Text = "Customer:";
            // 
            // OrderStateDispLabel
            // 
            OrderStateDispLabel.AutoSize = true;
            OrderStateDispLabel.BackColor = SystemColors.Window;
            OrderStateDispLabel.BorderStyle = BorderStyle.Fixed3D;
            OrderStateDispLabel.Location = new Point(454, 20);
            OrderStateDispLabel.MinimumSize = new Size(150, 25);
            OrderStateDispLabel.Name = "OrderStateDispLabel";
            OrderStateDispLabel.Size = new Size(150, 25);
            OrderStateDispLabel.TabIndex = 5;
            OrderStateDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderStateLabel
            // 
            OrderStateLabel.AutoSize = true;
            OrderStateLabel.Location = new Point(310, 25);
            OrderStateLabel.Name = "OrderStateLabel";
            OrderStateLabel.Size = new Size(86, 20);
            OrderStateLabel.TabIndex = 12;
            OrderStateLabel.Text = "Order state:";
            // 
            // CarrierAmountDispLabel
            // 
            CarrierAmountDispLabel.AutoSize = true;
            CarrierAmountDispLabel.BackColor = SystemColors.Window;
            CarrierAmountDispLabel.BorderStyle = BorderStyle.Fixed3D;
            CarrierAmountDispLabel.Location = new Point(454, 140);
            CarrierAmountDispLabel.MinimumSize = new Size(150, 25);
            CarrierAmountDispLabel.Name = "CarrierAmountDispLabel";
            CarrierAmountDispLabel.Size = new Size(150, 25);
            CarrierAmountDispLabel.TabIndex = 8;
            CarrierAmountDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CarrierAmountLabel
            // 
            CarrierAmountLabel.AutoSize = true;
            CarrierAmountLabel.Location = new Point(310, 145);
            CarrierAmountLabel.Name = "CarrierAmountLabel";
            CarrierAmountLabel.Size = new Size(111, 20);
            CarrierAmountLabel.TabIndex = 10;
            CarrierAmountLabel.Text = "Carrier amount:";
            // 
            // ContainerTypeDispLabel
            // 
            ContainerTypeDispLabel.AutoSize = true;
            ContainerTypeDispLabel.BackColor = SystemColors.Window;
            ContainerTypeDispLabel.BorderStyle = BorderStyle.Fixed3D;
            ContainerTypeDispLabel.Location = new Point(454, 60);
            ContainerTypeDispLabel.MinimumSize = new Size(150, 25);
            ContainerTypeDispLabel.Name = "ContainerTypeDispLabel";
            ContainerTypeDispLabel.Size = new Size(150, 25);
            ContainerTypeDispLabel.TabIndex = 6;
            ContainerTypeDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContainerTypeLabel
            // 
            ContainerTypeLabel.AutoSize = true;
            ContainerTypeLabel.Location = new Point(310, 65);
            ContainerTypeLabel.Name = "ContainerTypeLabel";
            ContainerTypeLabel.Size = new Size(109, 20);
            ContainerTypeLabel.TabIndex = 8;
            ContainerTypeLabel.Text = "Container type:";
            // 
            // ContainerAmountDispLabel
            // 
            ContainerAmountDispLabel.AutoSize = true;
            ContainerAmountDispLabel.BackColor = SystemColors.Window;
            ContainerAmountDispLabel.BorderStyle = BorderStyle.Fixed3D;
            ContainerAmountDispLabel.Location = new Point(454, 100);
            ContainerAmountDispLabel.MinimumSize = new Size(150, 25);
            ContainerAmountDispLabel.Name = "ContainerAmountDispLabel";
            ContainerAmountDispLabel.Size = new Size(150, 25);
            ContainerAmountDispLabel.TabIndex = 7;
            ContainerAmountDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContainerAmountLabel
            // 
            ContainerAmountLabel.AutoSize = true;
            ContainerAmountLabel.Location = new Point(310, 105);
            ContainerAmountLabel.Name = "ContainerAmountLabel";
            ContainerAmountLabel.Size = new Size(131, 20);
            ContainerAmountLabel.TabIndex = 6;
            ContainerAmountLabel.Text = "Container amount:";
            // 
            // OrderNumberDispLabel
            // 
            OrderNumberDispLabel.AutoSize = true;
            OrderNumberDispLabel.BackColor = SystemColors.Window;
            OrderNumberDispLabel.BorderStyle = BorderStyle.Fixed3D;
            OrderNumberDispLabel.Location = new Point(150, 20);
            OrderNumberDispLabel.MinimumSize = new Size(150, 25);
            OrderNumberDispLabel.Name = "OrderNumberDispLabel";
            OrderNumberDispLabel.Size = new Size(150, 25);
            OrderNumberDispLabel.TabIndex = 1;
            OrderNumberDispLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderNumberLabel
            // 
            OrderNumberLabel.AutoSize = true;
            OrderNumberLabel.Location = new Point(6, 25);
            OrderNumberLabel.Name = "OrderNumberLabel";
            OrderNumberLabel.Size = new Size(108, 20);
            OrderNumberLabel.TabIndex = 0;
            OrderNumberLabel.Text = "Order Number:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(CarrierTreeView);
            groupBox2.Location = new Point(8, 244);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(631, 266);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Carrier Queue";
            // 
            // CarrierTreeView
            // 
            CarrierTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CarrierTreeView.Location = new Point(6, 26);
            CarrierTreeView.Name = "CarrierTreeView";
            CarrierTreeView.Size = new Size(619, 232);
            CarrierTreeView.TabIndex = 11;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 526);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "OrderForm";
            Text = "OrderForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label OrderNumberLabel;
        private Label OrderNumberDispLabel;
        private Label ContainerTypeDispLabel;
        private Label ContainerTypeLabel;
        private Label ContainerAmountDispLabel;
        private Label ContainerAmountLabel;
        private GroupBox groupBox2;
        private TreeView CarrierTreeView;
        private Label CarrierAmountLabel;
        private Label CarrierAmountDispLabel;
        private Label OrderStateDispLabel;
        private Label OrderStateLabel;
        private Label CustomerDispLabel;
        private Label CustomerLabel;
        private Label ActualEndDispLabel;
        private Label ActualEndLabel;
        private Label ActualStartDispLabel;
        private Label ActualStartLabel;
        private Label MedicineDispLabel;
        private Label MedicineLabel;
    }
}