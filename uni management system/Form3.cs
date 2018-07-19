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
    public partial class Form3 : Form
    {
       Form41 f41=new Form41();
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
              
        }
           
        private void button1_Click(object sender, EventArgs e)
        {

            f41.sqlConnection1.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into login(User_id,Password,Name,F_Name)values(@User_id,@Password,@Name,@F_Name);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@User_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd.Parameters.AddWithValue("@Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@F_Name", textBox4.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Acount Has Been Created ");

                SqlDataAdapter da = new SqlDataAdapter("select * from login", f41.sqlConnection1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f41.sqlConnection1.Close();



        }

        private void Form3_Load(object sender, EventArgs e)
        {

            int userid = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(User_id) From login", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userid = Convert.ToInt32(dr[0]);
                userid++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "userid 00" + "-" + userid + "-" + System.DateTime.Today.Year;
        }
    }
}
