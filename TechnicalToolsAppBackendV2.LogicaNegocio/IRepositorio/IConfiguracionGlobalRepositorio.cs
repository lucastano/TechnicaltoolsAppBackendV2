using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio
{
    public interface IConfiguracionGlobalRepositorio
    {
        Task<ConfiguracionGlobal> Get();
        Task<ObjetoMailServer> GetMailServer();
    }
}
