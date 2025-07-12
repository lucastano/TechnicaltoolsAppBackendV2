using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoTecnico;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoTecnico
{
    public class ObtenerTecnicoPorUsuario : IObtenerTecnicoPorUsuario
    {
        private readonly IRelTecnicoUsuarioRepositorio repo;
        public ObtenerTecnicoPorUsuario(IRelTecnicoUsuarioRepositorio repo)
        {
            this.repo = repo;

        }
        public async Task<RelTecnicoUsuario> Ejecutar(Usuario usuario)
        {
            return await repo.ObtenerTecnicoPorUsuario(usuario);
        }
    }
}
