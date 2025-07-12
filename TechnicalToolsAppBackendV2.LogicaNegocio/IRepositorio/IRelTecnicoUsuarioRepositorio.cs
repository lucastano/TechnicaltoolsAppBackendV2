using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio
{
    public interface IRelTecnicoUsuarioRepositorio
    {
        Task Agregar(RelTecnicoUsuario relTecnicoUsuario);
        Task<RelTecnicoUsuario> ObtenerTecnicoPorUsuario(Usuario usuario);
        Task Eliminar(Usuario usuario);
    }
}
