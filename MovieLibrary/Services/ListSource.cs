using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace MovieLibrary {
    public class ListSource : IListSource {
        private readonly HttpClient httpClient;
        private readonly IEnumerable<string> serverUrls = new List<string>() {
            "https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json",
            "https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json"
        };

        public ListSource(HttpClient httpClient) {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public List<Movie> GetList() {
            List<Movie> movies = new List<Movie>();
            foreach (var serverUrl in serverUrls) {
                try {
                    var result = httpClient.GetAsync(serverUrl).Result;
                    var content = result.Content.ReadAsStream();
                    var parsedMovies = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(content).ReadToEnd());
                    // I have deliberately chosen to omit checking for null in movie.id because this should not impact user experience
                    var uniqueAndValidMovies = from movie in parsedMovies
                                       where !movies.Contains(movie) && movie.title != null && movie.rated != null && double.TryParse(movie.rated, out double x) != false
                                       select movie;
                    movies.AddRange(uniqueAndValidMovies);
                }
                catch (Exception) {
                    return null;
                }
            }
            return movies;
        }
    }
}
