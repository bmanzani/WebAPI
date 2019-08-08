using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entity;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers.API
{
    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly SSIS_TESTEContext _context;

        public ValuesController(SSIS_TESTEContext context)
        {
            _context = context;
        }

        // GET api/values 
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ListTableAPI = await APIModel.GetAllValues(_context);
            return Ok(ListTableAPI);
        }

        // GET api/values/5
        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TableApi tableApi = await APIModel.GetValues(id, _context);
            return Ok(tableApi);
        }

        // POST api/values
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TableApi tableApi)
        {
            await APIModel.PostValues(tableApi, _context);
            return Ok();
        }
    }
}
