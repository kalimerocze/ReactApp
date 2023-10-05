//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Migrations;
//using ReactApp.Context;
//using ReactApp.Models.Data;

//namespace ReactApp.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//        private readonly ILogger<WeatherForecastController> _logger;


//        private readonly DataDbContext _context;


//        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataDbContext context)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        [HttpGet]
//        public IEnumerable<Employee> Get()
//        {
//            return _context.Employee.ToList().ToArray();
//        }
//        [ActionName("test")]
//        [HttpDelete("test")]
//        public async Task<IActionResult> Test()
//        {
//            return Ok("test");
//        }

//        [ActionName("Delete")]
//        [HttpDelete("Delete/{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var zam = await _context.Employee.FindAsync(id);
//            if (zam == null) { return BadRequest(StatusCodes.Status500InternalServerError); }
//            _context.Remove(zam);
//            await _context.SaveChangesAsync();

//            return Ok(StatusCodes.Status200OK);
//        }


//    }
//}