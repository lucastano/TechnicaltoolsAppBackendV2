using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoAvisosEmail;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoRol;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoTecnico;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoUsuario;
using TechnicalToolsAppBackendV2.LogicaNegocio.Enumerables;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoTecnico
{
    public class AgregarTecnico : IAgregarTecnico
    {
        private readonly ITecnicoRepositorio repo;
        private readonly IAgregarUsuario agregarUsuario;
        private readonly IAgregarRelTecnicoUsuario relTecnicoUsuario;
        private readonly IObtenerRolPorCod obtenerRolPorCod;
        private readonly IEnviarEmailNuevoUsuario enviarEmailNuevoUsuario;
        public AgregarTecnico(ITecnicoRepositorio repo,IAgregarUsuario agregarUsuario, IAgregarRelTecnicoUsuario relTecnicoUsuario,IObtenerRolPorCod obtenerRolPorCod,IEnviarEmailNuevoUsuario enviarEmailNuevoUsuario)
        {
            this.repo = repo;
            this.agregarUsuario = agregarUsuario;
            this.relTecnicoUsuario = relTecnicoUsuario;
            this.obtenerRolPorCod = obtenerRolPorCod;
            this.enviarEmailNuevoUsuario = enviarEmailNuevoUsuario;
        }
        public async Task<Tecnico> Ejecutar(Tecnico tecnico, string email)
        {
            //try
            //{
                Rol rol = await obtenerRolPorCod.Ejecutar(RolesCod.RolTec.ToString());
                Usuario usuario = new Usuario
                {
                    Email = email,
                    Rol = rol,
                    Empresa = tecnico.Empresa
                };
                string passwordCreado = "";
                Usuario usuarioCreado = await agregarUsuario.Ejecutar(usuario, out passwordCreado);
                Tecnico tecnicoCreado = await repo.Agregar(tecnico);
                RelTecnicoUsuario relTecUsu = new RelTecnicoUsuario();
                relTecUsu.Tecnico = tecnicoCreado;
                relTecUsu.Usuario = usuarioCreado;
                relTecnicoUsuario.Ejecutar(relTecUsu);
                await enviarEmailNuevoUsuario.Ejecutar(usuarioCreado, tecnicoCreado, passwordCreado);
                return tecnicoCreado;
            //}
            //catch (Exception ex) 
            //{
            //    return new Exception(ex.Message.ToString);           
            //}   
        }
    }
}
