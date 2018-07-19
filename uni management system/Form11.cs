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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.Text = "Classes Record";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            //f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form32 f32 = new Form32();
            f32.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form33 f33 = new Form33();
            f33.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form34 f34 = new Form34();
            f34.Show();
            this.Hide();
        }
    }
}
