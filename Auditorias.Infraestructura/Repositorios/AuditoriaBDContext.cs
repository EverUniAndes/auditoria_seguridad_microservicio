using Auditorias.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Auditorias.Infraestructura.Repositorios
{
    public class AuditoriaBDContext: DbContext
    {
        public AuditoriaBDContext(DbContextOptions<AuditoriaBDContext> options) : base(options)
        {
        }
        public DbSet<Auditoria> Auditoria { get; set; }
    }
}
