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
        Char direction = "L";
        Random r;
        int score;
        Font fnt;

        private Color GetRandomColor()
        {
            return Color.FromArgb(r.Next(0, 255), r.Next(0,255),r.Next(0,255));
        }

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
            treasure.Y = r.next(0, 19);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size s = new System.Drawing.Size(400, 200);
            this.ClientSize = s;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            configuration();

        }
    }
}
