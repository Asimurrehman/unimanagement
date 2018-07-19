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
    public partial class Form21 : Form
    {
        Form41 f41 = new Form41();
        public Form21()
        {
            InitializeComponent();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            this.Text = "MODIFY FINANCE";

            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Student_Id from stfinance", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Student_Id"].ToString());

            }
            f41.sqlConnection1.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from stfinance where Student_Id='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Student_Id"].ToString());
                    textBox1.Text = (dr["Student_Name"].ToString());

                    textBox2.Text = (dr["Class"].ToString());
                    dateTimePicker1.Text = (dr["Date"].ToString());
                    textBox3.Text = (dr["Admission_Fee"].ToString());
                    textBox4.Text = (dr["Semester_Fee"].ToString());
                    textBox5.Text = (dr["Exam_Fee"].ToString());
                    textBox6.Text = (dr["Transport_Fee"].ToString());
                    textBox7.Text = (dr["Remarks"].ToString());



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
                SqlCommand cmd = new SqlCommand("update stfinance set  Student_Id=@Student_Id, Student_Name=@Student_Name, Class=@Class, Date=@Date, Admission_Fee=@Admission_Fee, Semester_Fee=@Semester_Fee, Exam_Fee=@Exam_Fee, Transport_Fee=@Transport_Fee, Remarks=@Remarks where Student_Id=@Student_Id", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Student_Id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Class", textBox2.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Admission_Fee", textBox3.Text);
                cmd.Parameters.AddWithValue("@Semester_Fee", textBox4.Text);
                cmd.Parameters.AddWithValue("@Exam_Fee", textBox5.Text);
                cmd.Parameters.AddWithValue("@Transport_Fee", textBox6.Text);
                cmd.Parameters.AddWithValue("@Remarks", textBox7.Text);


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
