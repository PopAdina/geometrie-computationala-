using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace seminar5ex1metoda1
{
    /* Se dă o mulțime de puncte în plan.Să se determine învelitoarea convexă
 a acestei mulțimi.
    Algoritmul lui Jarvis.*/
    public partial class Form1 : Form
    {
        private List<PointF> points = new List<PointF>();

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Desenează punctele
            foreach (var point in points)
            {
                e.Graphics.FillEllipse(Brushes.Black, point.X - 2, point.Y - 2, 4, 4);
            }

            // Dacă există puncte suficiente, desenează învelitoarea convexă
            if (points.Count > 2)
            {
                List<PointF> convexHull = ComputeConvexHull(points);
                if (convexHull.Count > 2)
                {
                    // Desenează liniile care unesc punctele învelitorii convexe
                    for (int i = 0; i < convexHull.Count; i++)
                    {
                        int nextIndex = (i + 1) % convexHull.Count;
                        e.Graphics.DrawLine(Pens.Red, convexHull[i], convexHull[nextIndex]);
                    }
                }
            }
        }

        private List<PointF> ComputeConvexHull(List<PointF> points)
        {
            List<PointF> convexHull = new List<PointF>();

            // Găsește cel mai din stânga punct
            PointF startPoint = points[0];
            foreach (var point in points)
            {
                if (point.X < startPoint.X || (point.X == startPoint.X && point.Y < startPoint.Y))
                {
                    startPoint = point;
                }
            }

            PointF currentPoint = startPoint;
            do
            {
                convexHull.Add(currentPoint);

                PointF nextPoint = points[0];
                foreach (var point in points)
                {
                    if (point == currentPoint)
                    {
                        continue;
                    }

                    float orientation = GetOrientation(currentPoint, point, nextPoint);
                    if (orientation < 0 || (orientation == 0 && GetDistance(currentPoint, point) > GetDistance(currentPoint, nextPoint)))
                    {
                        nextPoint = point;
                    }
                }

                currentPoint = nextPoint;
            } while (currentPoint != startPoint);

            return convexHull;
        }

        private float GetOrientation(PointF p1, PointF p2, PointF p3)
        {
            return (p2.Y - p1.Y) * (p3.X - p2.X) - (p3.Y - p2.Y) * (p2.X - p1.X);
        }

        private float GetDistance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private void addPointButton_Click(object sender, EventArgs e)
        {
            if (float.TryParse(xInput.Text, out float x) && float.TryParse(yInput.Text, out float y))
            {
                points.Add(new PointF(x, y));
                canvas.Invalidate();
            }
        }

        private void clearPointsButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            canvas.Invalidate();
        }
    }
}