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
    public partial class Form38 : Form
    {
        Form41 f41 = new Form41();
        public Form38()
        {
            InitializeComponent();
        }

        private void Form38_Load(object sender, EventArgs e)
        {

            this.Text = "ADD EXAM";

            int exam = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Student_Id) From exam", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                exam = Convert.ToInt32(dr[0]);
                exam++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "00" + "-" + exam + "-" + System.DateTime.Today.Year;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
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
                SqlCommand cmd = new SqlCommand("insert into exam(Student_ID,Student_Name,Class,Exam_Name,Exam_Date,Exam_Result)values(@Student_Id,@Student_Name,@Class,@Exam_Name,@Exam_Date,@Exam_Result);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Student_ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Class", textBox3.Text);
                cmd.Parameters.AddWithValue("@Exam_Name", textBox4.Text);
                cmd.Parameters.AddWithValue("@Exam_Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Exam_Result", textBox5.Text);


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
