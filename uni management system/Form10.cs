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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.Text = "Employee Finance";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form29 f29 = new Form29();
            f29.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form30 f30 = new Form30();
            f30.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form31 f31 = new Form31();
            f31.Show();
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
