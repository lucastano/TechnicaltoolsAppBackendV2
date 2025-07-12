using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoEmpresa
{
    public interface IAgregarEmpresa
    {
        Task<Empresa> Ejecutar(Empresa emp);
    }
}
