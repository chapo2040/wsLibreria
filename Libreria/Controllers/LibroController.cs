using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Libreria.Data;
using wsLibreria.Data;
using wsLibreria.Validation;

namespace Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class LibroController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ValidarLibro _validarLibro;

        public LibroController(AppDbContext context)
        {
            this._context = context;
            this._validarLibro = new ValidarLibro(context); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibro()
        {
            return await _context.Libro.ToListAsync();
        }
                
        [HttpGet("{id}")]
        public async Task<Libro> GetLibro(int id)
        {
            return await _validarLibro.GetLibro(id);            
        }

        [HttpPost]
        public async Task<IActionResult> PostLibro(Libro libro)
        {            
            return await _validarLibro.PostLibro(libro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            return await _validarLibro.PutLibro(id, libro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            return await _validarLibro.DeleteLibro(id);
        }
    }
}
