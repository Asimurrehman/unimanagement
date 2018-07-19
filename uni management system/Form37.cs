using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form37 : Form
    {
        Form41 f41 = new Form41();
        public Form37()
        {
            InitializeComponent();
        }

        private void Form37_Load(object sender, EventArgs e)
        {
            this.Text = "SEARCH SUBJECT";

            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Record_No from subject", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Record_No"].ToString());

            }
            f41.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from subject where Record_No='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Record_No"].ToString());
                    textBox1.Text = (dr["Subject_Name"].ToString());
                    textBox2.Text = (dr["Subject_Head"].ToString());
                    textBox3.Text = (dr["Remarks"].ToString());





                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            f41.sqlConnection1.Close();
        }
    }
}
