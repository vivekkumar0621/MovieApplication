using Microsoft.Extensions.Configuration;
using MovieApplication.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Database
{
    public class MovieRepository
    {
        private DBConnection dbcon;
        ActorRepository actorRepository;

        public MovieRepository(IConfiguration config)
        {
            dbcon = new DBConnection(config);
            actorRepository = new ActorRepository(config);
        }

        public List<Movie> GetMovies()
        {
            List<Movie> list = new List<Movie>();
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select * from Movie";
            DataTable dt = dbcon.GetResult(sql, con, false);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                Movie movie = new Movie();
                movie.MID = Convert.ToInt32(dt.Rows[i]["MID"].ToString());
                movie.MovieName = dt.Rows[i]["MovieName"].ToString();
                movie.Plot = dt.Rows[i]["Plot"].ToString();
                movie.DateOfRelease = dt.Rows[i]["DateOfRelease"].ToString();
                movie.PID = Convert.ToInt32(dt.Rows[i]["PID"].ToString());
                movie.PosterID = Convert.ToInt32(dt.Rows[i]["PosterID"].ToString());
                list.Add(movie);
            }
            return list;
        }

        public int addMovie(Movie movie)
        {
            MySqlConnection con = dbcon.GetConnection();
            String sql = "insert into Movie(MovieName, Plot, DateOfRelease, PID, PosterID) values ('" + movie.MovieName + "', '" + movie.Plot + "', '" + movie.DateOfRelease + "', " + movie.PID + ", " + movie.PosterID + ");";
            int mid = dbcon.SetResult(sql, con, false);
            return mid;
        }

        public void addMovieActor(int MID, List<int> ActorsID )
        {
            MySqlConnection con = dbcon.GetConnection();
            foreach(int aid in ActorsID)
            {
                String sql = "insert into MovieActor values(" + aid + ", " + MID + ";";
                dbcon.SetResult(sql, con, false);
            }
        }

        public MovieInfo GetMoviesByID(int MID)
        {
            MovieInfo movieInfo = new MovieInfo();
            
            MySqlConnection con = dbcon.GetConnection();
            String sql = "select * from Movie where MID = "+MID+";";
            DataTable dt = dbcon.GetResult(sql, con, false);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                movieInfo.MovieName = dt.Rows[i]["MovieName"].ToString();
                movieInfo.Plot = dt.Rows[i]["Plot"].ToString();
                movieInfo.DateOfRelease = dt.Rows[i]["DateOfRelease"].ToString();
                movieInfo.PID = Convert.ToInt32(dt.Rows[i]["PID"].ToString());
                
            }

            movieInfo.ActorsID = actorRepository.getActorIDByMovie(MID);
            return movieInfo;
        }

    }
}
