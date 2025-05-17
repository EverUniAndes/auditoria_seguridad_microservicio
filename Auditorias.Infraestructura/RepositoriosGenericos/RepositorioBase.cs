using Auditorias.Dominio.Entidades;
using Auditorias.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Auditorias.Infraestructura.RepositoriosGenericos
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadBase
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositorioBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private AuditoriaBDContext GetContext() 
        {
            return _serviceProvider.GetService<AuditoriaBDContext>();
        }

        protected DbSet<T> GetEntitySet()
        {
            return GetContext().Set<T>();
        }

        public async Task<T> Crear(T entity)
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            var res = await entitySet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> BuscarPorUsuario(Guid ValueAttribute)
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            var res = await entitySet.Where(v => EF.Property<Guid>(v, "IdUsuario") == ValueAttribute).ToListAsync();
            await _context.DisposeAsync();
            return res;
        }

        public async Task<List<T>> BuscarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            var res = await entitySet.Where(v => v.FechaCreacion.Date >= fechaInicio.Date && v.FechaCreacion.Date <= fechaFin.Date).ToListAsync();
            await _context.DisposeAsync();
            return res;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                try
                {
                    var ctx = GetContext();
                    ctx.Dispose();
                }
                catch (Exception ex)
                { }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
