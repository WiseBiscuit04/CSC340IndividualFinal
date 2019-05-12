using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Service
{
    public partial class PatientInfo : Form
    {
        public PatientInfo()
        {
            InitializeComponent();
            SQLHelper helper = new SQLHelper();
            List<List<string>> datatable = helper.Query("select id, fname, lname, email, dob, phone, patientid from logininfo;");

            foreach (List<string> data in datatable)
            {
                string fName = data[1].ToString();
                listBox2.Items.Add(fName);
                string lName = data[2].ToString();
                listBox3.Items.Add(lName);
                string email = data[3].ToString();
                listBox4.Items.Add(email);
                string dob = data[4].ToString();
                listBox5.Items.Add(dob);
                string phone = data[5].ToString();
                listBox6.Items.Add(phone);
                string patientID = data[6].ToString();
                listBox7.Items.Add(patientID);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox7.SelectedItem == null)
                label2.Show();
            else
            {
                string curItem = listBox7.SelectedItem.ToString();
                this.Hide();
                new patientsAllergies(curItem).ShowDialog();
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
