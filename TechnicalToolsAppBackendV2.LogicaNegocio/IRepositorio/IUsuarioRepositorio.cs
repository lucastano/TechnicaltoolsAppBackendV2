using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> Agregar(Usuario usuario);
        Task<Usuario?> Obtener(string email,string rolCod);
        Task Eliminar(Usuario usuario);
        Task<Usuario> Modificar(Usuario usuario);
        Task<Usuario> CambiarPassword (Usuario usuario);
    }
}
