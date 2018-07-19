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
    public partial class Form32 : Form
    {
        Form41 f41 = new Form41();
     
        public Form32()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            this.Text = "ADD CLASS";

            int recno = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Record_No) From class", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                recno = Convert.ToInt32(dr[0]);
                recno++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "00" + "-" + recno + "-" + System.DateTime.Today.Year;

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into class(Record_No,Class_Name)values(@Record_No,@Class_Name);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Record_No", textBox1.Text);
                cmd.Parameters.AddWithValue("@Class_Name", textBox2.Text);
             
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Data Has Been Inserted");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f41.sqlConnection1.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
