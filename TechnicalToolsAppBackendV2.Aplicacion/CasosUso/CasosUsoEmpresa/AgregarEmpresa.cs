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
    public class AgregarEmpresa : IAgregarEmpresa
    {
        private readonly IEmpresaRepositorio empresaRepositorio;
        public AgregarEmpresa(IEmpresaRepositorio empresaRepositorio)
        {
            this.empresaRepositorio = empresaRepositorio;
        }

        public Task<Empresa> Ejecutar(Empresa emp)
        {
            return empresaRepositorio.Agregar(emp);
        }
    }
}
