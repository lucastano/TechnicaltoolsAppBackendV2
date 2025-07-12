using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoTecnico;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoTecnico
{
    public class ObtenerTodosLosTecnicos : IObtenerTodosLosTecnicos
    {
        private readonly ITecnicoRepositorio repo;
        public ObtenerTodosLosTecnicos(ITecnicoRepositorio repo)
        {
            this.repo = repo;
        }
        public async Task<List<Tecnico>> Ejecutar()
        {
            return await repo.ObtenerTodos();
        }
    }
}
