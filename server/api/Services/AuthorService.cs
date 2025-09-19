namespace api.Etc;
public interface IAuthorService
{
    List<string> GetAuthor();
}

public class AuthorService : IAuthorService
{
    public AuthorService()
    {
        Console.WriteLine("AuthorService being used");
    }

    public List<string> GetAuthor()
    {
        throw new NotImplementedException();
    }

}
