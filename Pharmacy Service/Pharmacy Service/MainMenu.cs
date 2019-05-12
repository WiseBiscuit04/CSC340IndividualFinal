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
    public partial class MainMenu : Form
    {
        string uname;
        public MainMenu(string username = "")
        {
            uname = username;
            InitializeComponent();
            SQLHelper helper = new SQLHelper();
            label1.Text = "User: " + username;
            List<List<string>> data = helper.Query("select name from pharmacy where id = (select pharmacyid from pharmacist where id = (select pharmid from logininfo where uname = \""+username+"\"));");
            if (data != null)
            {
                label2.Text = "Pharamacy: " + data[0][0].ToString();
            }
                   
        }

        private void button5_Click(object sender, EventArgs e)//PatientInfo
        {
            this.Hide();
            new PatientInfo().ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)//Notifications
        {
            this.Hide();
            new Notifications(uname).ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)//Login
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Prescriptions().ShowDialog();
            this.Show();
        }
    }
}