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
    public partial class Form31 : Form
    {
        Form41 f41 = new Form41();
        public Form31()
        {
            InitializeComponent();
        }

        private void Form31_Load(object sender, EventArgs e)
        {
            this.Text = "SEARCH EMPLOYEE FINANCE";

            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Emp_Id from empfinance", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Emp_Id"].ToString());

            }
            f41.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from empfinance where Emp_Id='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Emp_Id"].ToString());
                    textBox1.Text = (dr["Emp_Name"].ToString());
                    dateTimePicker1.Text = (dr["Date"].ToString());
                    textBox2.Text = (dr["Bonus"].ToString());
                    textBox3.Text = (dr["Salary"].ToString());
                   // textBox4.Text = (dr["Discription"].ToString());




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
