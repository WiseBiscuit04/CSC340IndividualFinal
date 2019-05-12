using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pharmacy_Service
{
    public partial class Notifications : Form
    {
        string uname;
        public Notifications(string username)
        {
            uname = username;
            InitializeComponent();
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLHelper helper = new SQLHelper();
            helper.Query("insert into notification Values (null, \"" + textBox2.Text.ToString() + "\", \"" + textBox10.Text.ToString() + "\", \"" + textBox3.Text.ToString() + "\", \"" + textBox4.Text.ToString() + "\", \"" + textBox5.Text.ToString() + "\", \"" + textBox1.Text.ToString() + "\", 'Sent', 'Message', \"" + textBox6.Text.ToString() + "\", null);");
            label6.Show();
            update();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Send Date: yyyy-mm-dd")
                textBox2.Clear();
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            if(textBox10.Text == "Sent Time:")
                textBox10.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "Recipient:")
                textBox3.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if(textBox4.Text == "Sender:")
                textBox4.Clear();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if(textBox5.Text == "Subject:")
                textBox5.Clear();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Message:")
                textBox1.Clear();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            if(textBox6.Text == "Case Number:")
                textBox6.Clear();
        }
        private void update()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox5.Items.Clear();
            listBox4.Items.Clear();
            listBox6.Items.Clear();
            label6.Hide();
            SQLHelper helper = new SQLHelper();
            List<List<string>> datatable = helper.Query("select id, senddate, sendtime, subject, message, casenum from notification;");

            foreach (List<string> data in datatable)
            {
                string id = data[0].ToString();
                listBox1.Items.Add(id);
                string senddate = data[1].ToString().Substring(0, 10);
                listBox2.Items.Add(senddate);
                string sendtime = data[2].ToString();
                listBox3.Items.Add(sendtime);
                string subject = data[3].ToString();
                listBox5.Items.Add(subject);
                string message = data[4].ToString();
                listBox4.Items.Add(message);
                string caseNum = data[5].ToString();
                listBox6.Items.Add(caseNum);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
} 