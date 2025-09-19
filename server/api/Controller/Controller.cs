using Microsoft.AspNetCore.Mvc;

namespace api.Etc;

public class Controller : ControllerBase
{
    private readonly IService _service;

    public Controller(IService service)
    {
        _service = service;
    } 
    
    [Route("/")]
    public ActionResult GetItems()
    {
        return Ok(_service.GetItems());
    }
    
}