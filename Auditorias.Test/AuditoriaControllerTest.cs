using Microsoft.AspNetCore.Mvc.Testing;
using Auditorias.Aplicacion.Dto;
using System.Net;
using System.Net.Http.Json;

namespace Auditorias.Test
{
    public class AuditoriaControllerTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Guid clienteId = Guid.Parse("4cd124ef-6394-4562-a80f-952973684f82");
        private bool isTest = false;
        public AuditoriaControllerTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task registrarAuditoria_Ok()
        {
            var auditoria = new AuditoriaIn
            {
                IdUsuario = clienteId,
                Accion = "Crear",
                TablaAfectada = "Usuario",
                Idregistro = "04c88cba-4f7a-47ec-8a09-0578e1dc85f4",
                Registro = "Se creó un nuevo usuario"
            };
            var response = await _client.PostAsJsonAsync("/api/Auditoria/RegistrarAuditoria", auditoria);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            isTest = true;
        }

        [Fact]
        public async Task registrarAuditoria_Error()
        {
            var auditoria = new AuditoriaIn
            {
                IdUsuario = Guid.NewGuid(),
                Accion = "Crear",
                TablaAfectada = "Usuario",
                Idregistro = "04c88cba-4f7a-47ec-8a09-0578e1dc85f4",
                Registro = "Se creó un nuevo usuario"
            };
            var response = await _client.PostAsJsonAsync("/api/Auditoria/RegistrarAuditoria", auditoria);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async Task consultarAuditoriasFecha_Ok()
        {
            var fechaInicio = "2025-05-15T16:00:00.420Z";
            var fechaFin = "2025-05-16T16:00:00.420Z";
            var response = await _client.GetAsync($"/api/Auditoria/ObtenerAuditoriasPorFecha?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task consultarAuditoriasFecha_Error()
        {
            var fechaInicio = "2025-05-18T16:00:00.420Z";
            var fechaFin = "2025-05-15T16:00:00.420Z";
            var response = await _client.GetAsync($"/api/Auditoria/ObtenerAuditoriasPorFecha?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async Task consultaAuditoriasPorUsuario()
        {
            if (!isTest)
                await registrarAuditoria_Ok();

            var response = await _client.GetAsync($"/api/Auditoria/ObtenerAuditoriasPorUsuario?id={clienteId}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}