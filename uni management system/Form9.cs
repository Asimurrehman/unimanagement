using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.Text = "Employee Attendance";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form26 f26 = new Form26();
            f26.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form27 f27 = new Form27();
            f27.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form28 f28 = new Form28();
            f28.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            //f2.Show();
            this.Hide();
        }
    }
}
