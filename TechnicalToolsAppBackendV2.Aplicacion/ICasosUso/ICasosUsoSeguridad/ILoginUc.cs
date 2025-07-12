using Microsoft.Extensions.Configuration;
using TechnicalToolsAppBackendV2.LogicaNegocio;

namespace TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad
{
    public interface ILoginUc
    {
        Task<ObjetoSeguridad> Ejecutar(ObjetoLogin usuario, IConfiguration configuration);
    }
}
