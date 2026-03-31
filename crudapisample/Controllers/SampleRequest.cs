using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace crudapisample.Controllers;


[ApiController]
[Route("[controller]")]
public class SampleRequest : ControllerBase
{
    //QueryString
    [HttpGet]
    public IActionResult Get( [FromQuery] string category, [FromQuery] string sort )
    {
        return Ok($"Category: {category}, Sort: {sort}");
    }

    //Path Parameter 
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok($"Product with id: {id}");
    }

    // Another method to carry api request data is the Request Body. 
    public class Product
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
    }

    // post request which carry data in request body.
    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        return Ok($"Product created: Name: {product.Name}, Price: {product.Price}");
    }
}


