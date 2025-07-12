using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio;

namespace TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoConfiguraciones
{
    public interface IObtenerConfiguracionMailServer
    {
        Task<ObjetoMailServer> Ejecutar();
    }
}
