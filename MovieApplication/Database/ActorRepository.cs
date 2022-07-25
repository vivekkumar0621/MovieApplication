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
    public class ActorRepository
    {
        private DBConnection dbcon;
        public ActorRepository(IConfiguration config)
        {
            dbcon = new DBConnection(config);
        }

        public List<Actor> GetActor()
        {
            List<Actor> list = new List<Actor>();
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select * from Movie";
            DataTable dt = dbcon.GetResult(sql, con, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Actor actor = new Actor();
                actor.AID = Convert.ToInt32(dt.Rows[i]["MID"].ToString());
                list.Add(actor);
            }
            return list;
        }

        public List<String> getActorNameByMovie(int MID)
        {
            List<String> list = new List<String>();
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select AID from MovieActor where MID = " + MID+";";
            DataTable dt = dbcon.GetResult(sql, con, false);
            string aid = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                aid += dt.Rows[i]["AID"].ToString() + ',';
            }
            if(!string.IsNullOrWhiteSpace(aid))
                aid = aid.Substring(0, aid.Length - 1);
            sql = "select * from Actor where AID in (" + aid + ");";
            dt.Clear();
            dt = dbcon.GetResult(sql, con, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i]["ActorName"].ToString());
            }
            return list;
        }

        public List<String> GetActorNames()
        {
            List<String> list = new List<String>();
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select ActorName from Actor";
            DataTable dt = dbcon.GetResult(sql, con, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["ActorName"].ToString();
                list.Add(name);
            }
            return list;
        }

        public int AddActor(Actor actor)
        {
            MySqlConnection con = dbcon.GetConnection();
            String sql = "insert into Actor (ActorName,Bio,DOB,Gender) values ('"+ actor.ActorName + "' , '" + actor.Bio + "', '" + actor.DOB + "', '" + actor.Gender + "')";
            int aid = dbcon.SetResult(sql, con, false);
            return aid;
        }

        public List<int> getActorIDByMovie(int MID)
        {
            List<int> list = new List<int>();
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select AID from MovieActor where MID = " + MID + ";";
            DataTable dt = dbcon.GetResult(sql, con, false);
            string aid = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(Convert.ToInt32(dt.Rows[i]["AID"].ToString()));
            }
            
            return list;
        }


    }
}
