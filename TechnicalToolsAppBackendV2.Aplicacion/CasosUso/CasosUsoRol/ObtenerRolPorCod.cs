using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoRol;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoRol
{
    public class ObtenerRolPorCod : IObtenerRolPorCod
    {
        private readonly IRolRepositorio repo;
        public ObtenerRolPorCod(IRolRepositorio repo)
        {
            this.repo = repo;
        }

        public async Task<Rol> Ejecutar(string cod)
        {
            return await repo.Obtener(cod);
        }
    }
}
