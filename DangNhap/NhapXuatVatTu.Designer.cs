namespace DangNhap
{
    partial class NhapXuatVatTu
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
            this.panelTren = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNhap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_VatTuDungCu = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_VatTuThuoc = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelTren.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VatTuDungCu)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VatTuThuoc)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTren
            // 
            this.panelTren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTren.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(160)))), ((int)(((byte)(210)))));
            this.panelTren.Controls.Add(this.panel5);
            this.panelTren.Location = new System.Drawing.Point(0, 0);
            this.panelTren.Name = "panelTren";
            this.panelTren.Size = new System.Drawing.Size(1161, 44);
            this.panelTren.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(442, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(244, 41);
            this.panel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập xuất vật tư";
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(3, 0);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(84, 40);
            this.btnNhap.TabIndex = 3;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView_VatTuDungCu);
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 191);
            this.panel1.TabIndex = 5;
            // 
            // dataGridView_VatTuDungCu
            // 
            this.dataGridView_VatTuDungCu.AllowUserToAddRows = false;
            this.dataGridView_VatTuDungCu.AllowUserToDeleteRows = false;
            this.dataGridView_VatTuDungCu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_VatTuDungCu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VatTuDungCu.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_VatTuDungCu.Name = "dataGridView_VatTuDungCu";
            this.dataGridView_VatTuDungCu.RowHeadersWidth = 51;
            this.dataGridView_VatTuDungCu.RowTemplate.Height = 24;
            this.dataGridView_VatTuDungCu.Size = new System.Drawing.Size(1161, 191);
            this.dataGridView_VatTuDungCu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView_VatTuThuoc);
            this.panel2.Location = new System.Drawing.Point(0, 361);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 214);
            this.panel2.TabIndex = 6;
            // 
            // dataGridView_VatTuThuoc
            // 
            this.dataGridView_VatTuThuoc.AllowUserToAddRows = false;
            this.dataGridView_VatTuThuoc.AllowUserToDeleteRows = false;
            this.dataGridView_VatTuThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_VatTuThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VatTuThuoc.Location = new System.Drawing.Point(0, 3);
            this.dataGridView_VatTuThuoc.Name = "dataGridView_VatTuThuoc";
            this.dataGridView_VatTuThuoc.RowHeadersWidth = 51;
            this.dataGridView_VatTuThuoc.RowTemplate.Height = 24;
            this.dataGridView_VatTuThuoc.Size = new System.Drawing.Size(1161, 214);
            this.dataGridView_VatTuThuoc.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.btnSua);
            this.panel3.Controls.Add(this.btnXuat);
            this.panel3.Controls.Add(this.btnNhap);
            this.panel3.Location = new System.Drawing.Point(648, 303);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 40);
            this.panel3.TabIndex = 7;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(407, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 40);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(271, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 40);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(138, 0);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(84, 40);
            this.btnXuat.TabIndex = 8;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.panel4.Controls.Add(this.ceLearningTextbox1);
            this.panel4.Location = new System.Drawing.Point(314, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(488, 34);
            this.panel4.TabIndex = 8;
            // 
            // ceLearningTextbox1
            // 
            //this.ceLearningTextbox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            //|System.Windows.Forms.AnchorStyles.Right)));
            //this.ceLearningTextbox1.BackColor = System.Drawing.Color.Transparent;
            //this.ceLearningTextbox1.Br = System.Drawing.Color.White;
            //this.ceLearningTextbox1.Font = new System.Drawing.Font("Century Gothic", 12F);
            //this.ceLearningTextbox1.ForeColor = System.Drawing.Color.Black;
            //this.ceLearningTextbox1.Location = new System.Drawing.Point(3, 3);
            //this.ceLearningTextbox1.Name = "ceLearningTextbox1";
            //this.ceLearningTextbox1.Size = new System.Drawing.Size(482, 31);
            //this.ceLearningTextbox1.TabIndex = 0;
            //this.ceLearningTextbox1.Text = "ceLearningTextbox1";
            // 
            // NhapXuatVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 618);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTren);
            this.Name = "NhapXuatVatTu";
            this.Text = "NhapXuatVatTu";
            this.panelTren.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VatTuDungCu)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VatTuThuoc)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_VatTuDungCu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_VatTuThuoc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Panel panel4;
        private CeLearningTextbox ceLearningTextbox1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Panel panel5;
    }
}