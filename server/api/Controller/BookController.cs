using api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api.Etc;

public class BookController : ControllerBase
{
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    [Route("/books")]
    public ActionResult<IEnumerable<BookDto>>GetBooks()
    {
        return Ok(_service.GetBooks());
    }
}