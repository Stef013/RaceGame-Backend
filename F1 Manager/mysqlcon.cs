using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace F1_Manager
{
    public class mysqlcon
    {

        public string Hostname = "ams-web01.vanloon.xyz";
        public string DBName = "aquadis_proftaak";
        public string ID = "aquadis";
        public string Password = "grI5wiB4aSRS4TO9";

        public object Users { get; internal set; }

        //This class handels all the SQL communication.

        //public mysqlcon()
        //{
        //}

        public mysqlcon()
        {

        }

        private string connectionString()
        {
            return $"SERVER={Hostname};DATABASE={DBName};UID={ID};PASSWORD={Password};SslMode=none";
        }

        public DataTable mysqlGetTable(string command, string tablename)
        {
            MySqlConnection mysqlc = new MySqlConnection(connectionString());
            try
            {
                mysqlc.Open();
                MySqlCommand cmd = new MySqlCommand(command, mysqlc);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable(tablename);
                adapter.Fill(table);
                mysqlc.Close();
                return table;
            }
            catch (Exception ex)
            {
                mysqlError(ex);
                return null;
            }
        }
        public void mysql(string command)
        {
            MySqlConnection mysqlc = new MySqlConnection(connectionString());
            try
            {
                mysqlc.Open();
                MySqlCommand cmd = new MySqlCommand(command, mysqlc);
                cmd.ExecuteNonQuery();
                mysqlc.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                mysqlError(ex);
            }
        }
        public void testDbCon()
        {
            MySqlConnection mysqlc = new MySqlConnection(connectionString());
            try
            {
                mysqlc.Open();
                Console.WriteLine("MySQL server connected!");
                mysqlc.Close();
            }
            catch
            {
                mysqlError();
            }
        }
        private void mysqlError()
        {
            Console.WriteLine("Cannot connect to the MySQL Server!");
        }
        private void mysqlError(Exception ex)
        {
            Console.WriteLine("Something went wrong!" + "Environment.NewLine" + ex.ToString());
        }
        public override string ToString()
        {
            return connectionString();
        }
    }
}


