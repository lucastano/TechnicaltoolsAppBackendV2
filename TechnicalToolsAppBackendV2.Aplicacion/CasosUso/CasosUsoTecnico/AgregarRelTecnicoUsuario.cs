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
    public class AgregarRelTecnicoUsuario : IAgregarRelTecnicoUsuario
    {
        private readonly IRelTecnicoUsuarioRepositorio repo;
        public AgregarRelTecnicoUsuario(IRelTecnicoUsuarioRepositorio repo)
        {
            this.repo = repo;
        }

        public async void Ejecutar(RelTecnicoUsuario relTecnicoUsuario)
        {
            await repo.Agregar(relTecnicoUsuario);
        }
    }
}
