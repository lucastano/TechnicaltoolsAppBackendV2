using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoConfiguraciones;
using TechnicalToolsAppBackendV2.LogicaNegocio;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoConfiguraciones
{
    public class ObtenerConfiguracionMailServer : IObtenerConfiguracionMailServer
    {
        private readonly IConfiguracionGlobalRepositorio repo;
        public ObtenerConfiguracionMailServer(IConfiguracionGlobalRepositorio repo)
        {
            this.repo = repo;
        }

        public Task<ObjetoMailServer> Ejecutar()
        {
            return repo.GetMailServer();
        }
    }
}
