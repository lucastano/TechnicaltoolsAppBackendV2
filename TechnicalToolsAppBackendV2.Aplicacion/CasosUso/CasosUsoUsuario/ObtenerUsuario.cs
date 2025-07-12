using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoUsuario;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoUsuario
{
    public class ObtenerUsuario : IObtenerUsuario
    {
        private readonly IUsuarioRepositorio repo;
        public ObtenerUsuario(IUsuarioRepositorio repo)
        {
            this.repo = repo;
        }
        public Task<Usuario> Ejecutar(string email, string rolCod)
        {
            return repo.Obtener(email, rolCod);
        }
    }
}
