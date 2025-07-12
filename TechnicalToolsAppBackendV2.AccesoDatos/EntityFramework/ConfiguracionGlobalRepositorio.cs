using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.AccesoDatos.EntityFramework
{
    public class ConfiguracionGlobalRepositorio : IConfiguracionGlobalRepositorio
    {
        TechnicalToolsContexto contexto;
        public ConfiguracionGlobalRepositorio(TechnicalToolsContexto contexto)
        {
            this.contexto = contexto;

        }
        public async Task<ConfiguracionGlobal> Get()
        {
            return await contexto.ConfiguracionGlobal.FirstOrDefaultAsync();
        }

        public async Task<ObjetoMailServer> GetMailServer()
        {
            ConfiguracionGlobal config = await contexto.ConfiguracionGlobal.FirstOrDefaultAsync();
            ObjetoMailServer newObjetMailServer = new ObjetoMailServer();
            newObjetMailServer.apiKey = config.apiKey;
            newObjetMailServer.secretKey = config.secretKey;
            return newObjetMailServer;
        }
    }
}
