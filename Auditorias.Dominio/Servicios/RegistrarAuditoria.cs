using Auditorias.Dominio.Entidades;
using Auditorias.Dominio.Puertos;

namespace Auditorias.Dominio.Servicios
{
    public class RegistrarAuditoria(IAuditoriaRepositorio auditoriaRepositorio)
    {
        private readonly IAuditoriaRepositorio _auditoriaRepositorio = auditoriaRepositorio;

        public async Task<bool> Ejecutar(Auditoria auditoria)
        {
            if (ValidarAuditoria(auditoria))
            {
                auditoria.Id = Guid.NewGuid();
                auditoria.FechaCreacion = DateTime.UtcNow;
                await _auditoriaRepositorio.RegistrarAuditoria(auditoria);
            }

            return true;
        }

        private bool ValidarAuditoria(Auditoria auditoria)
        {
            // Implementar la lógica de validación de la auditoría aquí
            // Por ejemplo, verificar que los campos requeridos no estén vacíos
            if (auditoria.IdUsuario == Guid.Empty || 
                string.IsNullOrEmpty(auditoria.Accion) ||
                string.IsNullOrEmpty(auditoria.TablaAfectada) ||
                string.IsNullOrEmpty(auditoria.Idregistro) ||
                string.IsNullOrEmpty(auditoria.Registro))
            {
                return false;
            }
            return true;
        }
    }
}
