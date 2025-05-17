using Auditorias.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Auditorias.Infraestructura.RepositoriosGenericos
{
    public interface IRepositorioBase<T> : IDisposable where T : EntidadBase
    {
        Task<T> Crear(T entity);
        Task<List<T>> BuscarPorUsuario(Guid ValueAttribute);
        Task<List<T>> BuscarPorFecha(DateTime fechaInicio, DateTime fechaFin);
    }
}
