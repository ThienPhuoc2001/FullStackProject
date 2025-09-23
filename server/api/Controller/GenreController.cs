using api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api.Etc;

public class GenreController  : ControllerBase {
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }
        
     [Route("/genres")]
     public ActionResult <IEnumerable<GenreDto>>GetGenres()
     {
         return Ok(_service.GetGenres());
     }
}