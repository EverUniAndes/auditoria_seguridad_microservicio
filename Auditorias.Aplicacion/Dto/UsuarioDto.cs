namespace Auditorias.Aplicacion.Dto
{
    public class UsuarioDto
    {
        public string UserName { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Guid IdRol { get; set; }
    }

    public class UsuarioResponseDto
    {
        public int Resultado { get; set; }
        public string Mensaje { get; set; }
        public int Status { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdRol { get; set; }
        public string UserName { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
