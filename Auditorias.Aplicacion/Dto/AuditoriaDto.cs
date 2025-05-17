namespace Auditorias.Aplicacion.Dto
{
    public class AuditoriaDto
    {
        public Guid IdUsuario { get; set; }
        public string Accion { get; set; }
        public string TablaAfectada { get; set; }
        public string Idregistro { get; set; }
        public string Registro { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class AuditoriaOut : BaseOut
    {
        public AuditoriaDto Auditoria { get; set; }
    }

    public class AuditoriaOutList : BaseOut
    {
        public List<AuditoriaDto> Auditorias { get; set; }
    }
}
