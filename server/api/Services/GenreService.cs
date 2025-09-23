using api.DTOs;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace api.Etc;

public interface IGenreService
{
    IEnumerable<GenreDto> GetGenres();
}
public class GenreService : IGenreService
{
    private readonly NeondbContext _context;
    public GenreService(NeondbContext context)
    {
        _context = context;
    }
    public IEnumerable<GenreDto> GetGenres()
    {
        return _context.Genres
            .Include (g => g.Books)
            .ThenInclude (b => b.Authors)
            .Select(g => new GenreDto(g))
            .ToList();
            
    }
}