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
    public partial class Form39 : Form
    {
        Form41 f41 = new Form41();
        public Form39()
        {
            InitializeComponent();
        }

        private void Form39_Load(object sender, EventArgs e)
        {
            this.Text = "MODIFY EXAM";

            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Student_Id from exam", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Student_Id"].ToString());

            }
            f41.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from Exam where Student_Id='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Student_Id"].ToString());
                    textBox1.Text = (dr["Student_Name"].ToString());
                    textBox2.Text = (dr["class"].ToString());
                    textBox3.Text = (dr["Exam_Name"].ToString());
                    dateTimePicker1.Text = (dr["Exam_Date"].ToString());
                    textBox4.Text = (dr["Exam_Result"].ToString());





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
                SqlCommand cmd = new SqlCommand("update exam set Student_ID=@Student_ID, Student_Name=@Student_Name, Class=@Class, Exam_Name=@Exam_Name, Exam_Date=@Exam_Date, Exam_Result=@Exam_Result where Student_ID=@Student_ID", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Student_ID", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Class", textBox2.Text);
                cmd.Parameters.AddWithValue("@Exam_Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Exam_Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Exam_Result", textBox4.Text);


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
