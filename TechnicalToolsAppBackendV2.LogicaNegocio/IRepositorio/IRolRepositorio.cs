using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios
{
    public interface IRolRepositorio
    {
        Task<Rol> Agregar(Rol rol);
        Task<Rol?> Obtener(string rolCodigo);
        Task Eliminar(string rolCodigo);
        Task<Rol?> Modificar(Rol rol);
        Task<List<Rol>> ObtenerTodos();
    }
}
