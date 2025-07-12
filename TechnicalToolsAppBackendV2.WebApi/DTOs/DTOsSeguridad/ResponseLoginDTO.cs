using TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsTecnico;

namespace TechnicalToolsAppBackendV2.WebApi.DTOs.DTOsSeguridad
{
    public class ResponseLoginDTO
    {
        public string Status {  get; set; }
        public TecnicoDTO Tecnico { get; set; }
        public string Token { get; set; }
    }
}
