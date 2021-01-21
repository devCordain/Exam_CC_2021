using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MovieLibrary.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class MovieController
    {
        private readonly IListSource listSource;

        public MovieController(IListSource listSource) {
            this.listSource = listSource;
        }

        [HttpGet]
        [Route("/toplist")]
        public IEnumerable<string> Toplist(bool ascendingByRating = true)
        {
            var movies = listSource.GetList();
            if(movies is null) return new List<string>() { "Could not retrieve movies from source" };
            if (ascendingByRating) {
                return movies.OrderBy(movie => double.Parse(movie.rated)).ToList().Select(movie => movie.title);
            }
            else {
                return movies.OrderByDescending(movie => double.Parse(movie.rated)).ToList().Select(movie => movie.title);
            } 
        }
        
        [HttpGet]
        [Route("/movie")]
        public Movie GetMovieById(string id) {
            var movies = listSource.GetList();
            return movies.FirstOrDefault(movie => movie.id == id) ?? null;
        }
    }
}