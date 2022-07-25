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
    public class ProducerController : ControllerBase
    {
        private MovieRepository movieRepository;
        private ActorRepository actorRepository;
        private ProducerRepository producerRepository;
        private PosterRepository posterRepository;

        public ProducerController(IConfiguration config)
        {
            movieRepository = new MovieRepository(config);
            actorRepository = new ActorRepository(config);
            producerRepository = new ProducerRepository(config);
            posterRepository = new PosterRepository(config);
        }

        [HttpPost]
        [Route("AddProducer")]
        public int AddProducer(Producer producer)
        {
            int pid = producerRepository.AddProducer(producer);

            return pid;
        }
    }
}
