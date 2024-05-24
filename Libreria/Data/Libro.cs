using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    [PrimaryKey(nameof(Id))]
    public class Libro
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Existencia { get; set;}
        public int Prestado { get; set; }

        public Libro() 
        {
        
        }  

        public Libro(int piId, string psNombre, int piExistencia, int piPrestado) 
        { 
            Id = piId;    
            Nombre = psNombre;
            Existencia = piExistencia;            
            Prestado = piPrestado;
        }
    }
}
