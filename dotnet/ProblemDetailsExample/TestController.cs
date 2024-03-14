using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProblemDetailsExample;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("{statusCode:int}")]
    public IActionResult GetStatusCode(int statusCode) => StatusCode(statusCode);

    [HttpGet("[action]")]
    [Authorize(Roles = "Administrator")]
    public IActionResult Admin() => Ok();
}