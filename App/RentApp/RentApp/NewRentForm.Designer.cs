namespace RentApp
{
    partial class NewRentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.cbCars = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHandOver = new System.Windows.Forms.DateTimePicker();
            this.dtpTakeOver = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.btnNewRent = new System.Windows.Forms.Button();
            this.lblNewRentError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // cbCustomers
            // 
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(15, 198);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(282, 24);
            this.cbCustomers.TabIndex = 1;
            // 
            // cbCars
            // 
            this.cbCars.FormattingEnabled = true;
            this.cbCars.Location = new System.Drawing.Point(15, 246);
            this.cbCars.Name = "cbCars";
            this.cbCars.Size = new System.Drawing.Size(282, 24);
            this.cbCars.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cars";
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(15, 150);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(283, 24);
            this.cbUsers.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Users";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Handover Date";
            // 
            // dtpHandOver
            // 
            this.dtpHandOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHandOver.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHandOver.Location = new System.Drawing.Point(15, 57);
            this.dtpHandOver.Name = "dtpHandOver";
            this.dtpHandOver.Size = new System.Drawing.Size(278, 24);
            this.dtpHandOver.TabIndex = 9;
            this.dtpHandOver.ValueChanged += new System.EventHandler(this.dtpHandOver_ValueChanged);
            // 
            // dtpTakeOver
            // 
            this.dtpTakeOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTakeOver.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTakeOver.Location = new System.Drawing.Point(16, 104);
            this.dtpTakeOver.Name = "dtpTakeOver";
            this.dtpTakeOver.Size = new System.Drawing.Size(278, 24);
            this.dtpTakeOver.TabIndex = 11;
            this.dtpTakeOver.Value = new System.DateTime(2020, 5, 17, 15, 8, 57, 0);
            this.dtpTakeOver.ValueChanged += new System.EventHandler(this.dtpTakeOver_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Takeover Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Price";
            // 
            // numPrice
            // 
            this.numPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrice.Location = new System.Drawing.Point(12, 292);
            this.numPrice.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(282, 23);
            this.numPrice.TabIndex = 13;
            // 
            // btnNewRent
            // 
            this.btnNewRent.Location = new System.Drawing.Point(12, 367);
            this.btnNewRent.Name = "btnNewRent";
            this.btnNewRent.Size = new System.Drawing.Size(278, 34);
            this.btnNewRent.TabIndex = 14;
            this.btnNewRent.Text = " Sell";
            this.btnNewRent.UseVisualStyleBackColor = true;
            this.btnNewRent.Click += new System.EventHandler(this.btnNewRent_Click);
            // 
            // lblNewRentError
            // 
            this.lblNewRentError.AutoSize = true;
            this.lblNewRentError.ForeColor = System.Drawing.Color.Red;
            this.lblNewRentError.Location = new System.Drawing.Point(12, 324);
            this.lblNewRentError.Name = "lblNewRentError";
            this.lblNewRentError.Size = new System.Drawing.Size(249, 17);
            this.lblNewRentError.TabIndex = 16;
            this.lblNewRentError.Text = "Please Add or Checked All Infromation";
            this.lblNewRentError.Visible = false;
            // 
            // NewRentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 420);
            this.Controls.Add(this.lblNewRentError);
            this.Controls.Add(this.btnNewRent);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpTakeOver);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpHandOver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCars);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCustomers);
            this.Controls.Add(this.label1);
            this.Name = "NewRentForm";
            this.Text = "NewRentForm";
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.ComboBox cbCars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHandOver;
        private System.Windows.Forms.DateTimePicker dtpTakeOver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Button btnNewRent;
        private System.Windows.Forms.Label lblNewRentError;
    }
}