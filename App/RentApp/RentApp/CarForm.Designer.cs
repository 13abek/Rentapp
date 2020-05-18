namespace RentApp
{
    partial class CarForm
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
            this.txtNewBrands = new System.Windows.Forms.TextBox();
            this.txtModels = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHorsePower = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvcarResult = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnExistingBrands = new System.Windows.Forms.Button();
            this.btnNewBrands = new System.Windows.Forms.Button();
            this.cbExistingBrands = new System.Windows.Forms.ComboBox();
            this.cbFuelType = new System.Windows.Forms.ComboBox();
            this.cbTransmission = new System.Windows.Forms.ComboBox();
            this.txtCarSearch = new System.Windows.Forms.TextBox();
            this.lblCarSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcarResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brands";
            // 
            // txtNewBrands
            // 
            this.txtNewBrands.Location = new System.Drawing.Point(12, 111);
            this.txtNewBrands.Name = "txtNewBrands";
            this.txtNewBrands.Size = new System.Drawing.Size(226, 22);
            this.txtNewBrands.TabIndex = 1;
            this.txtNewBrands.Visible = false;
            // 
            // txtModels
            // 
            this.txtModels.Location = new System.Drawing.Point(11, 156);
            this.txtModels.Name = "txtModels";
            this.txtModels.Size = new System.Drawing.Size(226, 22);
            this.txtModels.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Models";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(11, 251);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(226, 22);
            this.txtYear.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Year";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(11, 202);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(226, 22);
            this.txtNumber.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Number";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(11, 444);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(226, 22);
            this.txtPrice.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Price";
            // 
            // txtHorsePower
            // 
            this.txtHorsePower.Location = new System.Drawing.Point(11, 395);
            this.txtHorsePower.Name = "txtHorsePower";
            this.txtHorsePower.Size = new System.Drawing.Size(226, 22);
            this.txtHorsePower.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Horse Power";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Transmission";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Fuel Type";
            // 
            // dgvcarResult
            // 
            this.dgvcarResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcarResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcarResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvcarResult.Location = new System.Drawing.Point(262, 91);
            this.dgvcarResult.Name = "dgvcarResult";
            this.dgvcarResult.RowHeadersWidth = 51;
            this.dgvcarResult.RowTemplate.Height = 24;
            this.dgvcarResult.Size = new System.Drawing.Size(998, 648);
            this.dgvcarResult.TabIndex = 16;
            this.dgvcarResult.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvcarResult_RowHeaderMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Brands";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Models";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Number";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Year";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Fuel Type";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Transmission";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Horse Power";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Price";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 526);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(226, 35);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(11, 567);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(226, 35);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(11, 608);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(226, 35);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(9, 478);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(244, 20);
            this.lblError.TabIndex = 21;
            this.lblError.Text = "Please Add All Information !";
            this.lblError.Visible = false;
            // 
            // btnExistingBrands
            // 
            this.btnExistingBrands.Location = new System.Drawing.Point(8, 54);
            this.btnExistingBrands.Name = "btnExistingBrands";
            this.btnExistingBrands.Size = new System.Drawing.Size(115, 33);
            this.btnExistingBrands.TabIndex = 22;
            this.btnExistingBrands.Text = "Existing Brands";
            this.btnExistingBrands.UseVisualStyleBackColor = true;
            this.btnExistingBrands.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNewBrands
            // 
            this.btnNewBrands.Location = new System.Drawing.Point(129, 54);
            this.btnNewBrands.Name = "btnNewBrands";
            this.btnNewBrands.Size = new System.Drawing.Size(110, 33);
            this.btnNewBrands.TabIndex = 23;
            this.btnNewBrands.Text = "New Brands";
            this.btnNewBrands.UseVisualStyleBackColor = true;
            this.btnNewBrands.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbExistingBrands
            // 
            this.cbExistingBrands.FormattingEnabled = true;
            this.cbExistingBrands.Location = new System.Drawing.Point(13, 111);
            this.cbExistingBrands.Name = "cbExistingBrands";
            this.cbExistingBrands.Size = new System.Drawing.Size(227, 24);
            this.cbExistingBrands.TabIndex = 24;
            this.cbExistingBrands.Visible = false;
            // 
            // cbFuelType
            // 
            this.cbFuelType.FormattingEnabled = true;
            this.cbFuelType.Location = new System.Drawing.Point(11, 299);
            this.cbFuelType.Name = "cbFuelType";
            this.cbFuelType.Size = new System.Drawing.Size(227, 24);
            this.cbFuelType.TabIndex = 25;
            // 
            // cbTransmission
            // 
            this.cbTransmission.FormattingEnabled = true;
            this.cbTransmission.Location = new System.Drawing.Point(12, 349);
            this.cbTransmission.Name = "cbTransmission";
            this.cbTransmission.Size = new System.Drawing.Size(227, 24);
            this.cbTransmission.TabIndex = 26;
            // 
            // txtCarSearch
            // 
            this.txtCarSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarSearch.Location = new System.Drawing.Point(491, 38);
            this.txtCarSearch.Name = "txtCarSearch";
            this.txtCarSearch.Size = new System.Drawing.Size(769, 26);
            this.txtCarSearch.TabIndex = 27;
            this.txtCarSearch.TextChanged += new System.EventHandler(this.txtCarSearch_TextChanged);
            // 
            // lblCarSearch
            // 
            this.lblCarSearch.AutoSize = true;
            this.lblCarSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarSearch.Location = new System.Drawing.Point(309, 40);
            this.lblCarSearch.Name = "lblCarSearch";
            this.lblCarSearch.Size = new System.Drawing.Size(178, 20);
            this.lblCarSearch.TabIndex = 28;
            this.lblCarSearch.Text = "Search Car or Models:";
            // 
            // CarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 792);
            this.Controls.Add(this.lblCarSearch);
            this.Controls.Add(this.txtCarSearch);
            this.Controls.Add(this.cbTransmission);
            this.Controls.Add(this.cbFuelType);
            this.Controls.Add(this.cbExistingBrands);
            this.Controls.Add(this.btnNewBrands);
            this.Controls.Add(this.btnExistingBrands);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvcarResult);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHorsePower);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtModels);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewBrands);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CarForm";
            this.Text = "CarForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvcarResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewBrands;
        private System.Windows.Forms.TextBox txtModels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHorsePower;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvcarResult;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnExistingBrands;
        private System.Windows.Forms.Button btnNewBrands;
        private System.Windows.Forms.ComboBox cbExistingBrands;
        private System.Windows.Forms.ComboBox cbFuelType;
        private System.Windows.Forms.ComboBox cbTransmission;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.TextBox txtCarSearch;
        private System.Windows.Forms.Label lblCarSearch;
    }
}