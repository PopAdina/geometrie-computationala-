using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace seminar11ex1
/*Partiționarea unui poligon simplu în poligoane convexe, pornind de la o triangulare
a poligonului și eliminând diagonalele neesențiale.*/
{
    public partial class Form1 : Form
    {
        private List<PointF> points = new List<PointF>(); // Lista de puncte care reprezintă vârfurile poligonului
        private List<Triangle> triangles = new List<Triangle>(); // Lista de triunghiuri care reprezintă triangularea poligonului

        public Form1()
        {
            InitializeComponent();
            panel1.MouseClick += panel1_MouseClick; // Adăugăm evenimentul MouseClick pentru a adăuga puncte la clic pe panou
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location); // Adăugăm locația clicului ca punct în lista de puncte
            panel1.Invalidate(); // Redesenăm panoul pentru a afișa noile puncte și triunghiuri
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Desenăm triunghiurile din lista de triunghiuri
            foreach (var triangle in triangles)
            {
                e.Graphics.DrawLine(Pens.Black, triangle.A, triangle.B);
                e.Graphics.DrawLine(Pens.Black, triangle.B, triangle.C);
                e.Graphics.DrawLine(Pens.Black, triangle.C, triangle.A);
            }

            // Desenăm punctele
            foreach (var point in points)
            {
                e.Graphics.FillEllipse(Brushes.Red, point.X - 3, point.Y - 3, 6, 6);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (points.Count < 3)
            {
                MessageBox.Show("Cel puțin 3 puncte sunt necesare pentru a triunghiula poligonul.");
                return;
            }

            triangles = TriangulatePolygon(points); // Triunghiulăm poligonul folosind metoda de mai jos
            panel1.Invalidate(); // Redesenăm panoul pentru a afișa triunghiurile
        }
        // Metoda care triunghiulează un poligon dat și returnează lista de triunghiuri rezultate
        private List<Triangle> TriangulatePolygon(List<PointF> polygon)
        {
            List<Triangle> triangles = new List<Triangle>();

            // Verificăm dacă poligonul are cel puțin 3 vârfuri
            if (polygon.Count < 3)
            {
                return triangles; // Returnăm o listă goală deoarece nu putem forma triunghiuri
            }

            for (int i = 1; i < polygon.Count - 1; i++)
            {
                triangles.Add(new Triangle(polygon[0], polygon[i], polygon[i + 1]));
            }

            return triangles;
        }

        // Structura pentru a reprezenta un triunghi
        private struct Triangle
        {
            public PointF A, B, C;

            public Triangle(PointF a, PointF b, PointF c)
            {
                A = a;
                B = b;
                C = c;
            }
        }
    }
}