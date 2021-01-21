using System.Collections.Generic;
namespace MovieLibrary {
    public interface IListSource {
        abstract List<Movie> GetList();
    }
}
