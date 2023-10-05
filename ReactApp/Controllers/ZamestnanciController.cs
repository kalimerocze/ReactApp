#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactApp.Context;
using ReactApp.Models.Data;

namespace ReactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZamestnanciController : ControllerBase
    {
        private readonly DataDbContext _context;

        public ZamestnanciController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/Zamestnanci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetPaymentDetails()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/Zamestnanec/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetZamestnanci(int id)
        {
            var zamestnanci = await _context.Employee.FindAsync(id);

            if (zamestnanci == null)
            {
                return NotFound();
            }

            return zamestnanci;
        }

        // PUT: api/Zamestnanci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZamestnanci(int id, Employee zamestnanci)
        {
            if (id != zamestnanci.Id)
            {
                return BadRequest();
            }

            _context.Entry(zamestnanci).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!ZamestnanciExists(id))
                {
                    return NotFound();
                }
                else
                {
                    Logger.LogError($"Nastala chyba: data -  {e.Data}, mesage - {e.Message}, source - {e.Source}, stack trace - {e.StackTrace}");
                }
            }

            return NoContent();
        }

        // POST: api/Zamestnanci
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostZamestnanci(Employee zamestnanci)
        {
            _context.Employee.Add(zamestnanci);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZamestnanci", new { id = zamestnanci.Id }, zamestnanci);
        }

        // DELETE: api/Zamestnanci/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZamestnanci(int id)
        {
            var zamestnanci = await _context.Employee.FindAsync(id);
            if (zamestnanci == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(zamestnanci);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZamestnanciExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }


    }
}
