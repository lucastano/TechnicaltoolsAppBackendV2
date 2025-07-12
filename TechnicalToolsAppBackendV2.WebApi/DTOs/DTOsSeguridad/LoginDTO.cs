using System.ComponentModel.DataAnnotations;

namespace TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsSeguridad
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Rol {  get; set; }
    }
}
