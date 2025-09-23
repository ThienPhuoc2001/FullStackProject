using api.Etc.DTOs;
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
     public ActionResult <IEnumerable<AuthorDto>> GetAuthor()
    {
        return Ok(_service.GetAuthor());
    }
}