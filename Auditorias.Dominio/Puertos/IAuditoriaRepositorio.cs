using Auditorias.Dominio.Entidades;

namespace Auditorias.Dominio.Puertos
{
    public interface IAuditoriaRepositorio
    {
        Task RegistrarAuditoria(Auditoria auditoria);
        Task<List<Auditoria>> ObtenerAuditoriasPorFecha(DateTime fechaInicio, DateTime fechaFin);
        Task<List<Auditoria>> ObtenerAuditoriasPorUsuario(Guid usuario);
    }
}
