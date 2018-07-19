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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            this.Text = "Examinations";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form38 f38 = new Form38();
            f38.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form39 f39 = new Form39();
            f39.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form40 f40 = new Form40();
            f40.Show();
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
