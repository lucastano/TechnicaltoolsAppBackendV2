using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad
{
    public interface IVerificarPasswordHash
    {
        bool Ejecutar(string password, byte[] passwordHash, byte[]passwordSalt);
    }
}
