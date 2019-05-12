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
    public partial class Prescriptions : Form
    {
        public Prescriptions()
        {
            InitializeComponent();
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                label10.Show();
            else
            {
                string curItem = listBox1.SelectedItem.ToString();
                if (comboBox1.SelectedItem == null)
                    label11.Show();
                else
                {
                    string statusChange = comboBox1.SelectedItem.ToString();
                    SQLHelper helper = new SQLHelper();
                    List<List<string>> datatable = helper.Query("update prescription set Status = \"" + statusChange + "\"  where id = \"" + curItem + "\";");
                    update();
                }
            }
        }

        private void update()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox3.Items.Clear();
            SQLHelper helper = new SQLHelper();
            List<List<string>> datatable = helper.Query("select id, name, patientid, doctorid, caseid, numrefill, status from prescription;");
            foreach (List<string> data in datatable)
            {
                string id = data[0].ToString();
                listBox1.Items.Add(id);
                string name = data[1].ToString();
                listBox2.Items.Add(name);
                string patientID = data[2].ToString();
                listBox4.Items.Add(patientID);
                string doctorID = data[3].ToString();
                listBox5.Items.Add(doctorID);
                string caseID = data[4].ToString();
                listBox6.Items.Add(caseID);
                string numRefills = data[5].ToString();
                listBox7.Items.Add(numRefills);
                string status = data[6].ToString();
                listBox3.Items.Add(status);
            }
            label10.Visible = false;
            label11.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
