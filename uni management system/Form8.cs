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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.Text = "Employee Record";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form23 f23 = new Form23();
            f23.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form24 f24 = new Form24();
            f24.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form25 f25 = new Form25();
            f25.Show();
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
