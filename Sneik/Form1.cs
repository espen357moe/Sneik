using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sneik
{
    public partial class Form1 : Form
    {      
        ArrayList bodySegments;
        Point treasure;
        Char direction = 'L';
        Random r = new Random(Guid.NewGuid().GetHashCode());
        int score;
        Font fnt;
        HitDetection hd = new HitDetection();

        public Form1()
        {
            InitializeComponent();
        }

        private void configuration()
        {
            fnt = new Font("Verdana", 12, FontStyle.Bold);
            score = 0;

            bodySegments = new ArrayList();
            bodySegments.Add(new Point(20, 10));
            bodySegments.Add(new Point(21, 10));
            bodySegments.Add(new Point(22, 10));
            bodySegments.Add(new Point(23, 10));
            bodySegments.Add(new Point(24, 10));
            
            r = new Random();
            
            treasure.X = r.Next(0, 39);
            treasure.Y = r.Next(0, 19);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size s = new System.Drawing.Size(400, 200);
            this.ClientSize = s;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            configuration();           
            timer1.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            SolidBrush b = new SolidBrush(Color.Green);
            
            for (int i = 0; i < bodySegments.Count; i++)
            {
                Point bodySegment = (Point)bodySegments[i];
                g.FillEllipse(b, bodySegment.X * 10, bodySegment.Y * 10, 10, 10);                
            }
            
            b.Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            g.FillRectangle(b, treasure.X * 10, treasure.Y * 10, 10, 10);
            b.Color = Color.DarkGray;
            g.DrawString(score.ToString(), fnt, b, 10, 10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = (Point)bodySegments[0];
            switch (direction)
            {
                case 'L' : bodySegments.Insert(0, new Point(p.X - 1, p.Y));
                    break;
                case 'R' : bodySegments.Insert(0, new Point(p.X + 1, p.Y));
                    break;
                case 'U' : bodySegments.Insert(0, new Point(p.X, p.Y - 1));
                    break;
                case 'D' : bodySegments.Insert(0, new Point(p.X, p.Y + 1));
                    break;
            }
            
            bodySegments.RemoveAt(bodySegments.Count - 1);
            
            bool hit = hd.DetectHit((Point) bodySegments[0], treasure);
            
            if (hit)
            {
                Console.WriteLine("Hit detected");
                score += 1;
                bodySegments.Add(new Point());
                
                treasure.X = r.Next(0, 39);
                treasure.Y = r.Next(0, 19);
            }                      
            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down & direction != 'U')
            {
                direction = 'D';
            }

            if (e.KeyCode == Keys.Up & direction != 'D')
            {
                direction = 'U';
            }

            if (e.KeyCode == Keys.Left & direction != 'R')
            {
                direction = 'L';
            }

            if (e.KeyCode == Keys.Right & direction != 'L')
            {
                direction = 'R';
            }
        }
    }
}
