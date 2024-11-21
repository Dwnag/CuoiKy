namespace DangNhap
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.artanPanel1 = new ArtanComponent.ArtanPanel();
            this.Hienmatkhau = new System.Windows.Forms.CheckBox();
            this.Thoat = new System.Windows.Forms.LinkLabel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.roundPictureBox3 = new ArtanComponent.RoundPictureBox();
            this.matkhau = new System.Windows.Forms.TextBox();
            this.taikhoan = new System.Windows.Forms.TextBox();
            this.roundPictureBox2 = new ArtanComponent.RoundPictureBox();
            this.roundPictureBox1 = new ArtanComponent.RoundPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.roundPictureBox4 = new ArtanComponent.RoundPictureBox();
            this.artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // artanPanel1
            // 
            this.artanPanel1.AllowDrop = true;
            this.artanPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.artanPanel1.AutoScroll = true;
            this.artanPanel1.AutoScrollMinSize = new System.Drawing.Size(100, 100);
            this.artanPanel1.BackColor = System.Drawing.Color.White;
            this.artanPanel1.BorderAngle = 90F;
            this.artanPanel1.BorderRadius = 40;
            this.artanPanel1.Controls.Add(this.pictureBox2);
            this.artanPanel1.Controls.Add(this.Hienmatkhau);
            this.artanPanel1.Controls.Add(this.Thoat);
            this.artanPanel1.Controls.Add(this.btnDangNhap);
            this.artanPanel1.Controls.Add(this.label2);
            this.artanPanel1.Controls.Add(this.linkLabel2);
            this.artanPanel1.Controls.Add(this.linkLabel1);
            this.artanPanel1.Controls.Add(this.checkBox1);
            this.artanPanel1.Controls.Add(this.roundPictureBox3);
            this.artanPanel1.Controls.Add(this.matkhau);
            this.artanPanel1.Controls.Add(this.taikhoan);
            this.artanPanel1.Controls.Add(this.roundPictureBox2);
            this.artanPanel1.Controls.Add(this.roundPictureBox1);
            this.artanPanel1.Controls.Add(this.label1);
            this.artanPanel1.Font = new System.Drawing.Font(".VnTime", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artanPanel1.ForeColor = System.Drawing.Color.Black;
            this.artanPanel1.GradientBottomColor = System.Drawing.Color.White;
            this.artanPanel1.GradientTopColor = System.Drawing.Color.White;
            this.artanPanel1.Location = new System.Drawing.Point(785, 128);
            this.artanPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.artanPanel1.Name = "artanPanel1";
            this.artanPanel1.Size = new System.Drawing.Size(611, 723);
            this.artanPanel1.TabIndex = 0;
            this.artanPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.artanPanel1_Paint);
            // 
            // Hienmatkhau
            // 
            this.Hienmatkhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Hienmatkhau.AutoSize = true;
            this.Hienmatkhau.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Hienmatkhau.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hienmatkhau.Location = new System.Drawing.Point(189, 458);
            this.Hienmatkhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Hienmatkhau.Name = "Hienmatkhau";
            this.Hienmatkhau.Size = new System.Drawing.Size(164, 28);
            this.Hienmatkhau.TabIndex = 12;
            this.Hienmatkhau.Text = "Hiện mật khẩu";
            this.Hienmatkhau.UseVisualStyleBackColor = true;
            this.Hienmatkhau.CheckedChanged += new System.EventHandler(this.hienmatkhau_CheckedChanged);
            // 
            // Thoat
            // 
            this.Thoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Thoat.AutoSize = true;
            this.Thoat.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thoat.LinkColor = System.Drawing.Color.Red;
            this.Thoat.Location = new System.Drawing.Point(316, 640);
            this.Thoat.Name = "Thoat";
            this.Thoat.Size = new System.Drawing.Size(94, 36);
            this.Thoat.TabIndex = 11;
            this.Thoat.TabStop = true;
            this.Thoat.Text = "Thoát";
            this.Thoat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangNhap.BackColor = System.Drawing.Color.Silver;
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(237, 559);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(243, 67);
            this.btnDangNhap.TabIndex = 10;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bạn chưa có tài khoản?";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(403, 502);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(172, 32);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Đăng ký ngay";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(387, 434);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(205, 32);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên mật khẩu?";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(69, 458);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 28);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Ghi nhớ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // roundPictureBox3
            // 
            this.roundPictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roundPictureBox3.Image = global::DangNhap.Properties.Resources.Screenshot_2024_11_06_032508;
            this.roundPictureBox3.Location = new System.Drawing.Point(19, 352);
            this.roundPictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPictureBox3.Name = "roundPictureBox3";
            this.roundPictureBox3.Size = new System.Drawing.Size(83, 73);
            this.roundPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox3.TabIndex = 4;
            this.roundPictureBox3.TabStop = false;
            // 
            // matkhau
            // 
            this.matkhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.matkhau.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matkhau.ForeColor = System.Drawing.Color.Silver;
            this.matkhau.Location = new System.Drawing.Point(132, 374);
            this.matkhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.matkhau.Name = "matkhau";
            this.matkhau.Size = new System.Drawing.Size(460, 35);
            this.matkhau.TabIndex = 5;
            this.matkhau.Text = "Mật khẩu";
            this.matkhau.Enter += new System.EventHandler(this.matkhau_Enter);
            this.matkhau.Leave += new System.EventHandler(this.matkhau_Leave);
            this.matkhau.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.matkhau_PreviewKeyDown);
            // 
            // taikhoan
            // 
            this.taikhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.taikhoan.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taikhoan.ForeColor = System.Drawing.Color.Silver;
            this.taikhoan.Location = new System.Drawing.Point(132, 272);
            this.taikhoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.taikhoan.Name = "taikhoan";
            this.taikhoan.Size = new System.Drawing.Size(452, 35);
            this.taikhoan.TabIndex = 4;
            this.taikhoan.Text = "Tên đăng nhập";
            this.taikhoan.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.taikhoan.Enter += new System.EventHandler(this.taikhoan_Enter);
            this.taikhoan.Leave += new System.EventHandler(this.taikhoan_Leave);
            this.taikhoan.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.taikhoan_PreviewKeyDown);
            // 
            // roundPictureBox2
            // 
            this.roundPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roundPictureBox2.Image = global::DangNhap.Properties.Resources.Screenshot_2024_11_06_025526;
            this.roundPictureBox2.Location = new System.Drawing.Point(19, 257);
            this.roundPictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPictureBox2.Name = "roundPictureBox2";
            this.roundPictureBox2.Size = new System.Drawing.Size(82, 72);
            this.roundPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox2.TabIndex = 3;
            this.roundPictureBox2.TabStop = false;
            this.roundPictureBox2.Click += new System.EventHandler(this.roundPictureBox2_Click);
            // 
            // roundPictureBox1
            // 
            this.roundPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.roundPictureBox1.Image = global::DangNhap.Properties.Resources.Screenshot_2024_11_06_022205;
            this.roundPictureBox1.Location = new System.Drawing.Point(254, 103);
            this.roundPictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPictureBox1.Name = "roundPictureBox1";
            this.roundPictureBox1.Size = new System.Drawing.Size(115, 125);
            this.roundPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox1.TabIndex = 1;
            this.roundPictureBox1.TabStop = false;
            this.roundPictureBox1.Click += new System.EventHandler(this.roundPictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(141, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 108);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng Nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-5, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1401, 851);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(542, 675);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // roundPictureBox4
            // 
            this.roundPictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.roundPictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("roundPictureBox4.Image")));
            this.roundPictureBox4.Location = new System.Drawing.Point(163, 668);
            this.roundPictureBox4.Name = "roundPictureBox4";
            this.roundPictureBox4.Size = new System.Drawing.Size(156, 161);
            this.roundPictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox4.TabIndex = 2;
            this.roundPictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 850);
            this.Controls.Add(this.roundPictureBox4);
            this.Controls.Add(this.artanPanel1);
            this.Controls.Add(this.pictureBox1);
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.form1_Load);
            this.artanPanel1.ResumeLayout(false);
            this.artanPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ArtanComponent.ArtanPanel artanPanel1;
        private System.Windows.Forms.Label label1;
        private ArtanComponent.RoundPictureBox roundPictureBox1;
        private ArtanComponent.RoundPictureBox roundPictureBox2;
        private System.Windows.Forms.TextBox taikhoan;
        private System.Windows.Forms.TextBox matkhau;
        private ArtanComponent.RoundPictureBox roundPictureBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel Thoat;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox Hienmatkhau;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ArtanComponent.RoundPictureBox roundPictureBox4;
    }
}

