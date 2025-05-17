using Auditorias.Aplicacion.Enum;
using System.Net;

namespace Auditorias.Aplicacion.Dto
{
    public class BaseOut
    {
        public Resultado Resultado { get; set; }
        public string Mensaje { get; set; }
        public Guid? Id { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
