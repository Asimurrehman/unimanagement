﻿using System;
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
    public partial class Form26 : Form
    {
        Form41 f41 = new Form41();
        public Form26()
        {
            InitializeComponent();
        }

        private void Form26_Load(object sender, EventArgs e)
        {
            this.Text = "ADD EMPLOYEE ATTENDANCE";


            int empid = 0;
            f41.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select count(Emp_Id) From empattendence", f41.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                empid = Convert.ToInt32(dr[0]);
                empid++;

            }
            f41.sqlConnection1.Close();
            this.textBox1.Text = "00" + "-" + empid + "-" + System.DateTime.Today.Year;

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
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
                SqlCommand cmd = new SqlCommand("insert into empattendence(Emp_Id,Emp_Name,Status,Date,Time,Remarks)values(@Emp_Id,@Emp_Name,@Status,@Date,@Time,@Remarks);", f41.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Emp_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Status", textBox3.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text.ToString());
                cmd.Parameters.AddWithValue("@Time", textBox4.Text);
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