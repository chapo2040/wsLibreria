using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Libreria.Data;
using wsLibreria.Data;

namespace Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController(AppDbContext _context) : ControllerBase
    {
        // GET: api/Libro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibro()
        {
            return await _context.Libro.ToListAsync();
        }

        // GET: api/Libroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libro.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // POST: api/Libro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            if (LibroExists(libro.Id))
            {                
                return Ok(new Resultado(2, "Libro ya existente."));
            }
            else
            {
                _context.Libro.Add(libro);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
            }
        }

        // DELETE: api/Libro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libro.FindAsync(id);
            if (libro == null)
            {
                //return NotFound();               
                return Ok(new Resultado(2, "Libro no encontrado"));
            }

            _context.Libro.Remove(libro);
            await _context.SaveChangesAsync();

            //return NoContent();
            return Ok(new Resultado(1, "Libro borrado con éxito."));
        }

        private bool LibroExists(int id)
        {
            return _context.Libro.Any(e => e.Id == id);
        }

        // PUT: api/Libro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
                {
                    //return NotFound();
                    return Ok(new Resultado(2, "Libro no encontrado"));
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
