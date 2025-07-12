using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoEmpresa;

namespace TechnicalToolsAppBackendV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IAgregarEmpresa agregarEmpresaUc;
        public EmpresasController(IAgregarEmpresa agregarEmpresaUc)
        {
            this.agregarEmpresaUc = agregarEmpresaUc;

        }
    }
}
