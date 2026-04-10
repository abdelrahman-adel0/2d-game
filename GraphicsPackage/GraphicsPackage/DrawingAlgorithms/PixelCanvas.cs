using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//wrapper class to enhance reusability and maintainability as well as center our graphs in the drawing panels

namespace GraphicsPackage
{
    public class PixelCanvas
    {
        private Graphics g;
        private int scale;
        private int centerX;
        private int centerY;
        private Brush brush;
        public PixelCanvas(Graphics graphics, int width, int height, int scale , Color color)
        {
            g = graphics;
            this.scale = scale;

            // Set origin to center of panel
            centerX = width / 2;
            centerY = height / 2;

            brush = new SolidBrush(color);
        }

        public void Plot(int x, int y)
        {
            // Convert math coordinates to screen coordinatess
            int screenX = centerX + x * scale;
            int screenY = centerY - y * scale;

            g.FillRectangle( brush , screenX, screenY, scale, scale);
        }

        public void DrawAxes(int width, int height)
        {
            Pen axisPen = new Pen(Color.Gray, 1);

            // X axis
            g.DrawLine(axisPen, 0, centerY, width, centerY);

            // Y axis
            g.DrawLine(axisPen, centerX, 0, centerX, height);
        }
        public void DrawGrid(int width, int height)
        {
            Pen gridPen = new Pen(Color.LightGray, 1);

            for (int x = centerX; x < width; x += scale)
                g.DrawLine(gridPen, x, 0, x, height);

            for (int x = centerX; x > 0; x -= scale)
                g.DrawLine(gridPen, x, 0, x, height);

            for (int y = centerY; y < height; y += scale)
                g.DrawLine(gridPen, 0, y, width, y);

            for (int y = centerY; y > 0; y -= scale)
                g.DrawLine(gridPen, 0, y, width, y);
        }
    }
}
