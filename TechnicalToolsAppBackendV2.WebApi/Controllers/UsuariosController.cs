using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoUsuario;
using TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsUsuario;

namespace TechnicalToolsAppBackendV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IAgregarUsuario agregarUsuarioUc;
        public UsuariosController(IAgregarUsuario agregarUsuarioUc)
        {
            this.agregarUsuarioUc = agregarUsuarioUc;
        }
 
    }
}
