using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary;

namespace Test {
    class ListSourceMock : IListSource {
        private readonly List<Movie> movies;

        public ListSourceMock(List<Movie> movies) {
            this.movies = movies;
        }
        public List<Movie> GetList() {
            return movies;
        }
    }
}
