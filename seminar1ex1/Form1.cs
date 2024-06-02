using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs1
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Ex3(e.Graphics);
        }

        private void Ex1(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            Random rnd = new Random();

            int n = rnd.Next(50, 200);
            int x_min = this.ClientSize.Width, x_max = 0;
            int y_min = this.ClientSize.Height, y_max = 0;
            int x, y;

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);

                g.DrawEllipse(p, x, y, 2, 2);

                if (x < x_min)
                    x_min = x;
                else if (x > x_max)
                    x_max = x;

                if (y < y_min)
                    y_min = y;
                else if (y > y_max)
                    y_max = y;
            }

            g.DrawRectangle(p, x_min - 1, y_min - 1, x_max - x_min + 1, y_max - y_min + 1);
        } 
       
       private void Ex2(Graphics g)
        {
            Pen p = new Pen(Color.Red, 1);
            Random rnd = new Random();

            int n = rnd.Next(50, 100), m = rnd.Next(50, 100);
            int x, y;
            double d, d_min;
            int j_min = 0;

            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                points[i] = new Point(x, y);
                g.DrawEllipse(p, x, y, 4, 4);
            }

            for (int i = 0; i < m; i++)
            {
                p.Color = Color.Green;
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                g.DrawEllipse(p, x, y, 4, 4);

                d_min = int.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    d = Math.Sqrt(Math.Pow(x - points[j].X, 2) + Math.Pow(y - points[j].Y, 2));
                    if (d < d_min)
                    {
                        d_min = d;
                        j_min = j;
                    }
                }

                p.Color = Color.Blue;
                g.DrawLine(p, x + 2, y + 2, points[j_min].X + 2, points[j_min].Y + 2);
            }
        }

        private void Ex3(Graphics g)
        {
            Pen p = new Pen(Color.DarkBlue, 2);
            Random rnd = new Random();

            int n = rnd.Next(50, 100);
            int x, y;
            double d, d_min = int.MaxValue;
            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                points[i] = new Point(x, y);
                g.DrawEllipse(p, x, y, 2, 2);
            }

            x = rnd.Next(10, this.ClientSize.Width - 10);
            y = rnd.Next(10, this.ClientSize.Height - 10);

            Point q = new Point(x, y);
            p.Color = Color.Green;
            g.DrawEllipse(p, x, y, 2, 2);

            for (int i = 0; i < n; i++)
            {
                d = Math.Sqrt(Math.Pow(x - points[i].X, 2) + Math.Pow(y - points[i].Y, 2));
                if (d < d_min)
                {
                    d_min = d;
                }
            }

            d_min -= 1;
            g.DrawEllipse(p, (float)(q.X - d_min), (float)(q.Y - d_min), (float)(2 * d_min), (float)(2 * d_min));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
