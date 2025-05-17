using Auditorias.Dominio.Entidades;
using Auditorias.Dominio.Puertos;

namespace Auditorias.Dominio.Servicios
{
    public class AuditoriasPorUsuario(IAuditoriaRepositorio auditoriaRepositorio)
    {
        private readonly IAuditoriaRepositorio _auditoriaRepositorio = auditoriaRepositorio;
        public async Task<List<Auditoria>> ObtenerAuditoriasPorUsuario(Guid usuario)
        {
            if (usuario == Guid.Empty)
            {
                throw new ArgumentException("El ID de usuario no puede ser vacío.");
            }
            return await _auditoriaRepositorio.ObtenerAuditoriasPorUsuario(usuario);
        }
    }
}
