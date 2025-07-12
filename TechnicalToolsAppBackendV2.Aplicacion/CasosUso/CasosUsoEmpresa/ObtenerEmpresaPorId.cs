using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoEmpresa;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoEmpresa
{
    public class ObtenerEmpresaPorId : IObtenerEmpresaPorId
    {
        private readonly IEmpresaRepositorio repo;
        public ObtenerEmpresaPorId(IEmpresaRepositorio repo)
        {
            this.repo = repo;
        }
        public async Task<Empresa> Ejecutar(int id)
        {
            return await repo.ObtenerPorId(id);
        }
    }
}
