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
    public partial class Form30 : Form
    {
        Form41 f41 = new Form41();
        public Form30()
        {
            InitializeComponent();
        }

        private void Form30_Load(object sender, EventArgs e)
        {
            this.Text = "MODIFY EMPLOYEE FINANCE";

            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Emp_ID from empfinance", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Emp_ID"].ToString());

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
                SqlCommand cmd = new SqlCommand("select * from empfinance where Emp_ID='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Emp_ID"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("update empfinance set Emp_ID=@Emp_ID, Emp_Name=@Emp_Name, Date=@Date, Bonus=@Bonus, Salary=@Salary  where Emp_ID=@Emp_ID", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_ID", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Emp_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Bonus", textBox2.Text);
                cmd.Parameters.AddWithValue("@Salary", textBox3.Text);
                //cmd.Parameters.AddWithValue("@Description", textBox4.Text);


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
