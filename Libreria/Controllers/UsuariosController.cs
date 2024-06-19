using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Libreria.Data;
using wsLibreria.Data;
using wsLibreria.Validation;

namespace Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ValidarUsuario _validarUsuario;

        public UsuariosController(AppDbContext context, ValidarUsuario validarUsuario)
        {
            this._context = context;
            this._validarUsuario = validarUsuario;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            return await _validarUsuario.GetUsuario(id);
        }

        [HttpPost("UsuarioLogin")]
        public ActionResult UsuarioCheck(Usuario usuario)
        {            
            return _validarUsuario.UsuarioCheck(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            return await _validarUsuario.PostUsuario(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            return await _validarUsuario.PutUsuario(id, usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            return await _validarUsuario.DeleteUsuario(id);
        }
    }
}
