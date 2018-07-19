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
    public partial class Form22 : Form
    {
        Form41 f41 = new Form41();
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            this.Text = "SEARCH FINANCE";

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
    }
}
