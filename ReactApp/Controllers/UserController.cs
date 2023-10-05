
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReactApp.Context;
using ReactApp.Models.Data;

namespace ReactApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly DataDbContext _context;

        public UserController(DataDbContext context)
        {
            _context = context;
        }
   
        [HttpGet]
        public async Task<IActionResult> Ge()
        {
            return Ok(await _context.User.ToListAsync());
        }
    
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("fungujeme");
        }

        //// GET: User/Edit/5
     
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int? id)
        {
            // int id = 2;
            if (id == null)
            {
                return NotFound();
            }

            var uzivatele = await _context.User.FindAsync(id);
            if (uzivatele == null)
            {
                return NotFound();
            }
            return Ok(uzivatele);
        }


        [HttpPut]
        // public async Task<IActionResult> Edit()
        public async Task<IActionResult> Edit([FromBody]  User user)
        {

            Logger.LogDebug($"Editace uzivatele");


            if (user == null) { return BadRequest(StatusCodes.Status500InternalServerError); }
            _context.Update(user);
            await _context.SaveChangesAsync();

            return Ok(StatusCodes.Status200OK);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usr = await _context.User.FindAsync(id);
            if (usr == null) { return BadRequest(StatusCodes.Status500InternalServerError); }
            _context.Remove(usr);
            await _context.SaveChangesAsync();

            return Ok(StatusCodes.Status200OK);
        }

        //// POST: Zam/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

    }
}
