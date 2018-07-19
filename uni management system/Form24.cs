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
    public partial class Form24 : Form
    {
        Form41 f41 = new Form41();
        public Form24()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            this.Text = "MODIFY EMPLOYEE";

            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Emp_Id from empdata", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Emp_Id"].ToString());

            }
            f41.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from empdata where Emp_Id='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Emp_Id"].ToString());
                    textBox1.Text = (dr["Emp_Name"].ToString());

                    textBox2.Text = (dr["Qualification"].ToString());
                    textBox3.Text = (dr["Subject"].ToString());
                    textBox4.Text = (dr["Salary"].ToString());
                    textBox5.Text = (dr["Age"].ToString());
                    textBox6.Text = (dr["Phone_No"].ToString());
                    textBox7.Text = (dr["Gender"].ToString());
                    dateTimePicker1.Text = (dr["Hire_Date"].ToString());



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            f41.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("update empdata set Emp_Id=@Emp_Id, Emp_Name=@Emp_Name, Qualification=@Qualification, Subject=@Subject, Salary=@Salary, Age=@Age, Phone_No=@Phone_No, Gender=@Gender, Hire_Date=@Hire_Date where Emp_Id=@Emp_Id", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_Id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Emp_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Qualification", textBox2.Text);
                cmd.Parameters.AddWithValue("@Subject", textBox3.Text);
                cmd.Parameters.AddWithValue("@Salary", textBox4.Text);
                cmd.Parameters.AddWithValue("@Age", textBox5.Text);
                cmd.Parameters.AddWithValue("@Phone_No", textBox6.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox7.Text);
                cmd.Parameters.AddWithValue("@Hire_Date", dateTimePicker1.Text.ToString());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Data Has Been Modified");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f41.sqlConnection1.Close();
        }
    }
}
