using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        private readonly DataContext _context;

        public AddController(DataContext context)
        {
            _context = context;
        }

        // POST: api/outputs
        [HttpPost]
        public async Task<ActionResult<IEnumerable<outputAdd>>> Getoutput(inputAdd input)
        {
            string StoredProc = "EXEC [inspectionapidb].[dbo].[AddMessage] " +
                    "@ContactName = '" + input.ContactName + "'," +
                    "@Phone = '" + input.Phone + "'," +
                    "@Email= '" + input.Email + "'," +
                    "@Title= '" + input.Title + "'," +
                    "@Message_text= '" + input.Message_text + "'";

            return await _context.output.FromSqlRaw(StoredProc).ToListAsync();
        }

        
    }
}
