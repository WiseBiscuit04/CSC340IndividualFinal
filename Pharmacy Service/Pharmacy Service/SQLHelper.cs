using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Pharmacy_Service
{
    class SQLHelper
    {
        string connectionStatment = "user id=root;password=yeet;server=24.95.141.63;database=mcnultyradersmith;connection timeout=30; convert zero datetime=True";
        //string connectionStatment = "user id=root;password=yeet;server=157.89.105.60;database=mcnultyradersmith;connection timeout=30;convert zero datetime=True";
        public MySqlConnection OpenConnection()
        {
            var con = new MySqlConnection(this.connectionStatment);
            con.Open();
            return con;
        }
        public List<List<string>> Query(string command)
        {
            List<List<string>> ret = new List<List<string>>();
            using (var con = this.OpenConnection())
            using (var exec = new MySqlCommand(command, con))
            using (MySqlDataReader data = exec.ExecuteReader())
            {
                while (data.Read())
                {
                    List<string> output = new List<string>();
                    for (int i = 0; i < data.FieldCount; i++)
                        output.Add(data[i].ToString());
                    ret.Add(output);
                }
            }
            return ret;
        }
    }
}