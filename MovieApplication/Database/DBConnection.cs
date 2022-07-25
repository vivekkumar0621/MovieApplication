using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace MovieApplication.Database
{
    public class DBConnection
    {
        private readonly IConfiguration _config;
        private MySqlConnection con=null;

        public DBConnection(IConfiguration config)
        {
            _config = config;
        }

        public MySqlConnection GetConnection()
        {
            if(con==null)
            {
                string connstr = _config.GetConnectionString("DBConnection");
                con = new MySqlConnection(connstr);
            }
                
            return con;
        }

        public DataTable GetResult(string query,MySqlConnection con,bool isStoreProcedure)
        {
            DataTable dt = null;
            MySqlCommand cmd;
            MySqlDataAdapter dataAdapter;

            try
            {
                cmd = new MySqlCommand(query, con);
                con.Open();
                dataAdapter = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                dataAdapter.Fill(dt);
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public int SetResult(string query, MySqlConnection con, bool isStoreProcedure)
        {
            DataTable dt = null;
            MySqlCommand cmd;
            int id=-1;
            try
            {
                cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                id = (int)cmd.LastInsertedId;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
            return id;
        }

    }
}
