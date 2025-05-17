using Auditorias.Aplicacion.Comandos;
using Auditorias.Aplicacion.Consultas;
using Auditorias.Aplicacion.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ServicioAuditoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AuditoriaController : ControllerBase
    {
        private readonly IComandosAuditoria _comandosAuditoria;
        private readonly IConsultasAuditoria _consultasAuditoria;
        public AuditoriaController(IComandosAuditoria comandosAuditoria, IConsultasAuditoria consultasAuditoria)
        {
            _comandosAuditoria = comandosAuditoria;
            _consultasAuditoria = consultasAuditoria;
        }

        [HttpPost]
        [Route("RegistrarAuditoria")]
        [ProducesResponseType(typeof(AuditoriaOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> RegistrarAuditoria([FromBody] AuditoriaIn auditoriaIn)
        {
            try
            {
                if (auditoriaIn == null)
                {
                    return BadRequest("El objeto auditoria no puede ser nulo.");
                }

                var resultado = await _comandosAuditoria.RegistrarAuditoria(auditoriaIn);
                
                if (resultado.Resultado == Auditorias.Aplicacion.Enum.Resultado.Exitoso)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerAuditoriasPorFecha")]
        [ProducesResponseType(typeof(AuditoriaOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerAuditoriasPorFecha([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            try
            {
                if (fechaInicio == default || fechaFin == default)
                {
                    return BadRequest("Las fechas de inicio y fin son requeridas.");
                }
                var resultado = await _consultasAuditoria.ObtenerAuditoriasPorFecha(fechaInicio, fechaFin);

                if (resultado.Resultado == Auditorias.Aplicacion.Enum.Resultado.Exitoso)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerAuditoriasPorUsuario")]
        [ProducesResponseType(typeof(AuditoriaOutList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ObtenerAuditoriasPorUsuario(Guid id)
        {
            try
            {
                var resultado = await _consultasAuditoria.ObtenerAuditoriasPorUsuario(id);
                if (resultado.Resultado == Auditorias.Aplicacion.Enum.Resultado.Exitoso)
                    return Ok(resultado);
                else
                    return Problem(resultado.Mensaje, statusCode: (int)resultado.Status, title: resultado.Resultado.ToString(), type: resultado.Resultado.ToString(), instance: HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

