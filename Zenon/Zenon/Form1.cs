using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zenon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float t = 0, dt, x = 0, y = 200, vaxil = 0, vtort = 0, d = 0;
        public static int AWidth { get; } = 40;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void Start_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
            timer1.Interval = 10;
            float.TryParse(vax.Text, out vaxil);
            float.TryParse(vtor.Text, out vtort); 
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {   

            Graphics grf = e.Graphics;
            Pen pen = new Pen(Color.Red, 3);
            Pen pen2 = new Pen(Color.Green, 3);
            grf.DrawRectangle(pen,x, 285, 100, 100);
            grf.DrawEllipse(pen2,y, 360, 50, 50);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (x>478)
            {
                x = -100;
            }
            if (y > 528)
            {
                y = -50;
            }
            x += (int)vaxil;
            y += (int)vtort;
            pictureBox1.Refresh();
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (x > 478)
            {
                x = -100;
            }
            if (y > 528)
            {
                y = -50;
            }
            d = y - x ;
            t = d / vaxil;
            dt = t / 100;
            x += vaxil * dt;
            y += vtort * dt;
            pictureBox1.Refresh();
        }
        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            timer2.Start();
            timer2.Interval = 100;
            float.TryParse(vax.Text, out vaxil);
            float.TryParse(vtor.Text, out vtort);
        }

        private void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            x = 0;
            y = 200;
            timer1.Stop();
            timer2.Stop();
        }
    }
}
