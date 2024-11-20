namespace DangNhap
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.artanPanel1 = new ArtanComponent.ArtanPanel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.TextBox();
            this.nhaplaimatkhau = new System.Windows.Forms.TextBox();
            this.matkhau = new System.Windows.Forms.TextBox();
            this.tendanhnhap = new System.Windows.Forms.TextBox();
            this.roundPictureBox1 = new ArtanComponent.RoundPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1395, 851);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // artanPanel1
            // 
            this.artanPanel1.AllowDrop = true;
            this.artanPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.artanPanel1.AutoScroll = true;
            this.artanPanel1.AutoScrollMinSize = new System.Drawing.Size(100, 100);
            this.artanPanel1.AutoSize = true;
            this.artanPanel1.BackColor = System.Drawing.Color.White;
            this.artanPanel1.BorderAngle = 90F;
            this.artanPanel1.BorderRadius = 40;
            this.artanPanel1.Controls.Add(this.roundPictureBox1);
            this.artanPanel1.Controls.Add(this.label1);
            this.artanPanel1.Controls.Add(this.linkLabel2);
            this.artanPanel1.Controls.Add(this.label2);
            this.artanPanel1.Controls.Add(this.btnDangNhap);
            this.artanPanel1.Controls.Add(this.email);
            this.artanPanel1.Controls.Add(this.nhaplaimatkhau);
            this.artanPanel1.Controls.Add(this.matkhau);
            this.artanPanel1.Controls.Add(this.tendanhnhap);
            this.artanPanel1.Font = new System.Drawing.Font(".VnTime", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artanPanel1.ForeColor = System.Drawing.Color.Black;
            this.artanPanel1.GradientBottomColor = System.Drawing.Color.White;
            this.artanPanel1.GradientTopColor = System.Drawing.Color.White;
            this.artanPanel1.Location = new System.Drawing.Point(740, 182);
            this.artanPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.artanPanel1.Name = "artanPanel1";
            this.artanPanel1.Size = new System.Drawing.Size(656, 669);
            this.artanPanel1.TabIndex = 2;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(356, 569);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(204, 32);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Đăng nhập ngay";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 573);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 28);
            this.label2.TabIndex = 20;
            this.label2.Text = "Bạn đã có tài khoản";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(219, 481);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(243, 67);
            this.btnDangNhap.TabIndex = 19;
            this.btnDangNhap.Text = "ĐĂNG KÝ NGAY";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            // 
            // email
            // 
            this.email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.email.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.Color.Silver;
            this.email.Location = new System.Drawing.Point(122, 420);
            this.email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(452, 35);
            this.email.TabIndex = 18;
            this.email.Text = "Email";
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nhaplaimatkhau
            // 
            this.nhaplaimatkhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nhaplaimatkhau.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhaplaimatkhau.ForeColor = System.Drawing.Color.Silver;
            this.nhaplaimatkhau.Location = new System.Drawing.Point(122, 356);
            this.nhaplaimatkhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nhaplaimatkhau.Name = "nhaplaimatkhau";
            this.nhaplaimatkhau.Size = new System.Drawing.Size(452, 35);
            this.nhaplaimatkhau.TabIndex = 17;
            this.nhaplaimatkhau.Text = "Nhập lại mật khẩu";
            this.nhaplaimatkhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // matkhau
            // 
            this.matkhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.matkhau.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matkhau.ForeColor = System.Drawing.Color.Silver;
            this.matkhau.Location = new System.Drawing.Point(122, 293);
            this.matkhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.matkhau.Name = "matkhau";
            this.matkhau.Size = new System.Drawing.Size(452, 35);
            this.matkhau.TabIndex = 16;
            this.matkhau.Text = "Mật khẩu";
            this.matkhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tendanhnhap
            // 
            this.tendanhnhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tendanhnhap.AutoCompleteCustomSource.AddRange(new string[] {
            "Ten"});
            this.tendanhnhap.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendanhnhap.ForeColor = System.Drawing.Color.Silver;
            this.tendanhnhap.Location = new System.Drawing.Point(122, 235);
            this.tendanhnhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tendanhnhap.Name = "tendanhnhap";
            this.tendanhnhap.Size = new System.Drawing.Size(452, 35);
            this.tendanhnhap.TabIndex = 15;
            this.tendanhnhap.Text = "Tên đăng nhập";
            this.tendanhnhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // roundPictureBox1
            // 
            this.roundPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roundPictureBox1.Image = global::DangNhap.Properties.Resources.Screenshot_2024_11_06_022205;
            this.roundPictureBox1.Location = new System.Drawing.Point(267, 85);
            this.roundPictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPictureBox1.Name = "roundPictureBox1";
            this.roundPictureBox1.Size = new System.Drawing.Size(142, 132);
            this.roundPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox1.TabIndex = 14;
            this.roundPictureBox1.TabStop = false;
            this.roundPictureBox1.Click += new System.EventHandler(this.roundPictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 108);
            this.label1.TabIndex = 22;
            this.label1.Text = "Đăng Ký Tài Khoản";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 850);
            this.Controls.Add(this.artanPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Đăng Ký";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.artanPanel1.ResumeLayout(false);
            this.artanPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ArtanComponent.ArtanPanel artanPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox nhaplaimatkhau;
        private System.Windows.Forms.TextBox matkhau;
        private System.Windows.Forms.TextBox tendanhnhap;
        private ArtanComponent.RoundPictureBox roundPictureBox1;
    }
}