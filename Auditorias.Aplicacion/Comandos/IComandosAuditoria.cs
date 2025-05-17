using Auditorias.Aplicacion.Dto;

namespace Auditorias.Aplicacion.Comandos
{
    public interface IComandosAuditoria
    {
        Task<BaseOut> RegistrarAuditoria(AuditoriaIn auditoria);
    }
}
