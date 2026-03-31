using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace crudapisample.Controllers;


[ApiController]
[Route("[controller]")]
public class JsonSampleController : ControllerBase
{
//    public class Product
//     {
//         public string? Name { get; set; }
//         public int? Price { get; set; }
//         public bool? InStock { get; set; }
//     }

//     [HttpGet]
//     public IActionResult Get()
//     {
//         var product = new Product
//         {
//             Name = "Laptop",
//             Price = 999,
//             InStock = true
//         };
//         return Ok(product);
//     }

   //Json data - Key value pair, value can be string,number,boolean,array,object.
   // demostrating an object in json data
    public class category
    {
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }

   public class Product
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
        public bool? InStock { get; set; }
    }

    [HttpGet]
    public IActionResult Get()
    {
      var category = new category
      {
          Name = "Firstcategory",
          Products = new List<Product>
          {
              new Product {Name= "Product1", Price=100, InStock=true},
              new Product {Name= "Product2", Price=200, InStock=false}
          }
      };
      return Ok(category);
    }


}


