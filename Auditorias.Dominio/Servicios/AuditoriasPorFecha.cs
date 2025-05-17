using Auditorias.Dominio.Entidades;
using Auditorias.Dominio.Puertos;

namespace Auditorias.Dominio.Servicios
{
    public class AuditoriasPorFecha(IAuditoriaRepositorio auditoriaRepositorio)
    {
        private readonly IAuditoriaRepositorio _auditoriaRepositorio = auditoriaRepositorio;

        public async Task<List<Auditoria>> ObtenerAuditoriasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }

            if (fechaInicio == null || fechaFin == null)
            {
                throw new ArgumentNullException("Las fechas no pueden ser nulas.");
            }
            return await _auditoriaRepositorio.ObtenerAuditoriasPorFecha(fechaInicio, fechaFin);
        }
    }
}
