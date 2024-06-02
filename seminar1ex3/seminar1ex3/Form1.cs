using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace seminar1ex3
{
    /*Se dau n puncte în plan.Pentru un punct dat q să se determine cercul cu
centrul în q și de rază maximă care să nu conțină niciun punct din
mulțimea dată.*/

    public partial class Form1: Form
    {
        private List<PointF> points;// Lista pentru a stoca punctele din plan
        private PointF center;// Centrul cercului
        private float maxRadius;// Raza maximă a cercului

        public Form1()
        {
            InitializeComponent();
            points = new List<PointF>();
            maxRadius = 0;
        }
        // Butonul pentru găsirea cercului maxim
        private void button1_Click(object sender, EventArgs e)
        {

            if (points.Count == 0)
            {
                MessageBox.Show("Adaugati puncte inainte de a gasi cercul maxim.", "Fara puncte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Iterăm prin fiecare punct și găsim distanța maximă de la centrul cercului
            foreach (PointF point in points)
            {
                float distance = Distance(center, point);
                if (distance > maxRadius)
                {
                    maxRadius = distance;
                }
            }
            // Verificăm dacă cercul cu centrul în 'center' și raza 'maxRadius' conține vreun punct
            bool containsPoints = false;
            foreach (PointF point in points)
            {
                float distanceToCenter = Distance(center, point);
                if (distanceToCenter <= maxRadius)
                {
                    containsPoints = true;
                    break;
                }
            }

            if (containsPoints)
            {
                MessageBox.Show("Cercul maxim conține câteva puncte din mulțimea dată.", "Cercul contine puncte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Cercul maxim cu centrul în ({center.X}, {center.Y}) și rază {maxRadius} nu conține niciun punct din mulțimea dată.", "Cercul maxim fara puncte.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Funcția pentru calculul distanței între două puncte
        private float Distance(PointF p1, PointF p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        // Suprascrierea metodei OnMouseDown pentru a permite adăugarea de puncte și setarea centrului cercului
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);// Adăugăm punctul în listă la clic stâng
                Invalidate();// Invalidăm controlul pentru a declanșa redesenarea
            }
            else if (e.Button == MouseButtons.Right)
            {
                center = e.Location;// Setăm centrul cercului la clic dreapta
                maxRadius = 0;// Resetăm raza maximă
                Invalidate();// Invalidăm controlul pentru a declanșa redesenarea
            }
        }
        // Suprascrierea metodei OnPaint pentru a desena punctele și cercul
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (PointF point in points)
            {
                e.Graphics.FillEllipse(Brushes.Black, point.X - 2, point.Y - 2, 4, 4);// Desenăm punctele
            }
            if (center != null)
            {
                e.Graphics.FillEllipse(Brushes.Red, center.X - 2, center.Y - 2, 4, 4);// Desenăm centrul cercului
                if (maxRadius > 0)
                {
                    e.Graphics.DrawEllipse(Pens.Blue, center.X - maxRadius, center.Y - maxRadius, 2 * maxRadius, 2 * maxRadius);// Desenăm cercul cu raza maximă
                }
            }
        }
    }
}
