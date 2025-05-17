using Auditorias.Dominio.Entidades;
using Auditorias.Dominio.Puertos;
using Auditorias.Infraestructura.RepositoriosGenericos;

namespace Auditorias.Infraestructura.Repositorios
{
    public class AuditoriaRepositorio: IAuditoriaRepositorio
    {
        private readonly IRepositorioBase<Auditoria> _repositorioBase;

        public AuditoriaRepositorio(IRepositorioBase<Auditoria> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public async Task RegistrarAuditoria(Auditoria auditoria)
        {
            await _repositorioBase.Crear(auditoria);
        }

        public async Task<List<Auditoria>> ObtenerAuditoriasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _repositorioBase.BuscarPorFecha(fechaInicio, fechaFin);
        }

        public async Task<List<Auditoria>> ObtenerAuditoriasPorUsuario(Guid usuario)
        {
            return await _repositorioBase.BuscarPorUsuario(usuario);
        }

    }
}
