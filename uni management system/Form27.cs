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
    public partial class Form27 : Form
    {
        Form41 f41 = new Form41();
        public Form27()
        {
            InitializeComponent();
        }

        private void Form27_Load(object sender, EventArgs e)
        {
            this.Text = "MODIFY EMPLOYEE ATTENDANCE";

            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Emp_Id from empattendence", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Emp_Id"].ToString());

            }
            f41.sqlConnection1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from empattendence where Emp_Id='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Emp_Id"].ToString());
                    textBox1.Text = (dr["Emp_Name"].ToString());

                    textBox2.Text = (dr["Status"].ToString());
                    dateTimePicker1.Text = (dr["Date"].ToString());
                    textBox3.Text = (dr["Time"].ToString());
                    textBox4.Text = (dr["Remarks"].ToString());
                 



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
                SqlCommand cmd = new SqlCommand("update  empattendence set Emp_Id=@Emp_Id, Emp_Name=@Emp_Name, Status=@Status, Date=@Date, Time=@Time, Remarks=@Remarks where Emp_Id=@Emp_Id", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_Id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Emp_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Status", textBox2.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Time", textBox3.Text);
                cmd.Parameters.AddWithValue("@Remarks", textBox4.Text);


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
