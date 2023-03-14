using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static montecarlo.PNG;

namespace montecarlo
{
    public partial class Form1 : Form
    {
        public static double count_balls = 5000;

        public Form1()
        {
            InitializeComponent();
        }

        void _Init() 
        {
            Graphics g = CreateGraphics();
            g.DrawRectangle(new Pen(Color.Black, 3), 50, 50, 300, 300);
            g.DrawEllipse(new Pen(Color.Red, 2), 50, 50, 300, 300);
        }

        double fallibility(double pred)
        {
            const double _Pi = 3.14159f;
            return _Pi - pred;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            double dotsin = 0,  // dots in 
                   pi = 0; 
            
            int dotsout = 0,    // dots out
                x = 0,          // Coordinate x
                y = 0;          // Coordinate y

          
            Pen p1;
            Graphics g2 = Graphics.FromHwnd(this.Handle);

            g2.Clear(BackColor);

            _Init();

            for (int i = 0; i < count_balls; i++) {
               
                // Random x,y
                x = getN(300) + 51;
                y = getN(300) + 51;
               

                // Center of circle is at (250,220)

                int radius = (int)(Math.Sqrt(Math.Pow(x - 200, 2) + Math.Pow(y - 200, 2)));

                if (radius <= 150) { // Dot in
                    p1 = new Pen(Color.IndianRed);
                    dotsin++;
                }
                else { // Dot out
                    p1 = new Pen(Color.Blue);
                    dotsout++;
                }

                g2.DrawRectangle(p1, x, y, 1, 1); // draw
            }

            pi = (4 * dotsin) / count_balls;

            label1.Text = $"In:    {dotsin}";
            label2.Text = $"Out: {dotsout}";
            label3.Text = $"PI:          {Math.Round(pi,4)}";
            label4.Text = $"fallibility:  {Math.Round(fallibility(pi), 4)}"; 

        }
    }
}
