using api.DTOs;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace api.Etc;

public interface IBookService
{
    IEnumerable<BookDto> GetBooks();

}
public class BookService : IBookService
{
    private readonly NeondbContext _context;
    
    public BookService(NeondbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<BookDto> GetBooks()
    {
        // This fetches the books, includes their related authors and genre,
        // and converts them to the BookDto format.
        return _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Genre)
            .Select(b => new BookDto(b))
            .ToList();    }
    
}