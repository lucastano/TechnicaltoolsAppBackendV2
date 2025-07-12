using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsUsuario
{
    public class AgregarUsuarioDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public int EmpresaId { get; set; }
    }
}
