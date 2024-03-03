using Microsoft.AspNetCore.Mvc;

namespace DemoRouting_Group03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /*
         Multiple URLs for a Single Resource using Routing
         */
        [HttpGet]
        [Route("Categories")]
        [Route("Categories/GetAll")]
        [Route("Categories/All")]
        public IActionResult GetCategories()
        {
            List<string> e = new List<string>();
            e.Add("Beer");
            e.Add("Food");
            return Ok(e);
        }


        /*
         * Variables and Query Strings in Routing
         * Passing Multiple dynamic Values
         */
        [HttpGet("GetByIdPath/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok("Category By ID Path");
        }

        [HttpGet("GetByIdQuery")]
        public IActionResult GetCategoryById1([FromQuery] int id)
        {
            return Ok("Category By ID Query");
        }

        [HttpGet("SearchByPath/{id}/{name}")]
        public IActionResult GetCategoryBySearchPath(int id, string name)
        {
            return Ok("GetCategoryBySearch Path");
        }

        [HttpGet("SearchByQuery")]
        public IActionResult GetCategoryBySearchQuery([FromQuery] int id, [FromQuery] string name)
        {
            return Ok("GetCategoryBySearch Query");
        }
    }
}
