using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicsPackage
{
    public class BresenhamEllipse
    {
        public List<StepData> Draw(int xc, int yc, int Rx, int Ry, PixelCanvas canvas)
        {
            List<StepData> steps = new List<StepData>();

            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;

            int x = 0;
            int y = Ry;

            int px = 0;
            int py = twoRx2 * y;

            int k = 0;

            Plot(xc, yc, x, y, canvas);

            // REGION 1
            double p1 = Ry2 - (Rx2 * Ry) + (0.25 * Rx2);

            while (px < py)
            {
                x++;
                px += twoRy2;

                if (p1 < 0)
                {
                    p1 += Ry2 + px;
                }
                else
                {
                    y--;
                    py -= twoRx2;
                    p1 += Ry2 + px - py;
                }

                Plot(xc, yc, x, y, canvas);

                steps.Add(new StepData
                {
                    K = k++,
                    P1 = p1,
                    X = x,
                    Y = y,
                    TwoRy2X = px,
                    TwoRx2Y = py,
                    Rx2 = Rx2,
                    Ry2 = Ry2,
                    Region = "R1"
                });
            }

            // REGION 2
            double p2 = Ry2 * Math.Pow(x + 0.5, 2) +
                        Rx2 * Math.Pow(y - 1, 2) -
                        Rx2 * Ry2;

            while (y > 0)
            {
                y--;
                py -= twoRx2;

                if (p2 > 0)
                {
                    p2 += Rx2 - py;
                }
                else
                {
                    x++;
                    px += twoRy2;
                    p2 += Rx2 - py + px;
                }

                Plot(xc, yc, x, y, canvas);

                steps.Add(new StepData
                {
                    K = k++,
                    P2 = p2,
                    X = x,
                    Y = y,
                    TwoRy2X = px,
                    TwoRx2Y = py,
                    Rx2 = Rx2,
                    Ry2 = Ry2,
                    Region = "R2"
                });
            }

            return steps;
        }

        private void Plot(int xc, int yc, int x, int y, PixelCanvas canvas)
        {
            canvas.Plot(xc + x, yc + y);
            canvas.Plot(xc - x, yc + y);
            canvas.Plot(xc + x, yc - y);
            canvas.Plot(xc - x, yc - y);
        }
    }
}