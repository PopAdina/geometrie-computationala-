using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace seminar9ex1
{
    public partial class Form1 : Form
    {
        /*Partiționarea unui poligon simplu în poligoane monotone, prin identificarea
vârfurilor de întoarcere și unirea acestora prin diagonale cu vârfurile
corespunzătoare.*/

        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        List<Point> points = new List<Point>();

        int contor = 1;
        bool drawingMode = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (drawingMode)
            {
                Pen pen = new Pen(Color.Black, 3);
                Point aux = new Point(e.X, e.Y);
                Pen linie = new Pen(Color.DarkViolet, 2);
                g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
                contor++;
                g.DrawEllipse(pen, aux.X - 2, aux.Y - 2, 4, 4);
                if (points.Count != 0)
                {
                    g.DrawLine(linie, aux, points[points.Count - 1]);
                }
                points.Add(aux);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!drawingMode)
            {
                drawingMode = true;
                button1.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (drawingMode)
            {
                Graphics g = panel1.CreateGraphics();
                Pen linie = new Pen(Color.DarkViolet, 2);
                g.DrawLine(linie, points[0], points[points.Count - 1]);
                button2.Enabled = false;
                drawingMode = false;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                List<Triangle> triangles = Triangulate(points);
                DrawTriangles(triangles);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Triangle> Triangulate(List<Point> points)
        {
            List<Triangle> triangles = new List<Triangle>();
            List<Point> remainingPoints = new List<Point>(points);

            int maxIterations = remainingPoints.Count * remainingPoints.Count;  // Limita maximă de iterații
            int iteration = 0;

            while (remainingPoints.Count > 3 && iteration < maxIterations)
            {
                bool earFound = false;
                for (int i = 0; i < remainingPoints.Count; i++)
                {
                    int prev = (i - 1 + remainingPoints.Count) % remainingPoints.Count;
                    int next = (i + 1) % remainingPoints.Count;

                    if (IsEar(remainingPoints, prev, i, next))
                    {
                        triangles.Add(new Triangle(remainingPoints[prev], remainingPoints[i], remainingPoints[next]));
                        remainingPoints.RemoveAt(i);
                        earFound = true;
                        break;
                    }
                }

                if (!earFound)
                {
                    // Nu a găsit nici o ureche, marcăm o problemă pentru depanare
                    Console.WriteLine("Nu s-a găsit nici o ureche la iterația " + iteration);
                    Console.WriteLine("Punctele rămase: " + string.Join(", ", remainingPoints));
                    throw new InvalidOperationException("Poligonul nu poate fi triangulat.");
                }

                iteration++;
            }

            if (remainingPoints.Count == 3)
            {
                triangles.Add(new Triangle(remainingPoints[0], remainingPoints[1], remainingPoints[2]));
            }

            return triangles;
        }

        private bool IsEar(List<Point> points, int prev, int i, int next)
        {
            Point a = points[prev];
            Point b = points[i];
            Point c = points[next];

            // Verifică dacă triunghiul (a, b, c) este orientat în sensul acelor de ceasornic
            if (CrossProduct(a, b, c) >= 0)
            {
                Console.WriteLine($"Triunghiul ({prev}, {i}, {next}) nu este orientat în sensul acelor de ceasornic.");
                return false;
            }

            // Verifică dacă vreun alt punct din poligon se află în interiorul triunghiului (a, b, c)
            for (int j = 0; j < points.Count; j++)
            {
                if (j == prev || j == i || j == next)
                {
                    continue;
                }

                if (IsPointInTriangle(a, b, c, points[j]))
                {
                    Console.WriteLine($"Punctul {j} se află în interiorul triunghiului ({prev}, {i}, {next}).");
                    return false;
                }
            }

            return true;
        }

        private bool IsPointInTriangle(Point a, Point b, Point c, Point p)
        {
            float d1 = Sign(p, a, b);
            float d2 = Sign(p, b, c);
            float d3 = Sign(p, c, a);

            bool has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        private float Sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private int CrossProduct(Point a, Point b, Point c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }

        private void DrawTriangles(List<Triangle> triangles)
        {
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Blue, 2);
            foreach (var triangle in triangles)
            {
                g.DrawLine(pen, triangle.A, triangle.B);
                g.DrawLine(pen, triangle.B, triangle.C);
                g.DrawLine(pen, triangle.C, triangle.A);
            }
        }

        public class Triangle
        {
            public Point A { get; }
            public Point B { get; }
            public Point C { get; }

            public Triangle(Point a, Point b, Point c)
            {
                A = a;
                B = b;
                C = c;
            }
        }
    }
}
