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
        private float СoordinateTortilla = 150;
        private float СoordinateAxiles=0;
        private float VelocityAxiles;
        private float VelocityTortilla;
        private float Time = 0;
        private float Distance;
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {   
            Graphics grf = e.Graphics;
            Pen pen = new Pen(Color.Red, 3);
            Pen pen2 = new Pen(Color.Green, 3);
            grf.DrawRectangle(pen, СoordinateAxiles, 285, 50, 100);
            grf.DrawEllipse(pen2, СoordinateTortilla, 360, 50, 50);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (СoordinateAxiles > pictureBox1.Width)
            {
                СoordinateAxiles = -50;
            }
            if (СoordinateTortilla > pictureBox1.Width)
            {
                СoordinateTortilla = -50;
            }
            СoordinateAxiles += (int)VelocityAxiles;
            СoordinateTortilla += (int)VelocityTortilla;
            pictureBox1.Refresh();
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (СoordinateAxiles > pictureBox1.Width)
            {
                СoordinateAxiles = -50;
            }
            if (СoordinateTortilla > pictureBox1.Width)
            {
                СoordinateTortilla = -50;
            }
            Distance = СoordinateTortilla - СoordinateAxiles;
            Time = Distance / VelocityAxiles;
            СoordinateAxiles += VelocityAxiles * Time/100;
            СoordinateTortilla += VelocityTortilla * Time/100;
            pictureBox1.Refresh();
        }
        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked== true)
            {
                timer2.Start();
                timer2.Interval = 10;
                float.TryParse(vax.Text, out VelocityAxiles);
                float.TryParse(vtor.Text, out VelocityTortilla);
            }
            else
            {
                timer1.Start();
                timer1.Interval = 10;
                float.TryParse(vax.Text, out VelocityAxiles);
                float.TryParse(vtor.Text, out VelocityTortilla);
            }
        }
        private void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            СoordinateAxiles = 0;
            СoordinateTortilla = 200;
            timer1.Stop();
            timer2.Stop();
            pictureBox1.Refresh();
        }
    }
}
