using Microsoft.AspNetCore.Mvc;

namespace DemoRouting_Group03.Controllers
{

    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /*
         Attribute Routing
        */
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<string> e = new List<string>();
            e.Add("Doiden");
            e.Add("Khong con e");
            return Ok(e);
        }

        [HttpGet]
        [Route("api/[controller]/EmployeeByID")]
        public IActionResult GetEmployeeById([FromQuery] int id)
        {
            return Ok("Khong con gi");
        }
    }

}
