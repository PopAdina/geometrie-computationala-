using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace seminar10ex1
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private List<Point> points = new List<Point>();
        private List<List<Point>> monotonePolygons = new List<List<Point>>();

        public Form1()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            // Desenează poligonul și triunghiurile
            DrawPolygon(g);
            DrawMonotonePolygons(g);
            DrawTriangulation(g);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);
                panel1.Invalidate(); // Desenează din nou panoul
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Închide poligonul și împarte-l în poligoane monotone
               // ClosePolygonAndPartition();
                panel1.Invalidate(); // Desenează din nou panoul
            }
        }

        private void DrawPolygon(Graphics g)
        {
            if (points.Count > 1)
            {
                g.DrawPolygon(Pens.Black, points.ToArray());
            }
        }

        private void DrawMonotonePolygons(Graphics g)
        {
            foreach (var polygon in monotonePolygons)
            {
                g.DrawPolygon(Pens.Red, polygon.ToArray());
            }
        }

        private void DrawTriangulation(Graphics g)
        {
            // Desenează triunghiurile pentru fiecare poligon monoton
            foreach (var polygon in monotonePolygons)
            {
                // Implementați algoritmul de triangulare liniară aici
               // List<Point> triangles = TriangulateMonotonePolygon(polygon);
               // foreach (var triangle in triangles)
                {
                    g.DrawPolygon(Pens.Blue, points.ToArray());
                }
            }
        }

        private List<int> FindSplitPoints(List<Point> polygon)
        {
            List<int> splitPoints = new List<int>();

            for (int i = 1; i < polygon.Count - 1; i++)
            {
                if (IsConvexVertex(polygon, i))
                {
                    splitPoints.Add(i);
                }
            }

            return splitPoints;
        }

        private bool IsConvexVertex(List<Point> polygon, int i)
        {
            int prev = (i == 0) ? polygon.Count - 2 : i - 1; // Indicele punctului anterior
            int next = (i + 1) % (polygon.Count - 1); // Indicele punctului următor

            int val = (polygon[i].X - polygon[prev].X) * (polygon[next].Y - polygon[i].Y) -
                      (polygon[i].Y - polygon[prev].Y) * (polygon[next].X - polygon[i].X);

            return val > 0; // Verificăm dacă forma vârfului este convexă
        }

        private List<List<Point>> PartitionIntoMonotonePolygons(List<Point> polygon)
        {
            List<List<Point>> monotonePolygons = new List<List<Point>>();

            List<int> splitPoints = FindSplitPoints(polygon);

            splitPoints.Insert(0, 0); // Adăugăm începutul poligonului ca punct de divizare
            splitPoints.Add(polygon.Count - 1); // Adăugăm sfârșitul poligonului ca punct de divizare

            splitPoints.Sort(); // Sortăm punctele de divizare

            Stack<Point> stack = new Stack<Point>();

            for (int i = 0; i < splitPoints.Count - 1; i++)
            {
                List<Point> subPolygon = polygon.GetRange(splitPoints[i], splitPoints[i + 1] - splitPoints[i] + 1);

                foreach (Point vertex in subPolygon)
                {
                    while (stack.Count >= 2 && !IsMonotone(stack, vertex))
                    {
                        monotonePolygons.Add(new List<Point>(stack.Reverse()));
                        stack.Clear();
                        stack.Push(vertex);
                    }

                    stack.Push(vertex);
                }
            }

            while (stack.Count > 0)
            {
                monotonePolygons.Add(new List<Point>(stack.Reverse()));
                stack.Clear();
            }

            return monotonePolygons;
        }

        private bool IsMonotone(Stack<Point> stack, Point vertex)
        {
            if (stack.Count < 2)
                return true;

            Point top = stack.Pop();
            Point nextToTop = stack.Peek();
            stack.Push(top);

            if (nextToTop.Y > top.Y && vertex.Y > top.Y)
                return true;

            if (nextToTop.Y < top.Y && vertex.Y < top.Y)
                return true;

            return false;
        }

        private List<Point> TriangulateMonotoneSubPolygon(List<Point> subPolygon)
        {
            List<Point> triangles = new List<Point>();

            Stack<Point> stack = new Stack<Point>();

            for (int i = 0; i < subPolygon.Count; i++)
            {
                while (stack.Count >= 2 && !IsConvex(subPolygon, stack, i))
                {
                    Point top = stack.Pop();
                    Point nextToTop = stack.Peek();
                    triangles.Add(subPolygon[i]);
                    triangles.Add(top);
                    triangles.Add(nextToTop);
                }

                stack.Push(subPolygon[i]);
            }

            return triangles;
        }

        private bool IsConvex(List<Point> subPolygon, Stack<Point> stack, int i)
        {
            if (stack.Count < 2)
                return true;

            Point top = stack.Pop();
            Point nextToTop = stack.Peek();
            stack.Push(top);

            int val = (subPolygon[i].X - top.X) * (nextToTop.Y - top.Y) -
                      (subPolygon[i].Y - top.Y) * (nextToTop.X - top.X);

            return val > 0; // Verificăm dacă forma vârfului este convexă
        }
    }
}
