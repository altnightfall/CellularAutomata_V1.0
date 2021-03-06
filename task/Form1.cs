using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n;
        CellularAutomata_Life cells;
        private async void Form1_Load(object sender, EventArgs e)
        {
            n = 100;
            cells = new CellularAutomata_Life(n);
            await Task.Run(() => cells.Generation(n));
            int scale = 3;
            SolidBrush p = new SolidBrush(Color.Black);
            Bitmap bmp = new Bitmap(PBGrid.Width, PBGrid.Height);
            PBGrid.Image = bmp;
            Graphics g = Graphics.FromImage(PBGrid.Image);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cells.field[i, j] == 1)
                    {
                        p.Color = Color.Black;
                    }
                    else
                    {
                        p.Color = Color.White;
                    }
                    Point cell = new Point(i * scale, j * scale);
                    Size s = new Size(scale, scale);
                    Rectangle r = new Rectangle(cell, s);
                    g.FillRectangle(p, r);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cells.TransitionRule(n);
            int scale = 3;
            SolidBrush p = new SolidBrush(Color.Black);
            Bitmap bmp = new Bitmap(PBGrid.Width, PBGrid.Height);
            PBGrid.Image = bmp;
            Graphics g = Graphics.FromImage(PBGrid.Image);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cells.field[i, j] == 1)
                    {
                        p.Color = Color.Black;
                    }
                    else
                    {
                        p.Color = Color.White;
                    }
                    Point cell = new Point(i * scale, j * scale);
                    Size s = new Size(scale, scale);
                    Rectangle r = new Rectangle(cell, s);
                    g.FillRectangle(p, r);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
