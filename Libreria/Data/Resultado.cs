using Libreria.Data;

namespace wsLibreria.Data
{
    public class Resultado
    {
        public int error {  get; set; }
        public string? mensaje { get; set; }
        public Usuario usuario { get; set; }

        public Resultado(int piError, string? psMensaje) 
        {
            this.error = piError; 
            this.mensaje = psMensaje;
        }

        public Resultado(int piError, string? psMensaje, Usuario loUsuario)
        {
            this.error = piError;
            this.mensaje = psMensaje;
            this.usuario = loUsuario;
        }
    }
}
