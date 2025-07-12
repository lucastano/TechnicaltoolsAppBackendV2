using System.Security.Cryptography;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoSeguridad
{
    public class VerificarPasswordHash : IVerificarPasswordHash
    {
        public bool Ejecutar(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var passwordHashCalculado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return passwordHashCalculado.SequenceEqual(passwordHash);
            }
        
        }
    }
}
