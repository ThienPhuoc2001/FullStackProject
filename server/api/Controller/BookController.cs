using Microsoft.AspNetCore.Mvc;

namespace api.Etc;

public class BookController : ControllerBase
{
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    [Route("/")]
    public ActionResult GetBooks()
    {
        return Ok(_service.GetBooks());
    }
}
    
