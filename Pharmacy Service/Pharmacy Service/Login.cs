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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLHelper helper = new SQLHelper();
            List<List<string>> passdata = helper.Query("select id from pharmacist where id = (select pharmid from logininfo where uname = \"" + textBox1.Text + "\" and hashword = MD5(\"" + textBox2.Text + "\"));");
            if (passdata.Count() != 0)
            {
                this.Hide();
                new MainMenu(textBox1.Text).ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
                this.Show();
            }
            else
            {
                textBox2.Clear();
                this.BackColor = Color.Red;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                button1_Click(sender, e);
        }
    }
}
