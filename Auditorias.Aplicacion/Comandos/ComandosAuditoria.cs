using Auditorias.Aplicacion.Dto;
using Auditorias.Aplicacion.Enum;
using Auditorias.Dominio.Entidades;
using Auditorias.Dominio.Servicios;
using AutoMapper;
using System.Net;

namespace Auditorias.Aplicacion.Comandos
{
    public class ComandosAuditoria: IComandosAuditoria
    {
        private readonly RegistrarAuditoria _registrarAuditoria;
        private readonly IMapper _mapper;

        public ComandosAuditoria(RegistrarAuditoria registrarAuditoria, IMapper mapper)
        {
            _registrarAuditoria = registrarAuditoria;
            _mapper = mapper;
        }

        public async Task<BaseOut> RegistrarAuditoria(AuditoriaIn auditoria)
        {
            BaseOut baseOut = new();

            try
            {
                var auditoriaDominio = _mapper.Map<Auditoria>(auditoria);
                await _registrarAuditoria.Ejecutar(auditoriaDominio);
                baseOut.Mensaje = "Auditoria registrada correctamente";
                baseOut.Id = auditoriaDominio.Id;
                baseOut.Resultado = Resultado.Exitoso;
                baseOut.Status = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                baseOut.Resultado = Resultado.Error;
                baseOut.Mensaje = ex.Message;
                baseOut.Status = HttpStatusCode.InternalServerError;
            }

            return baseOut;
        }
    }
}
