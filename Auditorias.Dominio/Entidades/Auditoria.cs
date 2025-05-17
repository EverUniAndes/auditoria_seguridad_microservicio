
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auditorias.Dominio.Entidades
{
    [Table("tbl_auditoria")]
    public class Auditoria : EntidadBase
    {
        [Column("idusuario")]
        public Guid IdUsuario { get; set; }
        
        [Column("accion")]
        public string Accion { get; set; }

        [Column("tablaafectada")]
        public string TablaAfectada { get; set; }

        [Column("idregistro")]
        public string Idregistro { get; set; }

        [Column("registro")]
        public string Registro { get; set; }
    }
}
