
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReactApp.Context;
using ReactApp.Models.Data;

namespace ReactApp.Controllers
{

    class Product
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
        public int Desc { get; set; }
    }
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]

    public class EmployeeController : ControllerBase
    {
        private readonly DataDbContext _context;

        public EmployeeController(DataDbContext context)
        {
            _context = context;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zam = await _context.Employee.FindAsync(id);
            if (zam == null) { return BadRequest(StatusCodes.Status500InternalServerError); }
            _context.Remove(zam);
            await _context.SaveChangesAsync();
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;

            return Ok(response);
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _context.Employee.ToList().ToArray();
        }
        [AllowAnonymous]
        [HttpOptions]
        public IActionResult Options()
        {
            return Ok();
        }
        [HttpGet("test2")]
        public async Task<ActionResult> Test2()
        {
            List<Product> people = new()
                {
                    new Product { Id = 1, productName = "Lg", price = 30 },
                    new Product { Id = 2, productName = "Samsung", price = 5 }
                };

            return Ok(people);
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("fungujeme");
        }

        //// GET: Zam/Edit/5
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamestnanci = await _context.Employee.FindAsync(id);
            if (zamestnanci == null)
            {
                return NotFound();
            }
            return Ok(zamestnanci);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (employee == null) { return BadRequest(StatusCodes.Status500InternalServerError); }
            _context.Update(employee);
            await _context.SaveChangesAsync();

            return Ok(StatusCodes.Status200OK);
        }



        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employeeObj)
        {
            await _context.Employee.AddAsync(employeeObj);
            await _context.SaveChangesAsync();
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;

            return Ok(response);
        }
    }
}
