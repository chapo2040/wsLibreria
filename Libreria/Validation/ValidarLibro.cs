using Libreria.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wsLibreria.Validation
{
    public class ValidarLibro : ControllerBase
    {
        private readonly AppDbContext _context;

        public ValidarLibro(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Libro> GetLibro(int id)
        {
            return await _context.Libro.FindAsync(id);            
        }

        public async Task<IActionResult> PostLibro(Libro libro)
        {
            if (LibroExists(libro.Id)) { return BadRequest(); }

            _context.Libro.Add(libro);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Libro Agregado con éxito.");
        }

        public bool LibroExists(int id)
        {
            return _context.Libro.Any(e => e.Id == id);
        }

        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            try
            {
                if (id != libro.Id) { return BadRequest(); }
                _context.Entry(libro).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return new OkObjectResult("Libro actualizado con éxito.");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id)) { return new OkObjectResult("Libro no encontrado"); }
                else { throw; }
            }
        }

        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libro.FindAsync(id);
            if (libro == null) { return BadRequest("Libro no encontrado"); }

            _context.Libro.Remove(libro);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Libro borrado con éxito.");
        }
    }
}
