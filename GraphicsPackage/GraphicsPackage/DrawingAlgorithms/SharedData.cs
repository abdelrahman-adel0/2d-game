using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// get data needed for the form's result table 

namespace GraphicsPackage
{
    public class StepData
    {
        public int K { get; set; }

        // Common
        public double? P { get; set; }

        // Coordinates
        public double X { get; set; }
        public double Y { get; set; }

        // DDA
        public int? XRounded { get; set; }
        public int? YRounded { get; set; }

        // Circle
        public int? TwoX { get; set; }
        public int? TwoY { get; set; }

        // Ellipse
        public double? P1 { get; set; }
        public double? P2 { get; set; }
        public double? TwoRy2X { get; set; }
        public double? TwoRx2Y { get; set; }
        public int? Rx2 { get; set; }
        public int? Ry2 { get; set; }
        public string Region { get; set; }
    }
}