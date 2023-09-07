﻿using System;
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
    public class AlimentoesController : ControllerBase
    {
        private readonly VetparcialContext _context;

        public AlimentoesController(VetparcialContext context)
        {
            _context = context;
        }

        // GET: api/Alimentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alimento>>> GetAlimentos()
        {
          if (_context.Alimentos == null)
          {
              return NotFound();
          }
            return await _context.Alimentos.ToListAsync();
        }

        // GET: api/Alimentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alimento>> GetAlimento(int id)
        {
          if (_context.Alimentos == null)
          {
              return NotFound();
          }
            var alimento = await _context.Alimentos.FindAsync(id);

            if (alimento == null)
            {
                return NotFound();
            }

            return alimento;
        }

        // PUT: api/Alimentoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlimento(int id, Alimento alimento)
        {
            if (id != alimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(alimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlimentoExists(id))
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

        // POST: api/Alimentoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alimento>> PostAlimento(Alimento alimento)
        {
          if (_context.Alimentos == null)
          {
              return Problem("Entity set 'VetparcialContext.Alimentos'  is null.");
          }
            _context.Alimentos.Add(alimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlimento", new { id = alimento.Id }, alimento);
        }

        // DELETE: api/Alimentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlimento(int id)
        {
            if (_context.Alimentos == null)
            {
                return NotFound();
            }
            var alimento = await _context.Alimentos.FindAsync(id);
            if (alimento == null)
            {
                return NotFound();
            }

            _context.Alimentos.Remove(alimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlimentoExists(int id)
        {
            return (_context.Alimentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
