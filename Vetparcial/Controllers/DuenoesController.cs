using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vetparcial.Models;

namespace Vetparcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuenoesController : ControllerBase
    {
        private readonly VetparcialContext _context;

        public DuenoesController(VetparcialContext context)
        {
            _context = context;
        }

        // GET: api/Duenoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dueno>>> GetDuenos()
        {
          if (_context.Duenos == null)
          {
              return NotFound();
          }
            return await _context.Duenos.ToListAsync();
        }

        // GET: api/Duenoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dueno>> GetDueno(int id)
        {
          if (_context.Duenos == null)
          {
              return NotFound();
          }
            var dueno = await _context.Duenos.FindAsync(id);

            if (dueno == null)
            {
                return NotFound();
            }

            return dueno;
        }

        // PUT: api/Duenoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDueno(int id, Dueno dueno)
        {
            if (id != dueno.Id)
            {
                return BadRequest();
            }

            _context.Entry(dueno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuenoExists(id))
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

        // POST: api/Duenoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dueno>> PostDueno(Dueno dueno)
        {
          if (_context.Duenos == null)
          {
              return Problem("Entity set 'VetparcialContext.Duenos'  is null.");
          }
            _context.Duenos.Add(dueno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDueno", new { id = dueno.Id }, dueno);
        }

        // DELETE: api/Duenoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDueno(int id)
        {
            if (_context.Duenos == null)
            {
                return NotFound();
            }
            var dueno = await _context.Duenos.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }

            _context.Duenos.Remove(dueno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DuenoExists(int id)
        {
            return (_context.Duenos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
