using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary;
using MovieLibrary.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Test {
    [TestClass]
    public class MovieControllerTest {
        List<Movie> defaultTestMovies = new List<Movie>() {
            new Movie() {
                id = "0",
                title = "Memento",
                rated = "5"
            },
            new Movie() {
                id = "1",
                title = "Clash of the Titans",
                rated = "0"
            },
            new Movie() {
                id = "2",
                title = "Interstellar",
                rated = "11"
            },
            new Movie() {
                id = "3",
                title = "Dumb and dumber",
                rated = "6"
            },
        };

        [TestMethod]
        public void Get_toplist_returns_ascending_list_of_movies_when_no_condition_set() {
            var controller = new MovieController(new ListSourceMock(defaultTestMovies));
            var actual = controller.Toplist();
            Assert.AreEqual(defaultTestMovies[1].title, actual.First());
            Assert.AreEqual(defaultTestMovies[2].title, actual.Last());
        }

        [TestMethod]
        public void Get_toplist_returns_ascending_list_of_movies() {
            var controller = new MovieController(new ListSourceMock(defaultTestMovies));
            var actual = controller.Toplist(true);
            Assert.AreEqual(defaultTestMovies[1].title, actual.First());
            Assert.AreEqual(defaultTestMovies[2].title, actual.Last());
        }

        [TestMethod]
        public void Get_toplist_returns_descending_list_of_movies() {
            var controller = new MovieController(new ListSourceMock(defaultTestMovies));
            var actual = controller.Toplist(false);
            Assert.AreEqual(defaultTestMovies[2].title, actual.First());
            Assert.AreEqual(defaultTestMovies[1].title, actual.Last());
        }

        [TestMethod]
        public void Get_toplist_returns_expected_error() {
            var controller = new MovieController(new ListSourceMock(null));
            var actual = controller.Toplist();
            Assert.AreEqual("Could not retrieve movies from source", actual.First());
        }

        [TestMethod]
        public void Get_movie_by_id_returns_expected_movie() {
            var controller = new MovieController(new ListSourceMock(defaultTestMovies));
            var testId = "1";
            var actual = controller.GetMovieById(testId);
            Assert.AreEqual(testId, actual.id);
            Assert.AreEqual(defaultTestMovies[1].title, actual.title);
            Assert.AreEqual("0", actual.rated);
        }

        [TestMethod]
        public void Get_movie_by_id_returns_expected_error() {
            var controller = new MovieController(new ListSourceMock(defaultTestMovies));
            var testId = "bogusId";
            var actual = controller.GetMovieById(testId);
            Assert.IsNull(actual);
        }
    }
}
