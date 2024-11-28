using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyApp.CustomControls
{
    public class RoundPictureBox : PictureBox
    {
        public int BorderRadius { get; set; } = 20; // Độ cong của góc
        public Color BorderColor { get; set; } = Color.Black; // Màu viền
        public int BorderSize { get; set; } = 5; // Độ dày viền

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Graphics để vẽ
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Vẽ vùng ảnh bo góc
            Rectangle innerRect = new Rectangle(
                BorderSize,
                BorderSize,
                this.Width - 2 * BorderSize,
                this.Height - 2 * BorderSize);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(innerRect.X, innerRect.Y, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(innerRect.Right - BorderRadius, innerRect.Y, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(innerRect.Right - BorderRadius, innerRect.Bottom - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(innerRect.X, innerRect.Bottom - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            // Vẽ hình ảnh bên trong
            if (this.Image != null)
            {
                Rectangle imageRect = new Rectangle(
                    BorderSize,
                    BorderSize,
                    this.Width - 2 * BorderSize,
                    this.Height - 2 * BorderSize);
                pe.Graphics.SetClip(path); // Giới hạn vùng vẽ hình ảnh
                pe.Graphics.DrawImage(this.Image, imageRect);
            }

            // Vẽ viền bên ngoài
            if (BorderSize > 0)
            {
                using (Pen pen = new Pen(BorderColor, BorderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    pe.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
