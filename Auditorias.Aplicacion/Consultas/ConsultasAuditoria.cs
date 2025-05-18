using Auditorias.Aplicacion.ClientesApi;
using Auditorias.Aplicacion.Dto;
using Auditorias.Aplicacion.Enum;
using Auditorias.Dominio.Entidades;
using Auditorias.Dominio.Servicios;
using AutoMapper;
using System.Net;

namespace Auditorias.Aplicacion.Consultas
{
    public class ConsultasAuditoria : IConsultasAuditoria
    {
        private readonly AuditoriasPorFecha _auditoriasPorFecha;
        private readonly AuditoriasPorUsuario _auditoriasPorUsuario;
        private readonly IMapper _mapper;
        private readonly IUsuariosApiClient _usuariosApiClient;

        public ConsultasAuditoria(AuditoriasPorFecha auditoriasPorFecha, AuditoriasPorUsuario auditoriasPorUsuario, IMapper mapper, IUsuariosApiClient usuariosApiClient)
        {
            _auditoriasPorFecha = auditoriasPorFecha;
            _auditoriasPorUsuario = auditoriasPorUsuario;
            _mapper = mapper;
            _usuariosApiClient = usuariosApiClient;
        }

        public void ConsultarUsuario(Auditoria auditoriaDto)
        {
            var usuario = _usuariosApiClient.consultarUsuario(auditoriaDto.IdUsuario);
            if (usuario != null)
            {
                auditoriaDto.UserName = usuario.Result;
            }
        }

        public async Task<AuditoriaOutList> ObtenerAuditoriasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            AuditoriaOutList output = new()
            {
                Auditorias = []
            };

            try
            {
                var Auditorias = await _auditoriasPorFecha.ObtenerAuditoriasPorFecha(fechaInicio, fechaFin);

                if (Auditorias == null || !Auditorias.Any())
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron auditorías en el rango de fechas especificado.";
                    output.Status = HttpStatusCode.NotFound;
                    return output;
                }
                else
                {
                    foreach (var auditoria in Auditorias)
                    { 
                        ConsultarUsuario(auditoria);
                    }

                    output.Auditorias = _mapper.Map<List<AuditoriaDto>>(Auditorias);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Auditorías obtenidas correctamente.";
                    output.Status = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }

        public async Task<AuditoriaOutList> ObtenerAuditoriasPorUsuario(Guid idUsuario)
        {
            AuditoriaOutList output = new()
            {
                Auditorias = []
            };

            try
            {
                var Auditorias = await _auditoriasPorUsuario.ObtenerAuditoriasPorUsuario(idUsuario);

                if (Auditorias == null || !Auditorias.Any())
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron auditorías en el rango de fechas especificado.";
                    output.Status = HttpStatusCode.NotFound;
                    return output;
                }
                else
                {
                    foreach (var auditoria in Auditorias)
                    {
                        ConsultarUsuario(auditoria);
                    }

                    output.Auditorias = _mapper.Map<List<AuditoriaDto>>(Auditorias);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Auditorías obtenidas correctamente.";
                    output.Status = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }
}
