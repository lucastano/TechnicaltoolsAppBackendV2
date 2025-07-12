using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoConfiguraciones;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoConfiguraciones
{
    public class ObtenerConfiguracionGlobal : IObtenerConfiguracionGlobal
    {
        private readonly IConfiguracionGlobalRepositorio repo;
        public ObtenerConfiguracionGlobal(IConfiguracionGlobalRepositorio repo)
        {
            this.repo = repo;
        }

        public Task<ConfiguracionGlobal> Ejecutar()
        {
            return repo.Get();
        }
    }
}
