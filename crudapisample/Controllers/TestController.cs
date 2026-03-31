using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace crudapisample.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class TestController : ControllerBase
// {
//     [HttpGet]
//     public IActionResult Get()
//     {
//         // return Ok(HttpStatusCode.OK);
//         return Ok("Api is Running");
//     }
// }


// [ApiController]
// [Route("[controller]")]
// public class TestController : ControllerBase
// {
//     [HttpGet("{id:int}")]
//     public IActionResult Get(int id)
//     {
//         string[] colors = ["Red", "Green", "Blue"];

//         if (id > 0 && id <= colors.Length - 1)
//             return Ok(colors[id]);
//         else
//             return BadRequest("In this index color not exist");


//     }
// }


// [ApiController]
// [Route("[controller]")]
// public class TestController : ControllerBase
// {
//     [HttpGet("{id:int}")]
//     public IActionResult Get(int id)
//     {
//         string[] colors = ["Red", "Green", "Blue"];

//         return Ok(colors);
//     }
// }

// [ApiController]
// [Route("[controller]")]
// public class TestController : ControllerBase
// {
//     //Update Array to use the Generic list, in this way ,if i added more colors to the list it will added to the array
//     // when i post any color it will be added to the list.
//     public static List<string> colors = new() { "Red", "Green" , "Blue" };

//     [HttpGet]
//     public IActionResult Get()
//     {
//         return Ok(colors);
//     }
// }


// ======================================= Post Method to add new color to the list ===================
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    //Update Array to use the Generic list, in this way ,if i added more colors to the list it will added to the array
    // when i post any color it will be added to the list.
    public static List<string> colors = new() { "Red", "Green" , "Blue" };


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(colors);
    }

    [HttpPost]
    public IActionResult Post([FromBody]string Newcolor)
    {
        if (string.IsNullOrWhiteSpace(Newcolor))
            return BadRequest("NewColor is required");

        colors.Add(Newcolor);
        return Created("", Newcolor);
    }

    [HttpPut("{index:int}")]
    public IActionResult Put(int index, [FromBody] string UpdatedColor)
    {
        if (index < 0 || index >= colors.Count)
            return BadRequest("Invalid Index");

        if (string.IsNullOrWhiteSpace(UpdatedColor))
            return BadRequest("UpdatedColor is required");
        
        colors[index] = UpdatedColor;
        return Ok(colors[index]);
    }

    [HttpDelete("{index:int}")]
    public IActionResult Delete(int index)
    {
        if (index < 0 || index >= colors.Count)
            return BadRequest("Invalid Index");
        
        string deletedColor = colors[index];
        colors.RemoveAt(index);
        return Ok($"color {deletedColor} is deleted sucessfully");
    }
   
}

