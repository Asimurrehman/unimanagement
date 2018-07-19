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
    public partial class Form35 : Form
    {
        Form41 f41 = new Form41();
        public Form35()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form35_Load(object sender, EventArgs e)
        {
            this.Text = "ADD SUBJECT";


            int sub = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Record_No) From subject", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sub = Convert.ToInt32(dr[0]);
                sub++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "00" + "-" + sub + "-" + System.DateTime.Today.Year;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into subject(Record_No,Subject_Name,Subject_Head,Remarks)values(@Record_No,@Subject_Name,@Subject_Head,@Remarks);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Record_No", textBox1.Text);
                cmd.Parameters.AddWithValue("@Subject_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Subject_Head", textBox3.Text);
                cmd.Parameters.AddWithValue("@Remarks", textBox4.Text);
            

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
