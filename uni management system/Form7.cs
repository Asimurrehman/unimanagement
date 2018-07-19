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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Text = "Students Finance";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20();
            f20.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form21 f21 = new Form21();
            f21.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form22 f22 = new Form22();
            f22.Show();
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
