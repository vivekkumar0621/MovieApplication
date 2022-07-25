using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApplication.Database;
using MovieApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieRepository movieRepository;
        private ActorRepository actorRepository;
        private ProducerRepository producerRepository;
        private PosterRepository posterRepository;

        public MovieController(IConfiguration config)
        {
            movieRepository = new MovieRepository(config);
            actorRepository = new ActorRepository(config);
            producerRepository = new ProducerRepository(config);
            posterRepository = new PosterRepository(config);
        }

        [HttpPost]
        [Route("AddMovie")]
        public Movie AddMovie(MovieInfo movieInfo)
        {
            Movie movie = new Movie();
            movie.MovieName = movieInfo.MovieName;
            movie.Plot = movieInfo.Plot;
            movie.DateOfRelease = movieInfo.DateOfRelease;
            movie.PID = movieInfo.PID;
            movie.PosterID = posterRepository.uploadImage(movieInfo.file);
            movie.MID = movieRepository.addMovie(movie);
            
            movieRepository.addMovieActor(movie.MID, movieInfo.ActorsID);
            
            return movie;
        }

        [HttpPost]
        [Route("EditMovie")]
        public MovieInfo EditMovie(int MID)
        {
            MovieInfo movie = movieRepository.GetMoviesByID(MID);
            return movie;
        }

        [HttpGet]
        [Route("GetProducers")]
        public List<String> GetProducers()
        {
            List<String> list = producerRepository.GetProducerNames();
            
            return list;
        }

        [HttpGet]
        [Route("GetActors")]
        public List<String> GetActors()
        {
            List<String> list = actorRepository.GetActorNames();
            
            return list;
        }


    }
}
