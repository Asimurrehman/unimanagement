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
    public partial class Form16 : Form
    {
        Form41 f41 = new Form41();
        public Form16()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            this.Text = "STUDENTS SEARCH";


            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select Student_Id from stdata", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Student_Id"].ToString());

            }
            f41.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f41.sqlConnection1.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from stdata where Student_Id='" + comboBox1.Text + "'", f41.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    comboBox1.Text = (dr["Student_Id"].ToString());
                    textBox1.Text = (dr["Student_Name"].ToString());
                    textBox2.Text = (dr["Father_Name"].ToString());
                    textBox3.Text = (dr["Class"].ToString());
                    textBox4.Text = (dr["Address"].ToString());
                    dateTimePicker1.Text = (dr["DOB"].ToString());
                    textBox5.Text = (dr["Phone_No"].ToString());
                    dateTimePicker2.Text = (dr["Registration_Date"].ToString());
                    textBox6.Text = (dr["Gender"].ToString());


                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

                f41.sqlConnection1.Close();



            
            
        }
    }
}
