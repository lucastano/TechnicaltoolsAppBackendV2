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
    public class ObtenerTodasLasEmpresas : IObtenerTodasLasEmpresas
    {
        private readonly IEmpresaRepositorio repo;
        public ObtenerTodasLasEmpresas(IEmpresaRepositorio repo)
        {
            this.repo = repo;
        }
        public async Task<List<Empresa>> Ejecutar()
        {
            return await repo.ObtenerTodas();
        }
    }
}
