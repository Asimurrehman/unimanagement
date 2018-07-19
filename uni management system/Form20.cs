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
    public partial class Form20 : Form
    {   
        Form41 f41=new Form41();
        public Form20()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            this.Text = "FINANCE ADD";

            int stid = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Student_Id) From stfinance", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                stid = Convert.ToInt32(dr[0]);
                stid++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "00" + "-" + stid + "-" + System.DateTime.Today.Year;
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into stfinance(Student_Id,Student_Name,Class,Date,Admission_Fee,Semester_Fee,Exam_Fee,Transport_Fee,Remarks)values(@Student_Id,@Student_Name,@Class,@Date,@Admission_Fee,@Semester_Fee,@Exam_Fee,@Transport_Fee,@Remarks);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Student_Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Class", textBox3.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Admission_Fee", textBox4.Text);
                cmd.Parameters.AddWithValue("@Semester_Fee", textBox5.Text);
                cmd.Parameters.AddWithValue("@Exam_Fee", textBox6.Text);
                cmd.Parameters.AddWithValue("@Transport_Fee", textBox7.Text);
                cmd.Parameters.AddWithValue("@Remarks", textBox8.Text);
                

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
