using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoAvisosEmail
{
    public interface IEnviarEmailNuevoUsuario
    {
        Task Ejecutar(Usuario usuario, Tecnico tecnico,string password);
    }
}
