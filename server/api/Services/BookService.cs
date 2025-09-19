namespace api.Etc;

public interface IBookService
{
    List<string> GetBooks();

}
public class BookService : IBookService
{
    public BookService()
    {
        Console.WriteLine("BookService instantiated");
    }
    public List <string> GetBooks()
    {
        throw new NotImplementedException();
    }

   
}