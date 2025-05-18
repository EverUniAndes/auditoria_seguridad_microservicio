using Auditorias.Aplicacion.Dto;
using System.Text.Json;

namespace Auditorias.Aplicacion.ClientesApi
{
    public interface IUsuariosApiClient
    {
        Task<string> consultarUsuario(Guid idUsuario);
    }

    public class UsuariosApiClient : IUsuariosApiClient
    {
        private readonly HttpClient _httpClient;
        public UsuariosApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> consultarUsuario(Guid idUsuario)
        {
            var response = await _httpClient.GetAsync($"/api/Usuarios/{idUsuario}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var usuarioResponse = JsonSerializer.Deserialize<UsuarioResponseDto>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return usuarioResponse.UserName;
            }
            else
            {
                throw new Exception("Error al consultar el usuario");
            }
        }
    }
}
