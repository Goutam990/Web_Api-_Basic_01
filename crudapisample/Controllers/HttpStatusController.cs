using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace crudapisample.Controllers;


[ApiController]
[Route("[controller]")]
public class HttpStatusController : ControllerBase
{
 
    // 200 Ok 
    [HttpGet("ok")]
    public IActionResult GetOk()
    {
        return Ok("This is a successful response.");
    }

    //201 Created
    [HttpPost("create")]
    public IActionResult PostCreated()
    {
        var newItem = new { Id = 1, Name = "New Item" };
        return Created("", newItem);
    }

    // 204 No Content 
    [HttpPut("putnocontent")]
    public IActionResult PutNoContent()
    {
        return NoContent();
    }

    // delete 
    [HttpDelete("delete")]
    public IActionResult Delete()
    {
        return NoContent();
    }

    // 400 Bad Request
    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        return BadRequest("This is a bad request. This request is invalid.");
    }

    //401 Unauthorized
    [HttpGet("unauthorized")]
    public IActionResult GetUnthorized()
    {
        return Unauthorized("You must be authenticated to access this resource."); 
    }

    //403 Forbidden
    [HttpGet("forbidden")]
    public IActionResult GetForbidden()
    {
        return StatusCode(StatusCodes.Status403Forbidden, new{message = "You're not allowed to access this resource."});
    }

    // 404 Not Found
    [HttpGet("notfound")]
    public IActionResult GetNotFound()
    {
        return NotFound("The resouce code not be found.");
    }


    // 500 Internal Server Error.
    [HttpGet("servererror")]
    public IActionResult GetServerError()
    {
        return StatusCode(StatusCodes.Status500InternalServerError, new{message = "An internal server error occurred."});
    }

}


