using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;


namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios
{
    public interface IClienteRepositorio
    {
       
        Task<Cliente> ObtenerPorCi(string ci);
        Task<Cliente> ObtenerPorId(int id);
        Task<Cliente> Agregar(Cliente cliente);
        Task Eliminar (int id);
        Task<List<Cliente>> ObtenerTodos();
        Task<Cliente> Modificar(Cliente cliente);


    }
}
