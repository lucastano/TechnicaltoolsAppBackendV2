using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio
{
    public interface ISucursalRepositorio
    {
        Task<Sucursal> Agregar(Sucursal sucursal);
        Task Eliminar(int idEmpresa, int idSucursal);
        Task<Sucursal> Modificar(Sucursal sucursal);
        Task<Sucursal> ObtenerSucursalPorId(int idEmpresa,int idSucursal);
        Task<List<Sucursal>> ObtenerSucursalesPorEmpresa(int idEmpresa);

    }
}
