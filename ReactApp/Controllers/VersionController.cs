
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReactApp.Context;

namespace ReactApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VersionController : ControllerBase
    {
        private readonly ApplicationContext _appCtx;
        private readonly IWebHostEnvironment _env;
        private readonly DataDbContext _context;

        public VersionController(DataDbContext context,ApplicationContext ctx, IWebHostEnvironment env)
        {
            _env = env;
            _appCtx = ctx;
            _context = context;
        }

        //api/verze
        [HttpGet]
        public async Task<ActionResult> Test2()
        {
            var verze =  Version.GetVerze();

            return Ok($"{verze.Name}: {verze.Version}");
        }
    }
}
