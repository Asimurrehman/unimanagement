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
    public partial class Form33 : Form
    {
        Form41 f41 = new Form41();
        public Form33()
        {
            InitializeComponent();
        }

        private void Form33_Load(object sender, EventArgs e)
        {
            this.Text = "MODIFY CLASS";

            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Record_No from class", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Record_No"].ToString());

            }
            f41.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from class where Record_No='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Record_No"].ToString());
                    textBox1.Text = (dr["Class_Name"].ToString());
                   




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
                SqlCommand cmd = new SqlCommand("update class set Record_No=@Record_No, Class_Name=@Class_Name where Record_No=@Record_No", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Record_No", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Class_Name", textBox1.Text);

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
