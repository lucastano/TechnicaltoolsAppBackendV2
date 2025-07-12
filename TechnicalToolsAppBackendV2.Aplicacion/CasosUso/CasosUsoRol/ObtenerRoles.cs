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
    public class ObtenerRoles : IObtenerRoles
    {
        private readonly IRolRepositorio repo;
        public ObtenerRoles(IRolRepositorio repo)
        {
            this.repo = repo;
        }
        public async Task<List<Rol>> Ejecutar()
        {
           return await repo.ObtenerTodos();
        }
    }
}
