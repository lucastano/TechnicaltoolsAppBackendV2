using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad;
using TechnicalToolsAppBackendV2.LogicaNegocio;
using TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsSeguridad;
using TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsTecnico;

namespace TechnicalToolsAppBackendV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginUc LoginUc;

        public SeguridadController(IConfiguration configuration,ILoginUc login)
        {
            _configuration = configuration;
            this.LoginUc = login;
        }

        [HttpPost("Login")]
       public async Task<ActionResult> Login(LoginDTO dto)
       {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Debe completar todos los datos");
                ObjetoLogin loginObject = new ObjetoLogin();
                loginObject.Email = dto.Email;
                loginObject.Password = dto.Password;
                loginObject.Rol = dto.Rol;
                ObjetoSeguridad objetoSeguridad = await LoginUc.Ejecutar(loginObject, _configuration);
                TecnicoDTO dtoTecnico = new TecnicoDTO()
                {
                    IdTecnico = objetoSeguridad.tecnico.IdTecnico,
                    Nombre = objetoSeguridad.tecnico.Nombre,
                    Apellido = objetoSeguridad.tecnico.Apellido,
                    Email = objetoSeguridad.usuario.Email
                };
                ResponseLoginDTO responseLoginDTO = new ResponseLoginDTO()
                {
                    Status = "Success",
                    Tecnico = dtoTecnico,
                    Token = objetoSeguridad.Token
                };
                return Ok(responseLoginDTO);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

       }
    }
}
