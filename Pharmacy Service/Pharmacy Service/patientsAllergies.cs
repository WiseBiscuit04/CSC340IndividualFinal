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
    public partial class patientsAllergies : Form
    {
        string patID;
        public patientsAllergies(string patientID)
        {
            InitializeComponent();
            patID = patientID;
            SQLHelper helper = new SQLHelper();
            List<List<string>> datatable0 = helper.Query("select allergy from allergy where patientid= \"" + patID + "\";");
            foreach (List<string> data in datatable0)
            {
                string allergy = data[0].ToString();
                listBox1.Items.Add(allergy);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = patID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
