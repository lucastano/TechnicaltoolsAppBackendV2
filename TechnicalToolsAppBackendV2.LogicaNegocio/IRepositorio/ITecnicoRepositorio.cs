using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios
{
    public interface ITecnicoRepositorio 
    {
        Task<Tecnico> Modificar(Tecnico tecnico);
        Task<Tecnico> Agregar(Tecnico tecnico);
        Task Eliminar(int id);
        Task<Tecnico> ObtenerPorId(int id);
        Task<List<Tecnico>> ObtenerTodos();
        
       
    }
}
