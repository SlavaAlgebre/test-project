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
    public class GetController : ControllerBase
    {
        private readonly DataContext _context;

        public GetController(DataContext context)
        {
            _context = context;
        }

        // POST: api/outputGet
        [HttpPost]
        public async Task<ActionResult<IEnumerable<outputGet>>> Getoutput(inputGet input)
        {
            //string StoredProc = "SELECT Id, MessageSubjectId, ContactId, Message_text FROM Messages WHERE Id = " + input.Id;
            string StoredProc = "SELECT TOP (1) * FROM [inspectionapidb].[dbo].[Messages] ORDER BY Id DESC";

            return await _context.outputGet.FromSqlRaw(StoredProc).ToListAsync();
        }


    }
}
