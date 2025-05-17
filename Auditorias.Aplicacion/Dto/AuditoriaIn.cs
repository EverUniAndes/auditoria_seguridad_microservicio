using System.ComponentModel.DataAnnotations.Schema;

namespace Auditorias.Aplicacion.Dto
{
    public class AuditoriaIn
    {
        public Guid IdUsuario { get; set; }
        public string Accion { get; set; }
        public string TablaAfectada { get; set; }
        public string Idregistro { get; set; }
        public string Registro { get; set; }
    }
}
