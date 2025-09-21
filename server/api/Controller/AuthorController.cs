using Microsoft.AspNetCore.Mvc;

namespace api.Etc;

public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }

    [Route("/authors")]
    public ActionResult GetAuthor()
    {
        return Ok(_service.GetAuthor());
    }
}