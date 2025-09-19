using DataAccess;

namespace api.Etc;

public partial interface IGenreService
{
    List<string> GetGenres();
}
public class GenreService : IGenreService
{
    public GenreService()
    {
        Console.WriteLine("GenreService being used");
    }
    public List<string> GetGenres()
    {
        throw new NotImplementedException();
    }
}