using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicsPackage
{
    public class BresenhamLine
    {
        public List<StepData> Draw(int x0, int y0, int x1, int y1, PixelCanvas canvas)
        {
            List<StepData> steps = new List<StepData>();

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            int sx = (x1 >= x0) ? 1 : -1;
            int sy = (y1 >= y0) ? 1 : -1;

            int x = x0;
            int y = y0;
            int k = 0;

            canvas.Plot(x, y);

            // CASE 1: slope <= 1
            if (dx >= dy)
            {
                int p = 2 * dy - dx;

                while (x != x1)
                {
                    x += sx;

                    if (p < 0)
                    {
                        p += 2 * dy;
                    }
                    else
                    {
                        y += sy;
                        p += 2 * (dy - dx);
                    }

                    canvas.Plot(x, y);

                    steps.Add(new StepData
                    {
                        K = k++,
                        P = p,
                        X = x,
                        Y = y
                    });
                }
            }
            // CASE 2: slope > 1
            else
            {
                int p = 2 * dx - dy;

                while (y != y1)
                {
                    y += sy;

                    if (p < 0)
                    {
                        p += 2 * dx;
                    }
                    else
                    {
                        x += sx;
                        p += 2 * (dx - dy);
                    }

                    canvas.Plot(x, y);

                    steps.Add(new StepData
                    {
                        K = k++,
                        P = p,
                        X = x,
                        Y = y
                    });
                }
            }

            return steps;
        }
    }
}
