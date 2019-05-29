using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Models;
using Microsoft.AspNetCore.Hosting;


namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;
        
        private IHostingEnvironment _hostEnv;

        public CommandsController(CommandContext context, IHostingEnvironment hostEnv)
        {
            _context = context;
            _hostEnv = hostEnv;
        }

        //GET:      api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommandItems()
        {
            Response.Headers.Add("Environment", _hostEnv.EnvironmentName);
            return _context.CommandItems;
        }

        /* COMMETED OUT - DELETE LATER
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this", "is", "hard", "coded"};
        }
        */
    }
}

