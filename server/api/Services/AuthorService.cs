using api.Etc.DTOs;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace api.Etc;
public interface IAuthorService
{
    IEnumerable<AuthorDto> GetAuthor();
    
}

public class AuthorService : IAuthorService
{
    private readonly NeondbContext _context;
    public AuthorService(NeondbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<AuthorDto> GetAuthor()
    {
        return _context.Set<Author>()
            .Include(a => a.Books)
            .ThenInclude(b => b.Genre)
            .Select(a => new AuthorDto(a))
            .ToList();
    }


}
