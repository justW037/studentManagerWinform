using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    class RoundedCorner
    {
        public static void DrawRoundedCornerControl(Control control, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int borderRadius = 10; // Độ cong của góc
            int width = control.Width;
            int height = control.Height;

            if (control.GetType() == typeof(Panel) || control.GetType().IsSubclassOf(typeof(Panel)))
            {
                int minSize = Math.Min(width, height);
                int radius = Math.Min(borderRadius, minSize / 2);
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(width - radius * 2, height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(0, height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseFigure();
            }
            else if (control.GetType() == typeof(Button) || control.GetType().IsSubclassOf(typeof(Button)))
            {
                int borderRadiusBtn = 5; // Độ cong của góc cho Button
                int minSize = Math.Min(width, height);
                int radius = Math.Min(borderRadiusBtn, minSize / 2);
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(width - radius * 2, height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(0, height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseFigure();
            }

            Region region = new Region(path);
            control.Region = region;

            using (SolidBrush brush = new SolidBrush(control.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }
    }
}
