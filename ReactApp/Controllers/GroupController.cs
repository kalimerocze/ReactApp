
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
using ReactApp.Models.Config;
using ReactApp.Models.Data;

namespace ReactApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class GroupController : ControllerBase
    {

        private readonly ApplicationContext _appCtx;
        private readonly IWebHostEnvironment _env;
        private readonly DataDbContext _context;

        public GroupController(DataDbContext context, ApplicationContext ctx, IWebHostEnvironment env)
        {
            _env = env;
            _appCtx = ctx;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Ge()
        {
            return Ok(await _appCtx.DbContexts.GetDbContext<ConfigDbContext>("ConfigDb").GroupSets.ToListAsync());
        }
    

        //// GET: Group/Edit/5
     
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzivatele = await _appCtx.DbContexts.GetDbContext<ConfigDbContext>("ConfigDb").GroupSets.FindAsync(id);
            if (uzivatele == null)
            {
                return NotFound();
            }
            return Ok(uzivatele);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]  Group user)
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
            var usr = await _appCtx.DbContexts.GetDbContext<ConfigDbContext>("ConfigDb").GroupSets.FindAsync(id);
            if (usr == null) { return BadRequest(StatusCodes.Status500InternalServerError); }
            _context.Remove(usr);
            await _context.SaveChangesAsync();

            return Ok(StatusCodes.Status200OK);
        }

        //// POST: Zam/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  Group user)
        {
            await _appCtx.DbContexts.GetDbContext<ConfigDbContext>("ConfigDb").GroupSets.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

    }
}
