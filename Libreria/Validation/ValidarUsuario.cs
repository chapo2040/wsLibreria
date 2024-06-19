using Libreria.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wsLibreria.Data;

namespace wsLibreria.Validation
{
    public class ValidarUsuario: ControllerBase
    {
        private readonly AppDbContext _context;

        public ValidarUsuario(AppDbContext context) 
        {
            this._context = context;
        }

        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) { return NotFound(); }
            return usuario;
        }

        public ActionResult UsuarioCheck(Usuario usuario)
        {            
            Usuario loUsuario = _context.Usuario.FirstOrDefault(e => e.Username.ToUpper() == usuario.Username.ToUpper() && e.Password.ToUpper() == usuario.Password.ToUpper());
            if (loUsuario != null) { return Ok(new Resultado(1, "contraeña correcta", loUsuario)); }
            else
            { return Ok(new Resultado(2, "Usuario y/o contraseña incorrecta.")); }            
        }

        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            try
            {
                if (id != usuario.Id) { return BadRequest(); }
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id)) { return NotFound(); }
            }

            return NoContent();
        }

        public bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) { return NotFound(); }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
