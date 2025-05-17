using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auditorias.Dominio.Entidades
{
    public class EntidadBase
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("fecharegistro")]
        public DateTime FechaCreacion { get; set; }
    }
}
