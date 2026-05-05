using System;
using GraphicsPackage;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        TestDDA();
        TestBresenhamLine();
        TestCircle();
        TestEllipse();

        Console.WriteLine("\nAll tests executed.");
        Console.ReadLine();
    }

    // ---------------- DDA ----------------
    static void TestDDA()
    {
        Console.WriteLine("\n=== DDA Line Test ===");

        var canvas = new TestCanvas();
        var dda = new DDALine();

        var steps = dda.Draw(2, 2, 10, 6, canvas);

        PrintSteps(steps);
        PrintPoints(canvas.Points);
    }

    // ---------------- Bresenham Line ----------------
    static void TestBresenhamLine()
    {
        Console.WriteLine("\n=== Bresenham Line Test ===");

        var canvas = new TestCanvas();
        var line = new BresenhamLine();

        var steps = line.Draw(2, 2, 10, 6, canvas);

        PrintSteps(steps);
        PrintPoints(canvas.Points);
    }

    // ---------------- Circle ----------------
    static void TestCircle()
    {
        Console.WriteLine("\n=== Bresenham Circle Test ===");

        var canvas = new TestCanvas();
        var circle = new BresenhamCircle();

        var steps = circle.Draw(0, 0, 5, canvas);

        PrintSteps(steps);
        PrintPoints(canvas.Points);
    }

    // ---------------- Ellipse ----------------
    static void TestEllipse()
    {
        Console.WriteLine("\n=== Bresenham Ellipse Test ===");

        var canvas = new TestCanvas();
        var ellipse = new BresenhamEllipse();

        var steps = ellipse.Draw(0, 0, 6, 4, canvas);

        PrintSteps(steps);
        PrintPoints(canvas.Points);
    }

    // ---------------- Helpers ----------------
    static void PrintSteps(List<StepData> steps)
    {
        foreach (var s in steps)
        {
            Console.WriteLine(
                $"k={s.K}, P={s.P}, X={s.X}, Y={s.Y}, XR={s.XRounded}, YR={s.YRounded}, Region={s.Region}"
            );
        }
    }

    static void PrintPoints(List<System.Drawing.Point> points)
    {
        Console.WriteLine("\nPlotted Points:");
        foreach (var p in points)
        {
            Console.WriteLine($"({p.X}, {p.Y})");
        }
    }
}