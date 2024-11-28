using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C1___Geometrie_Vectoriala
{
    internal class MyGraphics
    {
        Bitmap bmp;
        PictureBox display;
        Color bkColor = Color.GhostWhite;

        public Graphics g;
        public int resX, resY;

        // ---------------------------------------------

        public MyGraphics(PictureBox display)
        {
            this.display = display;
            this.bmp = new Bitmap(display.Width, display.Height);
            g = Graphics.FromImage(bmp);

            resX = display.Width;
            resY = display.Height;

            ClearGraphics();
            RefreshGraphics();
        }

        public void ClearGraphics()
        {
            g.Clear(bkColor);
        }

        public void RefreshGraphics()
        {
            this.display.Image = bmp;
        }
    }
}
