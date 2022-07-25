using Microsoft.Extensions.Configuration;
using MovieApplication.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Database
{
    public class ProducerRepository
    {
        private DBConnection dbcon;
        public ProducerRepository(IConfiguration config)
        {
            dbcon = new DBConnection(config);
        }

        public List<Producer> GetProducer()
        {
            List<Producer> list = new List<Producer>();
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select * from Producer";
            DataTable dt = dbcon.GetResult(sql, con, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Producer producer = new Producer();
                producer.PID = Convert.ToInt32(dt.Rows[i]["PID"].ToString());
                list.Add(producer);
            }
            return list;
        }

        public string getProducerByID(int PID)
        {
            String ProducerName=null;
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select ProducerName from Producer where PID = " + PID+";";
            DataTable dt = dbcon.GetResult(sql, con, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProducerName = dt.Rows[i]["ProducerName"].ToString();
            }
            return ProducerName;
        }

        public List<String> GetProducerNames()
        {
            List<String> list = new List<String>();
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select ProducerName from Producer";
            DataTable dt = dbcon.GetResult(sql, con, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["ProducerName"].ToString();
                list.Add(name);
            }
            return list;
        }

        public int AddProducer(Producer producer)
        {
            MySqlConnection con = dbcon.GetConnection();
            String sql = "insert into Producer (ProducerName,Bio,DOB,Company,Gender) values ('" + producer.ProducerName + "', '" + producer.Bio + "', '" + producer.DOB + "', '" + producer.Company + "', '" + producer.Gender + "');";
            int aid = dbcon.SetResult(sql, con, false);
            return aid;
        }
    }
}
