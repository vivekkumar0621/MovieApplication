using Microsoft.Extensions.Configuration;
using MovieApplication.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Database
{
    public class PosterRepository
    {
        private DBConnection dbcon;
        public PosterRepository(IConfiguration config)
        {
            dbcon = new DBConnection(config);
        }

        public Poster getPosterByPID(int PID)
        {
            Poster poster = new Poster();
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select * from Poster where PosterID = "+PID+";";
            DataTable dt = dbcon.GetResult(sql, con, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                poster.PosterID = PID;
                poster.PosterName = dt.Rows[i]["PosterName"].ToString();
                poster.PosterLocation = dt.Rows[i]["PosterLocation"].ToString();
            }
            return poster;
        }

        public int uploadImage(FileInfo file)
        {
            //string fileName = file.Name;
            
            return 100;
        }
        
    }
}
