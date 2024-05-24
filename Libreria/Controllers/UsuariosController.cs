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
    public class UsuariosController(AppDbContext _context) : ControllerBase
    {
        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost("UsuarioLogin")]
        public ActionResult UsuarioCheck(Usuario usuario)
        {
            Usuario loUsuario = validarUsuario(usuario.Username, usuario.Password);
            if (loUsuario != null)
            {
                return Ok(new Resultado(1, "contraeña correcta", loUsuario));
            }
            else
            {
                return Ok(new Resultado(2, "Usuario y/o contraseña incorrecta."));
            }
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }

        private Usuario validarUsuario(string user, string password)
        {
            //bool lbResultado = _context.Usuario.Any(e => e.Username.ToUpper() == user.ToUpper() && e.Password.ToUpper() == password.ToUpper());
            Usuario loUsuario = _context.Usuario.FirstOrDefault(e => e.Username.ToUpper() == user.ToUpper() && e.Password.ToUpper() == password.ToUpper());
            
            return loUsuario;
        }
    }
}
