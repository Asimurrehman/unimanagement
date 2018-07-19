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
    public partial class Form29 : Form
    {
        Form41 f41 = new Form41();
        public Form29()
        {
            InitializeComponent();
        }

        private void Form29_Load(object sender, EventArgs e)
        {
            this.Text = "ADD EMPLOYEE FINANCE";

            int empid = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Emp_Id) From empfinance", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                empid = Convert.ToInt32(dr[0]);
                empid++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "00" + "-" + empid + "-" + System.DateTime.Today.Year;
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into empfinance(Emp_Id,Emp_Name,Date,Bonus,Salary,Description)values(@Emp_Id,@Emp_Name,@Date,@Bonus,@Salary,@Description);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Emp_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Bonus", textBox3.Text);
                cmd.Parameters.AddWithValue("@Salary", textBox4.Text);
                cmd.Parameters.AddWithValue("@Description", textBox5.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Data Has Been Inserted");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f41.sqlConnection1.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
