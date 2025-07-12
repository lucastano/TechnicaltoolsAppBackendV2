using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios
{
    public interface IPermisoRepositorio
    {
        Task<Permiso> Agregar(Permiso permiso);
        Task<Permiso> Modificar(Permiso permiso);
        Task<List<Permiso>> ObtenerTodos();
        Task<Permiso?> ObtenerPorCodigo(string permisoCodigo);
        Task Eliminar(string permisoCodigo);
    }
}
