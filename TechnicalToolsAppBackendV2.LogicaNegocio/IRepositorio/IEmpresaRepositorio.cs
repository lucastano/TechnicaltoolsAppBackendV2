using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio
{
    public interface IEmpresaRepositorio
    {
        Task<Empresa> Agregar(Empresa empresa);
        Task<Empresa> ObtenerPorId(int id);
        Task Eliminar(int id);
        Task<Empresa> Modificar(Empresa empresa);
        Task<List<Empresa>> ObtenerTodas();
    }
}
