using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApplication.Database;
using MovieApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private MovieRepository movieRepository;
        private ActorRepository actorRepository;
        private ProducerRepository producerRepository;
        private PosterRepository posterRepository;

        public HomeController(IConfiguration config)
        {
            movieRepository = new MovieRepository(config);
            actorRepository = new ActorRepository(config);
            producerRepository = new ProducerRepository(config);
            posterRepository = new PosterRepository(config);
        }

        [HttpGet]
        [Route("GetMovies")]
        public List<MovieDetails> GetMovies()
        {
            List<MovieDetails> list = new List<MovieDetails>();
            List<Movie> movielist = movieRepository.GetMovies();
            foreach(Movie item in movielist)
            {
                MovieDetails detail = new MovieDetails();
                detail.MovieName = item.MovieName;
                detail.DateOfRelease = item.DateOfRelease;
                detail.actorsName = actorRepository.getActorNameByMovie(item.MID);
                detail.ProducerName = producerRepository.getProducerByID(item.PID);
                detail.Plot = item.Plot;
                detail.poster = posterRepository.getPosterByPID(item.PosterID);
                list.Add(detail);
            }
            return list;
        }
    }
}
