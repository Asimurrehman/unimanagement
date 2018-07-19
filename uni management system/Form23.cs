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
    public partial class Form23 : Form
    {
        Form41 f41 = new Form41();
        public Form23()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();

        }

        private void Form23_Load(object sender, EventArgs e)
        {
            this.Text = "ADD EMPLOYEE";

            int empid = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Emp_Id) From empdata", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                empid = Convert.ToInt32(dr[0]);
                empid++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "00" + "-" + empid + "-" + System.DateTime.Today.Year;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into empdata(Emp_Id,Emp_Name,Qualification,Subject,Salary,Age,Phone_No,Gender,Hire_Date)values(@Emp_Id,@Emp_Name,@Qualification,@Subject,@Salary,@Age,@Phone_No,@Gender,@Hire_Date);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Emp_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Qualification", textBox3.Text);
                cmd.Parameters.AddWithValue("@Subject", textBox4.Text);
                cmd.Parameters.AddWithValue("@Salary", textBox5.Text);
                cmd.Parameters.AddWithValue("@Age", textBox6.Text);
                cmd.Parameters.AddWithValue("@Phone_No", textBox7.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox8.Text);
                cmd.Parameters.AddWithValue("@Hire_Date", dateTimePicker1.Text.ToString());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Data Has Been Inserted");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f41.sqlConnection1.Close();
        }
    }
}
