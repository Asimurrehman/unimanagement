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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            this.Text = "Subjects";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form35 f35 = new Form35();
            f35.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form36 f36 = new Form36();
            f36.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form37 f37 = new Form37();
            f37.Show();
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
