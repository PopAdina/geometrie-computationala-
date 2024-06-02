using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace seminar1ex2
{
    /*Se dau două mulțimi de puncte în plan.Pentru fiecare punct din prima
mulțime să se găsească cel mai apropiat punct din cea de a doua mulțime.*/
    public partial class Form1 : Form
    {
        // Listă de puncte pentru prima mulțime
        private List<PointF> set1 = new List<PointF>();
        // Listă de puncte pentru a doua mulțime
        private List<PointF> set2 = new List<PointF>();

        public Form1()
        {
            InitializeComponent();
        }

        // Eveniment pentru butonul de adăugare puncte în prima mulțime
        private void addPointSet1Button_Click(object sender, EventArgs e)
        {
            // Validare și adăugare puncte în prima mulțime
            if (float.TryParse(xInput.Text, out float x) && float.TryParse(yInput.Text, out float y))
            {
                set1.Add(new PointF(x, y));
                // Redesenarea canvas-ului pentru a afișa noile puncte
                canvas.Invalidate();
            }
        }

        // Eveniment pentru butonul de adăugare puncte în a doua mulțime
        private void addPointSet2Button_Click(object sender, EventArgs e)
        {
            // Validare și adăugare puncte în a doua mulțime
            if (float.TryParse(xInput.Text, out float x) && float.TryParse(yInput.Text, out float y))
            {
                set2.Add(new PointF(x, y));
                // Redesenarea canvas-ului pentru a afișa noile puncte
                canvas.Invalidate();
            }
        }

        // Eveniment pentru butonul de găsire a celor mai apropiate puncte
        private void findClosestPointsButton_Click(object sender, EventArgs e)
        {
            // Asigură-te că există puncte în ambele mulțimi
            if (set1.Count == 0 || set2.Count == 0)
            {
                MessageBox.Show("Both sets must contain points.");
                return;
            }

            // Găsește cele mai apropiate puncte și desenează liniile de conexiune
            var closestPairs = FindClosestPoints(set1, set2);

            using (Graphics g = canvas.CreateGraphics())
            {
                Pen pen = new Pen(Color.Red, 2);
                foreach (var pair in closestPairs)
                {
                    g.DrawLine(pen, pair.Item1, pair.Item2);
                }
            }
        }

        // Eveniment de desenare a canvas-ului
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Desenează punctele din prima mulțime cu albastru
            foreach (var point in set1)
            {
                e.Graphics.FillEllipse(Brushes.Blue, point.X - 2, point.Y - 2, 4, 4);
            }

            // Desenează punctele din a doua mulțime cu verde
            foreach (var point in set2)
            {
                e.Graphics.FillEllipse(Brushes.Green, point.X - 2, point.Y - 2, 4, 4);
            }
        }

        // Funcție pentru găsirea celor mai apropiate puncte
        private List<Tuple<PointF, PointF>> FindClosestPoints(List<PointF> set1, List<PointF> set2)
        {
            var closestPairs = new List<Tuple<PointF, PointF>>();

            foreach (var p1 in set1)
            {
                double minDistance = double.MaxValue;
                PointF closestPoint = new PointF();

                // Găsește punctul cel mai apropiat din setul 2 pentru fiecare punct din setul 1
                foreach (var p2 in set2)
                {
                    double distance = Distance(p1, p2);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestPoint = p2;
                    }
                }

                closestPairs.Add(new Tuple<PointF, PointF>(p1, closestPoint));
            }

            return closestPairs;
        }

        // Funcție pentru calcularea distanței euclidiene dintre două puncte
        private double Distance(PointF p1, PointF p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}