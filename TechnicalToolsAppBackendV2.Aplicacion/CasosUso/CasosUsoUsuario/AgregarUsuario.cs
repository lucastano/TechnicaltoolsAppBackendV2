using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoConfiguraciones;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoUsuario;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoUsuario
{
    public class AgregarUsuario : IAgregarUsuario
    {
        private readonly IUsuarioRepositorio repo;
        private readonly IGenerarPasswordRandom generarPasswordRandom;
        private readonly ICrearPasswordHash crearPasswordHash;
        private readonly IConfiguracionSenderEmail configEmail;
        public AgregarUsuario(IUsuarioRepositorio repo, ICrearPasswordHash crearPasswordHash,IGenerarPasswordRandom generarPasswordRandom,IConfiguracionSenderEmail configEmail)
        {
            this.repo = repo;
            this.crearPasswordHash = crearPasswordHash;
            this.generarPasswordRandom = generarPasswordRandom;
            this.configEmail = configEmail;
        }

        public  Task<Usuario> Ejecutar(Usuario usuario,out string passwordCreado)
        {
            string password = generarPasswordRandom.Ejecutar();
            PasswordObject passwordObject = crearPasswordHash.Ejecutar(password);
            usuario.PasswordSalt = passwordObject.passwordSalt;
            usuario.PasswordHash = passwordObject.passwordHash;
            passwordCreado = password;
            Task<Usuario> userAgregado = repo.Agregar(usuario);
            // este caso de uso configura como sender el email, en realidad aca no va a menos de que sea el usuario administrador
            // que se crea cuando creamos la empresa, osea el usuario principal, aun no se si voy a usar este caso de uso para crearlo
            // o voy a crear uno exclusivo para el usuario principal
            //configEmail.Ejecutar(usuario.Email);
            return userAgregado;
        }
    }
}
