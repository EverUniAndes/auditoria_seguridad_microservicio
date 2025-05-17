using Auditorias.Aplicacion.Dto;

namespace Auditorias.Aplicacion.Consultas
{
    public interface IConsultasAuditoria
    {
        Task<AuditoriaOutList> ObtenerAuditoriasPorFecha(DateTime fechaInicio, DateTime fechaFin);
        Task<AuditoriaOutList> ObtenerAuditoriasPorUsuario(Guid usuario);
    }
}
