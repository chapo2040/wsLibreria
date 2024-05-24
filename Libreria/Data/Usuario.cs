using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    [PrimaryKey(nameof(Id))]
    public class Usuario
    {        
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }        
    }
}
