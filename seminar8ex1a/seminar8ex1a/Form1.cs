using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace seminar8ex1a
{
    /*a) Triangularea unui poligon simplu cu n>3 vârfuri prin metoda eliminării urechilor
(otectomie).*/
    public partial class Form1 : Form
    {
        private List<PointF> points;
        private List<Triangle> triangles;

        public Form1()
        {
            InitializeComponent();
            points = new List<PointF>();
            triangles = new List<Triangle>();
        }

        private void panelDraw_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            panelDraw.Invalidate();
        }

        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            if (points.Count > 1)
            {
                e.Graphics.DrawPolygon(Pens.Black, points.ToArray());
            }

            foreach (var triangle in triangles)
            {
                e.Graphics.DrawLine(Pens.Red, triangle.A, triangle.B);
                e.Graphics.DrawLine(Pens.Red, triangle.B, triangle.C);
                e.Graphics.DrawLine(Pens.Red, triangle.C, triangle.A);
            }
        }

        private void btnTriangulate_Click(object sender, EventArgs e)
        {
            if (points.Count > 3)
            {
                TriangulatePolygon();
                listBoxTriangles.Items.Clear();
                foreach (var triangle in triangles)
                {
                    listBoxTriangles.Items.Add(triangle);
                }
                panelDraw.Invalidate();
            }
            else
            {
                MessageBox.Show("Poligonul trebuie să aibă mai mult de 3 vârfuri!");
            }
        }

        private void TriangulatePolygon()
        {
            triangles.Clear();
            var polygon = new List<PointF>(points);

            while (polygon.Count > 3)
            {
                bool earFound = false;

                for (int i = 0; i < polygon.Count; i++)
                {
                    int prev = (i - 1 + polygon.Count) % polygon.Count;
                    int next = (i + 1) % polygon.Count;

                    if (IsEar(polygon, prev, i, next))
                    {
                        triangles.Add(new Triangle(polygon[prev], polygon[i], polygon[next]));
                        polygon.RemoveAt(i);
                        earFound = true;
                        break;
                    }
                }

                if (!earFound)
                {
                    // Dacă nu s-a găsit nicio ureche, înseamnă că algoritmul este blocat
                    MessageBox.Show("Nu s-a putut găsi nicio ureche pentru eliminare. Verifică dacă poligonul este simplu și corect.");
                    return;
                }
            }

            if (polygon.Count == 3)
            {
                triangles.Add(new Triangle(polygon[0], polygon[1], polygon[2]));
            }
        }

        private bool IsEar(List<PointF> polygon, int i, int j, int k)
        {
            var a = polygon[i];
            var b = polygon[j];
            var c = polygon[k];

            if (IsConvex(a, b, c))
            {
                for (int m = 0; m < polygon.Count; m++)
                {
                    if (m != i && m != j && m != k && IsPointInTriangle(polygon[m], a, b, c))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private bool IsConvex(PointF a, PointF b, PointF c)
        {
            return ((b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X)) > 0;
        }

        private bool IsPointInTriangle(PointF p, PointF a, PointF b, PointF c)
        {
            float dX = p.X - c.X;
            float dY = p.Y - c.Y;
            float dX21 = c.X - b.X;
            float dY12 = b.Y - c.Y;
            float D = dY12 * (a.X - c.X) + dX21 * (a.Y - c.Y);
            float s = dY12 * dX + dX21 * dY;
            float t = (c.Y - a.Y) * dX + (a.X - c.X) * dY;

            if (D < 0)
                return s <= 0 && t <= 0 && s + t >= D;

            return s >= 0 && t >= 0 && s + t <= D;
        }

        public class Triangle
        {
            public PointF A { get; }
            public PointF B { get; }
            public PointF C { get; }

            public Triangle(PointF a, PointF b, PointF c)
            {
                A = a;
                B = b;
                C = c;
            }

            public override string ToString()
            {
                return $"Triangle: ({A.X}, {A.Y}), ({B.X}, {B.Y}), ({C.X}, {C.Y})";
            }
        }
    }
}