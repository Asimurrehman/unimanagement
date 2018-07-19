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
    public partial class Form14 : Form
    {
        Form41 f41= new Form41();
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            this.Text = "ADD STUDENTS";


            int stid = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Student_Id) From stdata", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                stid = Convert.ToInt32(dr[0]);
                stid++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "stid 00" + "-" + stid + "-" + System.DateTime.Today.Year;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into stdata(Student_Id,Student_Name,Father_Name,Class,Address,DOB,Phone_No,Gender,Registration_Date)values(@Student_Id,@Student_Name,@Father_Name,@Class,@Address,@DOB,@Phone_No,@Gender,@Registration_Date);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Student_Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Father_Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Class", textBox4.Text);
                cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Phone_No", textBox6.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox7.Text);
                cmd.Parameters.AddWithValue("@Registration_Date", dateTimePicker2.Text.ToString());

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
