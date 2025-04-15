namespace Assignment7
{
    partial class EditForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OrderIDLabel = new System.Windows.Forms.Label();
            this.OrderIDTextBox = new System.Windows.Forms.TextBox();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.CustomerCBX = new System.Windows.Forms.ComboBox();
            this.AppleLabel = new System.Windows.Forms.Label();
            this.AppleUnitPrice = new System.Windows.Forms.Label();
            this.AppleQuantityLabel = new System.Windows.Forms.Label();
            this.AppleQuantity = new System.Windows.Forms.NumericUpDown();
            this.OrangeLabel = new System.Windows.Forms.Label();
            this.OrangeUnitPrice = new System.Windows.Forms.Label();
            this.OrangeQuantityLabel = new System.Windows.Forms.Label();
            this.OrangeQuantity = new System.Windows.Forms.NumericUpDown();
            this.BananaLabel = new System.Windows.Forms.Label();
            this.BananaUnitPrice = new System.Windows.Forms.Label();
            this.BananaQuantityLabel = new System.Windows.Forms.Label();
            this.BananaQuantity = new System.Windows.Forms.NumericUpDown();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CustomerBD = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppleQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BananaQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.ConfirmButton);
            this.panel1.Controls.Add(this.BananaQuantity);
            this.panel1.Controls.Add(this.BananaQuantityLabel);
            this.panel1.Controls.Add(this.BananaUnitPrice);
            this.panel1.Controls.Add(this.BananaLabel);
            this.panel1.Controls.Add(this.OrangeQuantity);
            this.panel1.Controls.Add(this.OrangeQuantityLabel);
            this.panel1.Controls.Add(this.OrangeUnitPrice);
            this.panel1.Controls.Add(this.OrangeLabel);
            this.panel1.Controls.Add(this.AppleQuantity);
            this.panel1.Controls.Add(this.AppleQuantityLabel);
            this.panel1.Controls.Add(this.AppleUnitPrice);
            this.panel1.Controls.Add(this.AppleLabel);
            this.panel1.Controls.Add(this.CustomerCBX);
            this.panel1.Controls.Add(this.CustomerLabel);
            this.panel1.Controls.Add(this.OrderIDTextBox);
            this.panel1.Controls.Add(this.OrderIDLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // OrderIDLabel
            // 
            this.OrderIDLabel.AutoSize = true;
            this.OrderIDLabel.Font = new System.Drawing.Font("宋体", 13F);
            this.OrderIDLabel.Location = new System.Drawing.Point(51, 31);
            this.OrderIDLabel.Name = "OrderIDLabel";
            this.OrderIDLabel.Size = new System.Drawing.Size(116, 26);
            this.OrderIDLabel.TabIndex = 0;
            this.OrderIDLabel.Text = "订单号：";
            // 
            // OrderIDTextBox
            // 
            this.OrderIDTextBox.Font = new System.Drawing.Font("宋体", 13F);
            this.OrderIDTextBox.Location = new System.Drawing.Point(191, 20);
            this.OrderIDTextBox.Name = "OrderIDTextBox";
            this.OrderIDTextBox.Size = new System.Drawing.Size(155, 37);
            this.OrderIDTextBox.TabIndex = 1;
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Font = new System.Drawing.Font("宋体", 13F);
            this.CustomerLabel.Location = new System.Drawing.Point(77, 84);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(90, 26);
            this.CustomerLabel.TabIndex = 2;
            this.CustomerLabel.Text = "客户：";
            // 
            // CustomerCBX
            // 
            this.CustomerCBX.DataSource = this.CustomerBD;
            this.CustomerCBX.DisplayMember = "Name";
            this.CustomerCBX.Font = new System.Drawing.Font("宋体", 13F);
            this.CustomerCBX.FormattingEnabled = true;
            this.CustomerCBX.Location = new System.Drawing.Point(191, 76);
            this.CustomerCBX.Name = "CustomerCBX";
            this.CustomerCBX.Size = new System.Drawing.Size(155, 34);
            this.CustomerCBX.TabIndex = 3;
            // 
            // AppleLabel
            // 
            this.AppleLabel.AutoSize = true;
            this.AppleLabel.Font = new System.Drawing.Font("宋体", 13F);
            this.AppleLabel.Location = new System.Drawing.Point(77, 137);
            this.AppleLabel.Name = "AppleLabel";
            this.AppleLabel.Size = new System.Drawing.Size(90, 26);
            this.AppleLabel.TabIndex = 4;
            this.AppleLabel.Text = "苹果：";
            // 
            // AppleUnitPrice
            // 
            this.AppleUnitPrice.AutoSize = true;
            this.AppleUnitPrice.Font = new System.Drawing.Font("宋体", 13F);
            this.AppleUnitPrice.Location = new System.Drawing.Point(186, 137);
            this.AppleUnitPrice.Name = "AppleUnitPrice";
            this.AppleUnitPrice.Size = new System.Drawing.Size(103, 26);
            this.AppleUnitPrice.TabIndex = 5;
            this.AppleUnitPrice.Text = "2 元/斤";
            // 
            // AppleQuantityLabel
            // 
            this.AppleQuantityLabel.AutoSize = true;
            this.AppleQuantityLabel.Font = new System.Drawing.Font("宋体", 13F);
            this.AppleQuantityLabel.Location = new System.Drawing.Point(25, 185);
            this.AppleQuantityLabel.Name = "AppleQuantityLabel";
            this.AppleQuantityLabel.Size = new System.Drawing.Size(142, 26);
            this.AppleQuantityLabel.TabIndex = 6;
            this.AppleQuantityLabel.Text = "购买数量：";
            // 
            // AppleQuantity
            // 
            this.AppleQuantity.Font = new System.Drawing.Font("宋体", 13F);
            this.AppleQuantity.Location = new System.Drawing.Point(191, 183);
            this.AppleQuantity.Name = "AppleQuantity";
            this.AppleQuantity.Size = new System.Drawing.Size(155, 37);
            this.AppleQuantity.TabIndex = 7;
            // 
            // OrangeLabel
            // 
            this.OrangeLabel.AutoSize = true;
            this.OrangeLabel.Font = new System.Drawing.Font("宋体", 13F);
            this.OrangeLabel.Location = new System.Drawing.Point(77, 236);
            this.OrangeLabel.Name = "OrangeLabel";
            this.OrangeLabel.Size = new System.Drawing.Size(90, 26);
            this.OrangeLabel.TabIndex = 8;
            this.OrangeLabel.Text = "橘子：";
            // 
            // OrangeUnitPrice
            // 
            this.OrangeUnitPrice.AutoSize = true;
            this.OrangeUnitPrice.Font = new System.Drawing.Font("宋体", 13F);
            this.OrangeUnitPrice.Location = new System.Drawing.Point(186, 236);
            this.OrangeUnitPrice.Name = "OrangeUnitPrice";
            this.OrangeUnitPrice.Size = new System.Drawing.Size(129, 26);
            this.OrangeUnitPrice.TabIndex = 9;
            this.OrangeUnitPrice.Text = "2.5 元/斤";
            // 
            // OrangeQuantityLabel
            // 
            this.OrangeQuantityLabel.AutoSize = true;
            this.OrangeQuantityLabel.Font = new System.Drawing.Font("宋体", 13F);
            this.OrangeQuantityLabel.Location = new System.Drawing.Point(25, 275);
            this.OrangeQuantityLabel.Name = "OrangeQuantityLabel";
            this.OrangeQuantityLabel.Size = new System.Drawing.Size(142, 26);
            this.OrangeQuantityLabel.TabIndex = 10;
            this.OrangeQuantityLabel.Text = "购买数量：";
            // 
            // OrangeQuantity
            // 
            this.OrangeQuantity.Font = new System.Drawing.Font("宋体", 13F);
            this.OrangeQuantity.Location = new System.Drawing.Point(191, 273);
            this.OrangeQuantity.Name = "OrangeQuantity";
            this.OrangeQuantity.Size = new System.Drawing.Size(155, 37);
            this.OrangeQuantity.TabIndex = 11;
            // 
            // BananaLabel
            // 
            this.BananaLabel.AutoSize = true;
            this.BananaLabel.Font = new System.Drawing.Font("宋体", 13F);
            this.BananaLabel.Location = new System.Drawing.Point(77, 324);
            this.BananaLabel.Name = "BananaLabel";
            this.BananaLabel.Size = new System.Drawing.Size(90, 26);
            this.BananaLabel.TabIndex = 12;
            this.BananaLabel.Text = "香蕉：";
            // 
            // BananaUnitPrice
            // 
            this.BananaUnitPrice.AutoSize = true;
            this.BananaUnitPrice.Font = new System.Drawing.Font("宋体", 13F);
            this.BananaUnitPrice.Location = new System.Drawing.Point(186, 324);
            this.BananaUnitPrice.Name = "BananaUnitPrice";
            this.BananaUnitPrice.Size = new System.Drawing.Size(103, 26);
            this.BananaUnitPrice.TabIndex = 13;
            this.BananaUnitPrice.Text = "3 元/斤";
            // 
            // BananaQuantityLabel
            // 
            this.BananaQuantityLabel.AutoSize = true;
            this.BananaQuantityLabel.Font = new System.Drawing.Font("宋体", 13F);
            this.BananaQuantityLabel.Location = new System.Drawing.Point(25, 363);
            this.BananaQuantityLabel.Name = "BananaQuantityLabel";
            this.BananaQuantityLabel.Size = new System.Drawing.Size(142, 26);
            this.BananaQuantityLabel.TabIndex = 14;
            this.BananaQuantityLabel.Text = "购买数量：";
            // 
            // BananaQuantity
            // 
            this.BananaQuantity.Font = new System.Drawing.Font("宋体", 13F);
            this.BananaQuantity.Location = new System.Drawing.Point(191, 360);
            this.BananaQuantity.Name = "BananaQuantity";
            this.BananaQuantity.Size = new System.Drawing.Size(155, 37);
            this.BananaQuantity.TabIndex = 15;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Font = new System.Drawing.Font("宋体", 13F);
            this.ConfirmButton.Location = new System.Drawing.Point(506, 76);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(203, 77);
            this.ConfirmButton.TabIndex = 16;
            this.ConfirmButton.Text = "确认";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("宋体", 13F);
            this.CancelButton.Location = new System.Drawing.Point(506, 275);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(203, 75);
            this.CancelButton.TabIndex = 17;
            this.CancelButton.Text = "取消";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // CustomerBD
            // 
            this.CustomerBD.DataSource = typeof(Assignment7.Customer);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppleQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BananaQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label OrderIDLabel;
        private System.Windows.Forms.ComboBox CustomerCBX;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.TextBox OrderIDTextBox;
        private System.Windows.Forms.Label AppleLabel;
        private System.Windows.Forms.Label AppleUnitPrice;
        private System.Windows.Forms.Label AppleQuantityLabel;
        private System.Windows.Forms.NumericUpDown AppleQuantity;
        private System.Windows.Forms.Label OrangeQuantityLabel;
        private System.Windows.Forms.Label OrangeUnitPrice;
        private System.Windows.Forms.Label OrangeLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.NumericUpDown BananaQuantity;
        private System.Windows.Forms.Label BananaQuantityLabel;
        private System.Windows.Forms.Label BananaUnitPrice;
        private System.Windows.Forms.Label BananaLabel;
        private System.Windows.Forms.NumericUpDown OrangeQuantity;
        private System.Windows.Forms.BindingSource CustomerBD;
    }
}