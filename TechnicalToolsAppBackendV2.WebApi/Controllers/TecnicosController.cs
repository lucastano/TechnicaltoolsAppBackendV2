using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoEmpresa;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoTecnico;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;
using TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsTecnico;

namespace TechnicalToolsAppBackendV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly IAgregarTecnico agregarTecnicoUc;
        private readonly IObtenerTecnicoPorId obtenerTecnicoPorIdUc;
        private readonly IObtenerTodosLosTecnicos obtenerTodosLosTecnicosUc;
        private readonly IObtenerEmpresaPorId ObtenerEmpresaPorIdUc;
        public TecnicosController(IAgregarTecnico agregarTecnicoUc, IObtenerTecnicoPorId obtenerTecnicoPorIdUc, IObtenerTodosLosTecnicos obtenerTodosLosTecnicosUc, IObtenerEmpresaPorId ObtenerEmpresaPorIdUc)
        {
            this.agregarTecnicoUc = agregarTecnicoUc;
            this.obtenerTecnicoPorIdUc = obtenerTecnicoPorIdUc;
            this.obtenerTodosLosTecnicosUc = obtenerTodosLosTecnicosUc;
            this.ObtenerEmpresaPorIdUc = ObtenerEmpresaPorIdUc;
        }

        [HttpPost("CrearTecnico")]
        public async Task<ActionResult> Agregar(AgregarTecnicoDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Falta algun dato del tecnico");
                // falta buscar la empresa y agregarla
                Empresa emp = await ObtenerEmpresaPorIdUc.Ejecutar(dto.EmpresaId);
                if (emp == null) throw new Exception("No existe empresa");
                Tecnico tecnicoPost = new Tecnico
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Empresa = emp
                };
                Tecnico tecnicoAgregado = await agregarTecnicoUc.Ejecutar(tecnicoPost,dto.Email);
                // aca deberia crear el usuario con el email 
                TecnicoDTO tec = new TecnicoDTO
                {
                    IdTecnico = tecnicoAgregado.IdTecnico,
                    Nombre = tecnicoPost.Nombre,
                    Apellido = tecnicoPost.Apellido
                };
                ResponseAgregarTecnico response = new ResponseAgregarTecnico
                {
                    Status = "success",
                    tecnico = tec

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                ResponseAgregarTecnicoError response = new ResponseAgregarTecnicoError
                {
                    descripcion = ex.Message
                };
                return BadRequest(response);
            }

        }
    }
}
