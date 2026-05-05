using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GraphicsPackage.Forms
{
    public partial class DrawingForm : Form
    {
        private Bitmap canvasBitmap;
        private Color currentColor = Color.Black;
        private List<StepData> lastSteps = new List<StepData>();
        private string lastAlgorithm = "";
        private bool colorChosen = false;
        private Bitmap lastShapeBitmap;

        public DrawingForm()
        {
            InitializeComponent();
            canvasBitmap = new Bitmap(drawPanel.Width, drawPanel.Height);
            drawPanel.BackgroundImage = canvasBitmap;
            drawPanel.BackgroundImageLayout = ImageLayout.None;

            cmbAlgorithm.SelectedIndexChanged += cmbAlgorithm_SelectedIndexChanged;
            drawPanel.Paint += drawPanel_Paint;

            UpdateInputVisibility();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (drawPanel.Width > 0 && drawPanel.Height > 0)
            {
                canvasBitmap = new Bitmap(drawPanel.Width, drawPanel.Height);
                drawPanel.BackgroundImage = canvasBitmap;
            }
        }
        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            if (canvasBitmap != null)
            {
                e.Graphics.DrawImage(canvasBitmap, 0, 0);
            }
            Graphics g = e.Graphics;
            // Create a temporary canvas JUST for axes/grid
            PixelCanvas canvas = new PixelCanvas(
                g,
                drawPanel.Width,
                drawPanel.Height,
                5,
                currentColor
            );

            // Always draw grid + axes
            canvas.DrawGrid(drawPanel.Width, drawPanel.Height);
            canvas.DrawAxes(drawPanel.Width, drawPanel.Height);

            // Then draw shapes (bitmap) ON TOP
            if (canvasBitmap != null)
            {
                g.DrawImage(canvasBitmap, 0, 0);
            }
        }
        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInputVisibility();
        }
        private void UpdateInputVisibility()
        {
            string algo = cmbAlgorithm.SelectedItem?.ToString();

            // Disable all first
            SetLineInputs(false);
            SetCircleInputs(false);
            SetEllipseInputs(false);

            if (algo == "Line DDA" || algo == "Line Bresenham")
                SetLineInputs(true);
            else if (algo == "Circle Bresenham")
                SetCircleInputs(true);
            else if (algo == "Ellipse Bresenham")
                SetEllipseInputs(true);
        }

        private void SetLineInputs(bool visible)
        {
            txtX0.Enabled = visible;
            txtY0.Enabled = visible;
            txtXEnd.Enabled = visible;
            txtYEnd.Enabled = visible;
        }

        private void SetCircleInputs(bool visible)
        {
            txtXcC.Enabled = visible;
            txtYcC.Enabled = visible;
            txtRadius.Enabled = visible;
        }

        private void SetEllipseInputs(bool visible)
        {
            txtXcE.Enabled = visible;
            txtYcE.Enabled = visible;
            txtRx.Enabled = visible;
            txtRy.Enabled = visible;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (canvasBitmap != null)
            {
                using (Graphics g = Graphics.FromImage(canvasBitmap))
                {
                    g.Clear(Color.Transparent);
                }
            }

            grid.Rows.Clear();
            drawPanel.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (canvasBitmap == null) return;
            if (!colorChosen)
            {
                currentColor = Color.Black;
            }


            using (Graphics g = Graphics.FromImage(canvasBitmap))
            using (Graphics gLast = Graphics.FromImage(
                lastShapeBitmap = new Bitmap(drawPanel.Width, drawPanel.Height)))
            {
                //g.Clear(drawPanel.BackColor);

                PixelCanvas canvas = new PixelCanvas(g, drawPanel.Width, drawPanel.Height, 3, currentColor);
                PixelCanvas canvasLast = new PixelCanvas(gLast,drawPanel.Width,drawPanel.Height,3,currentColor);
                grid.Rows.Clear();

                string algo = cmbAlgorithm.SelectedItem?.ToString();

                try
                {
                    if (algo == "Line DDA")
                    {
                        int x0 = int.Parse(txtX0.Text);
                        int y0 = int.Parse(txtY0.Text);
                        int x1 = int.Parse(txtXEnd.Text);
                        int y1 = int.Parse(txtYEnd.Text);

                        var algoObj = new DDALine();
                        var steps = algoObj.Draw(x0, y0, x1, y1, canvas);
                        algoObj.Draw(x0, y0, x1, y1, canvasLast);

                        lastSteps = steps;
                        lastAlgorithm = algo;

                        foreach (var s in steps)
                        {
                            grid.Rows.Add(
                                s.K,
                                "-",
                                s.X,
                                s.Y,
                                $"({s.XRounded},{s.YRounded})",
                                "-", "-", "-", "-", "-", "-", "-"
                            );
                        }
                    }
                    else if (algo == "Line Bresenham")
                    {
                        int x0 = int.Parse(txtX0.Text);
                        int y0 = int.Parse(txtY0.Text);
                        int x1 = int.Parse(txtXEnd.Text);
                        int y1 = int.Parse(txtYEnd.Text);

                        var algoObj = new BresenhamLine();
                        var steps = algoObj.Draw(x0, y0, x1, y1, canvas);
                        algoObj.Draw(x0, y0, x1, y1, canvasLast);
                        lastSteps = steps;
                        lastAlgorithm = algo;

                        foreach (var s in steps)
                        {
                            grid.Rows.Add(
                                s.K,
                                s.P,
                                s.X,
                                s.Y,
                                $"({s.X},{s.Y})",
                                "-", "-", "-",
                                "-", "-", "-", "-"
                            );
                        }
                    }
                    else if (algo == "Circle Bresenham")
                    {
                        int xc = int.Parse(txtXcC.Text);
                        int yc = int.Parse(txtYcC.Text);
                        int r = int.Parse(txtRadius.Text);

                        var algoObj = new BresenhamCircle();
                        var steps = algoObj.Draw(xc, yc, r, canvas);
                        algoObj.Draw(xc,yc,r, canvasLast);

                        lastSteps = steps;
                        lastAlgorithm = algo;

                        foreach (var s in steps)
                        {
                            grid.Rows.Add(
                                s.K,
                                s.P,
                                s.X,
                                s.Y,
                                $"({s.X},{s.Y})",
                                s.TwoX, s.TwoY,
                                "-", "-", "-", "-", "-"
                            );
                        }
                    }
                    else if (algo == "Ellipse Bresenham")
                    {
                        int xc = int.Parse(txtXcE.Text);
                        int yc = int.Parse(txtYcE.Text);
                        int rx = int.Parse(txtRx.Text);
                        int ry = int.Parse(txtRy.Text);

                        var algoObj = new BresenhamEllipse();
                        var steps = algoObj.Draw(xc, yc, rx, ry, canvas);
                        algoObj.Draw(xc,yc,rx,ry, canvasLast);

                        lastSteps = steps;
                        lastAlgorithm = algo;

                        foreach (var s in steps)
                        {
                            grid.Rows.Add(
                                s.K,
                                "-",
                                s.X,
                                s.Y,
                                $"({s.X},{s.Y})",
                                 "-", "-",
                                s.P1,
                                s.P2,
                                s.TwoRx2Y,
                                s.TwoRy2X,
                                s.Region
                            );
                        }
                    }

                    drawPanel.Invalidate();
                }
                catch
                {
                    MessageBox.Show("Invalid or missing inputs.");
                }
                colorChosen = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnColour_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    currentColor = dlg.Color;
                    colorChosen = true;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lastSteps == null || lastSteps.Count == 0)
            {
                MessageBox.Show("Nothing to save.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "HTML Files (*.html)|*.html";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string imgPath = System.IO.Path.ChangeExtension(sfd.FileName, ".png");

            // Save image
            if (lastShapeBitmap != null)
                lastShapeBitmap.Save(imgPath);

            // Build HTML
            string html = @"
<html>
<head>
    <style>
        body {
            font-family: Arial;
            margin: 40px;
            background-color: #f9f9f9;
        }
        h1, h2 {
            text-align: center;
        }
        img {
            display: block;
            margin: 20px auto;
            border: 1px solid #ccc;
        }
        table {
            border-collapse: collapse;
            margin: 20px auto;
            width: 80%;
            background: white;
        }
        th, td {
            border: 1px solid #999;
            padding: 8px;
            text-align: center;
        }
        th {
            background-color: #333;
            color: white;
        }
        tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        .section {
            margin-bottom: 40px;
        }
    </style>
</head>
<body>
";

            html += $"<h1>Graphics Algorithm Report</h1>";
            html += $"<h2>{lastAlgorithm}</h2>";

            html += "<div class='section'>";
            html += "<h2>Graph Output</h2>";
            html += $"<img src='{System.IO.Path.GetFileName(imgPath)}' width='600'/>";
            html += "</div>";

            html += "<div class='section'>";
            html += "<h2>Computation Steps</h2>";
            html += "<table><tr>";
            // Headers based on algorithm
            html += "<tr>";

            if (lastAlgorithm == "Line DDA")
                html += "<th>K</th><th>X</th><th>Y</th><th>Rounded</th>";
            else if (lastAlgorithm == "Line Bresenham")
                html += "<th>K</th><th>P</th><th>X</th><th>Y</th>";
            else if (lastAlgorithm == "Circle Bresenham")
                html += "<th>K</th><th>P</th><th>X</th><th>Y</th><th>2X</th><th>2Y</th>";
            else if (lastAlgorithm == "Ellipse Bresenham")
                html += "<th>K</th><th>P</th><th>X</th><th>Y</th><th>Region</th>";

            html += "</tr>";

            // Rows
            foreach (var s in lastSteps)
            {
                html += "<tr>";

                if (lastAlgorithm == "Line DDA")
                    html += $"<td>{s.K}</td><td>{s.X:F2}</td><td>{s.Y:F2}</td><td>({s.XRounded},{s.YRounded})</td>";

                else if (lastAlgorithm == "Line Bresenham")
                    html += $"<td>{s.K}</td><td>{s.P}</td><td>{s.X}</td><td>{s.Y}</td>";

                else if (lastAlgorithm == "Circle Bresenham")
                    html += $"<td>{s.K}</td><td>{s.P}</td><td>{s.X}</td><td>{s.Y}</td><td>{s.TwoX}</td><td>{s.TwoY}</td>";

                else if (lastAlgorithm == "Ellipse Bresenham")
                    html += $"<td>{s.K}</td><td>{s.P}</td><td>{s.X}</td><td>{s.Y}</td><td>{s.Region}</td>";

                html += "</tr>";
            }

            html += "</table></div></body></html>";

            System.IO.File.WriteAllText(sfd.FileName, html);

            MessageBox.Show("Saved successfully.");
        }
    }

}

