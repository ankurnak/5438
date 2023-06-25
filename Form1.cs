using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vector
{
    public partial class Form1 : Form
    {
        private Vector3D vector1;
        private Vector3D vector2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            int width = pictureBox.Width;
            int height = pictureBox.Height;

            Point origin = new Point(width / 2, height / 2);
            int vector1Length = (int)(vector1.Length() * 10);
            int vector2Length = (int)(vector2.Length() * 10);

            Point vector1End = new Point(origin.X + (int)(vector1.X * vector1Length), origin.Y + (int)(vector1.Y * vector1Length));
            Point vector2End = new Point(origin.X + (int)(vector2.X * vector2Length), origin.Y + (int)(vector2.Y * vector2Length));

            g.DrawLine(pen, origin, vector1End);
            g.DrawLine(pen, origin, vector2End);
        }
        private void SetButtonStyle(Button button)
        {
            button.BackColor = Color.Bisque;
            button.ForeColor = Color.White;
            button.Font = new Font("Arial", 12, FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        private void SetTextBoxStyle(TextBox textBox)
        {
            textBox.BackColor = Color.FromArgb(240, 240, 240);
            textBox.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        private void SetLabelStyle(Label label)
        {
            label.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        private void addition_Click(object sender, EventArgs e)
        {
            double x1 = double.Parse(txtX1.Text);
            double y1 = double.Parse(txtY1.Text);
            double z1 = double.Parse(txtZ1.Text);
            vector1 = new Vector3D(x1, y1, z1);

            double x2 = double.Parse(txtX2.Text);
            double y2 = double.Parse(txtY2.Text);
            double z2 = double.Parse(txtZ2.Text);
            vector2 = new Vector3D(x2, y2, z2);

            Vector3D sum = vector1 + vector2;
            lblResult.Text = "Sum: " + sum.ToString();

         
            pictureBox.Refresh();
        }

        private void substraction_Click(object sender, EventArgs e)
        {
            double x1 = double.Parse(txtX1.Text);
            double y1 = double.Parse(txtY1.Text);
            double z1 = double.Parse(txtZ1.Text);
            vector1 = new Vector3D(x1, y1, z1);

            double x2 = double.Parse(txtX2.Text);
            double y2 = double.Parse(txtY2.Text);
            double z2 = double.Parse(txtZ2.Text);
            vector2 = new Vector3D(x2, y2, z2);

            Vector3D difference = vector1 - vector2;
            lblResult.Text = "Difference: " + difference.ToString();

            // Перемалювання PictureBox
            pictureBox.Refresh();
        }

        private void dotproduct_Click(object sender, EventArgs e)
        {
            double x1 = double.Parse(txtX1.Text);
            double y1 = double.Parse(txtY1.Text);
            double z1 = double.Parse(txtZ1.Text);
            vector1 = new Vector3D(x1, y1, z1);

            double x2 = double.Parse(txtX2.Text);
            double y2 = double.Parse(txtY2.Text);
            double z2 = double.Parse(txtZ2.Text);
            vector2 = new Vector3D(x2, y2, z2);

            double dotProduct = vector1 * vector2;
            lblResult.Text = "Dot Product: " + dotProduct.ToString();

            // Перемалювання PictureBox
            pictureBox.Refresh();
        }

        private void length_Click(object sender, EventArgs e)
        {
            double x1 = double.Parse(txtX1.Text);
            double y1 = double.Parse(txtY1.Text);
            double z1 = double.Parse(txtZ1.Text);
            vector1 = new Vector3D(x1, y1, z1);

            double length = vector1.Length();
            lblResult.Text = "Length of Vector: " + length.ToString();

          
            pictureBox.Refresh();
        }

        private void angle_Click(object sender, EventArgs e)
        {
            double x1 = double.Parse(txtX1.Text);
            double y1 = double.Parse(txtY1.Text);
            double z1 = double.Parse(txtZ1.Text);
            vector1 = new Vector3D(x1, y1, z1);

            double x2 = double.Parse(txtX2.Text);
            double y2 = double.Parse(txtY2.Text);
            double z2 = double.Parse(txtZ2.Text);
            vector2 = new Vector3D(x2, y2, z2);

            double angle = vector1.AngleWith(vector2);
            lblResult.Text = "Angle between Vectors: " + angle.ToString() + " radians";

           
            pictureBox.Refresh();
        }
    }
    public class Vector3D
    {
        private double x;
        private double y;
        private double z;

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static double operator *(Vector3D v1, Vector3D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z; // Скалярний добуток
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z); // Довжина вектора
        }

        public double AngleWith(Vector3D other)
        {
            double dotProduct = this * other; // Скалярний добуток
            double lengthProduct = this.Length() * other.Length(); // Добуток довжин векторів

            if (lengthProduct == 0)
                throw new DivideByZeroException("One or both vectors have zero length.");

            return Math.Acos(dotProduct / lengthProduct); // Кут між векторами (в радіанах)
        }
    }
}
