using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoEmpresa;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoRegistroEmpresa;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;
using TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsRegistroInicial;

namespace TechnicalToolsAppBackendV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IRegistroInicialEmpresa agregarEmpresaUc;
        private readonly IWebHostEnvironment _env;
        public EmpresasController(IRegistroInicialEmpresa agregarEmpresaUc, IWebHostEnvironment _env)
        {
            this.agregarEmpresaUc = agregarEmpresaUc;
            this._env = _env;

        }

        [HttpPost("RegistrarEmpresa")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Agregar([FromForm] RegistroInicialDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }
            try
            {
                var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsPath);
                var fileName = $"{Guid.NewGuid()}_{dto.Foto.FileName}";
                var filePath = Path.Combine(uploadsPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Foto.CopyToAsync(stream);
                }
                Tecnico admin = new Tecnico()
                {
                    Nombre = dto.NombreAdministrador,
                    Apellido = dto.ApellidoAdministrador
                };
                Empresa empresa = new Empresa
                {
                    NombreFantasia = dto.NombreFantasia,
                    RazonSocial = dto.RazonSocial,
                    NumeroRUT = dto.NumeroRUT,
                    Foto = $"/uploads/{fileName}",
                    PoliticasEmpresa = dto.PoliticasEmpresa,
                    Email = dto.Email
                };
                Empresa emp = await agregarEmpresaUc.Ejecutar(empresa, admin, dto.Email, dto.Password);
                if (emp == null) throw new Exception("No se pudo registrar la empresa. Verifique los datos ingresados.");
                return Ok(emp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
