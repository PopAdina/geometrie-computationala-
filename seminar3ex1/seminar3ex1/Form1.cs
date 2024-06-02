using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace seminar3ex1
{
    /*Se dă o mulțime de 2n puncte în plan.Să se unească două câte două
puncte astfel încât suma lungimilor segmentelor obținute să fie minimă
(problemă de cuplaj).*/

    public partial class Form1 : Form
    {
        // Lista de puncte introduse
        private List<PointF> points = new List<PointF>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addPointButton_Click(object sender, EventArgs e)
        {

            // Validare și adăugare puncte
            if (float.TryParse(xInput.Text, out float x) && float.TryParse(yInput.Text, out float y))
            {
                points.Add(new PointF(x, y));
                // Redesenarea canvas-ului pentru a afișa noile puncte
                canvas.Invalidate();
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            // Verifică dacă numărul de puncte este par
            if (points.Count % 2 != 0)
            {
                MessageBox.Show("Number of points must be even.");
                return;
            }

            // Obține soluția pentru cuplajul perfect
            var result = SolveMatching(points);

            // Desenează segmentele roșii pentru perechile de puncte
            using (Graphics g = canvas.CreateGraphics())
            {
                Pen pen = new Pen(Color.Red, 2);
                foreach (var pair in result)
                {
                    g.DrawLine(pen, pair.Item1, pair.Item2);
                }
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Desenează punctele existente
            foreach (var point in points)
            {
                e.Graphics.FillEllipse(Brushes.Black, point.X - 2, point.Y - 2, 4, 4);
            }
        }

        // Funcție pentru calcularea cuplajului perfect cu suma minimă a lungimilor segmentelor
        private List<Tuple<PointF, PointF>> SolveMatching(List<PointF> points)
        {
            int n = points.Count / 2;
            var distances = new double[points.Count, points.Count];

            // Calculează distanțele dintre toate perechile de puncte
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    if (i != j)
                    {
                        distances[i, j] = Distance(points[i], points[j]);
                    }
                }
            }

            // Listează perechile de puncte astfel încât suma lungimilor să fie minimă
            var minCostMatching = new List<Tuple<PointF, PointF>>();
            var used = new bool[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                if (used[i]) continue;
                double minDistance = double.MaxValue;
                int minIndex = -1;

                // Găsește punctul cel mai apropiat care nu a fost deja folosit
                for (int j = 0; j < points.Count; j++)
                {
                    if (i != j && !used[j] && distances[i, j] < minDistance)
                    {
                        minDistance = distances[i, j];
                        minIndex = j;
                    }
                }

                // Adaugă perechea de puncte la soluție
                if (minIndex != -1)
                {
                    used[i] = used[minIndex] = true;
                    minCostMatching.Add(new Tuple<PointF, PointF>(points[i], points[minIndex]));
                }
            }

            return minCostMatching;
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
