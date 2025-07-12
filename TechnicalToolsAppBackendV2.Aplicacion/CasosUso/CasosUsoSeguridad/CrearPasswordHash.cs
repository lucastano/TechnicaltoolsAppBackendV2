using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoSeguridad
{
    public class CrearPasswordHash : ICrearPasswordHash
    {
        public PasswordObject Ejecutar(string Password)
        {
            PasswordObject po = new PasswordObject();
            using (var hmac = new HMACSHA512())
            {

                po.passwordSalt = hmac.Key;//se usa para cifrar la contrasen
                po.passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
               
            }
            return po;
        }

    }
}
