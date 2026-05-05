using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicsPackage
{
    public class BresenhamCircle
    {
        public List<StepData> Draw(int xc, int yc, int r, PixelCanvas canvas)
        {
            List<StepData> steps = new List<StepData>();

            int x = 0;
            int y = r;
            int p = 1 - r;
            int k = 0;

            PlotCirclePoints(xc, yc, x, y, canvas);

            while (x < y)
            {
                x++;

                if (p < 0)
                {
                    p += 2 * x + 1;
                }
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }

                PlotCirclePoints(xc, yc, x, y, canvas);

                steps.Add(new StepData
                {
                    K = k++,
                    P = p,
                    X = x,
                    Y = y,
                    TwoX = 2 * x,
                    TwoY = 2 * y
                });
            }

            return steps;
        }

        private void PlotCirclePoints(int xc, int yc, int x, int y, PixelCanvas canvas)
        {
            canvas.Plot(xc + x, yc + y);
            canvas.Plot(xc - x, yc + y);
            canvas.Plot(xc + x, yc - y);
            canvas.Plot(xc - x, yc - y);
            canvas.Plot(xc + y, yc + x);
            canvas.Plot(xc - y, yc + x);
            canvas.Plot(xc + y, yc - x);
            canvas.Plot(xc - y, yc - x);
        }
    }
}
