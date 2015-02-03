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

        

        public Form1()
        {
            InitializeComponent();
        }

        private void configuration()
        {
            score = 0;
            bodySegments = new ArrayList();
            bodySegments.Add(new Point(20, 10));
            bodySegments.Add(new Point(21, 10));
            bodySegments.Add(new Point(22, 10));
            bodySegments.Add(new Point(23, 10));
            bodySegments.Add(new Point(24, 10));
            r = new Random();
            fnt = new Font("Verdana", 12, FontStyle.Bold);
            treasure.X = r.Next(0, 39);
            treasure.Y = r.Next(0, 19);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size s = new System.Drawing.Size(400, 200);
            this.ClientSize = s;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            configuration();

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
            //mer her
        }
    }
}
