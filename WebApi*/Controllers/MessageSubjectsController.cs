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
    public class MessageSubjectsController : ControllerBase
    {
        private readonly DataContext _context;

        public MessageSubjectsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MessageSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageSubject>>> GetMessageSubjects()
        {
          if (_context.MessageSubjects == null)
          {
              return NotFound();
          }
            return await _context.MessageSubjects.ToListAsync();
        }

        // GET: api/MessageSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageSubject>> GetMessageSubject(int id)
        {
          if (_context.MessageSubjects == null)
          {
              return NotFound();
          }
            var messageSubject = await _context.MessageSubjects.FindAsync(id);

            if (messageSubject == null)
            {
                return NotFound();
            }

            return messageSubject;
        }

        // PUT: api/MessageSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageSubject(int id, MessageSubject messageSubject)
        {
            if (id != messageSubject.Id)
            {
                return BadRequest();
            }

            _context.Entry(messageSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageSubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MessageSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageSubject>> PostMessageSubject(MessageSubject messageSubject)
        {
          if (_context.MessageSubjects == null)
          {
              return Problem("Entity set 'DataContext.MessageSubjects'  is null.");
          }
            _context.MessageSubjects.Add(messageSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageSubject", new { id = messageSubject.Id }, messageSubject);
        }

        // DELETE: api/MessageSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageSubject(int id)
        {
            if (_context.MessageSubjects == null)
            {
                return NotFound();
            }
            var messageSubject = await _context.MessageSubjects.FindAsync(id);
            if (messageSubject == null)
            {
                return NotFound();
            }

            _context.MessageSubjects.Remove(messageSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageSubjectExists(int id)
        {
            return (_context.MessageSubjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
