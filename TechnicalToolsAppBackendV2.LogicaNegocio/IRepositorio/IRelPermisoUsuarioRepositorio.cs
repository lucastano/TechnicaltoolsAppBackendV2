
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;


namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios
{
    public interface IRelPermisoUsuarioRepositorio
    {
        Task<RelPermisoUsuario> Agregar(RelPermisoUsuario permisoUsuario);
        Task Eliminar(int id);

        Task<bool> VerificarPermisoUsuario(int usuario,string permisoCodigo);
    }
}
