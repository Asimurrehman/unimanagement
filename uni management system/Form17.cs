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
    public partial class Form17 : Form
    {
        Form41 f41 = new Form41();
        public Form17()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form17_Load(object sender, EventArgs e)
        {
            this.Text = "ATTENDANCE ADD";

            int stid = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Student_Id) From stattendence", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                stid = Convert.ToInt32(dr[0]);
                stid++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "00" + "-" + stid + "-" + System.DateTime.Today.Year;

          
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
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
                SqlCommand cmd = new SqlCommand("insert into stattendence(Student_Id,Student_Name,Class,Date,Status,Remarks)values(@Student_Id,@Student_Name,@Class,@Date,@Status,@Remarks);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Student_Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Student_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Class", textBox3.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Status", textBox4.Text);
                cmd.Parameters.AddWithValue("@Remarks", textBox5.Text);
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Data Has Been Inserted");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f41.sqlConnection1.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
