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
    public class ObtenerTecnicoPorId : IObtenerTecnicoPorId
    {
        private readonly ITecnicoRepositorio repo;
        public ObtenerTecnicoPorId(ITecnicoRepositorio repo)
        {
            this.repo = repo;
        }
        public async Task<Tecnico> Ejecutar(int id)
        {
            return await repo.ObtenerPorId(id);
        }
    }
}
