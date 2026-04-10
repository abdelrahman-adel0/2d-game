using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;


namespace GraphicsPackage
{
    public class DDALine
    {
        public List<StepData> Draw(int x0, int y0, int xEnd, int yEnd, PixelCanvas canvas)
        {
            List<StepData> stepsList = new List<StepData>();

            int dx = xEnd - x0;
            int dy = yEnd - y0;

            //math.abs instead of c's fabs
            int steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            float xInc = dx / (float)steps;
            float yInc = dy / (float)steps;

            float x = x0;
            float y = y0;

            for (int k = 0; k <= steps; k++)
            {
                int xr = (int)Math.Round(x);
                int yr = (int)Math.Round(y);

                canvas.Plot(xr, yr);

                stepsList.Add(new StepData
                {
                    K = k,
                    X = x,
                    Y = y,
                    XRounded = xr,
                    YRounded = yr
                });

                x += xInc;
                y += yInc;
            }

            return stepsList;
        }
    }
}