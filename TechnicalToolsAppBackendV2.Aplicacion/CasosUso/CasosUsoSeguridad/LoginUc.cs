using Microsoft.Extensions.Configuration;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoTecnico;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoUsuario;
using TechnicalToolsAppBackendV2.LogicaNegocio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;


namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoSeguridad
{
    public class LoginUc : ILoginUc
    {
        private readonly IObtenerUsuario obtenerUsuario;
        private readonly IVerificarPasswordHash verificarPasswordHash;
        private readonly IObtenerTecnicoPorUsuario tecnicoPorUsuario;
        private readonly ICrearToken crearToken;
        public LoginUc(IObtenerUsuario obtenerUsuario,IVerificarPasswordHash verificarPasswordHash,IObtenerTecnicoPorUsuario obtenerTecnicoPorUsuario,ICrearToken crearToken)
        {
            this.obtenerUsuario = obtenerUsuario;
            this.verificarPasswordHash = verificarPasswordHash;
            this.tecnicoPorUsuario = obtenerTecnicoPorUsuario;
            this.crearToken = crearToken;
        }

        public async Task<ObjetoSeguridad> Ejecutar(ObjetoLogin usuario, IConfiguration configuration)
        { 
            Usuario usu = await obtenerUsuario.Ejecutar(usuario.Email, usuario.Rol);
            if (usu == null) throw new Exception("No existe usuario");
            if (!verificarPasswordHash.Ejecutar(usuario.Password, usu.PasswordHash, usu.PasswordSalt)) throw new Exception("Password incorrecto");
            string token = crearToken.Ejecutar(usu, configuration);
            RelTecnicoUsuario relTecUsu = await tecnicoPorUsuario.Ejecutar(usu);
            ObjetoSeguridad objetoSeguridad = new ObjetoSeguridad();
            objetoSeguridad.usuario = usu;
            objetoSeguridad.tecnico = relTecUsu.Tecnico;
            objetoSeguridad.Token = token;
            return objetoSeguridad;
        }
    }
}
