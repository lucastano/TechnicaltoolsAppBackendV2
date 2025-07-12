using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{
    public class PasswordObject
    {
        public byte[] passwordHash {  get; set; }
        public byte[] passwordSalt { get; set; }
    }
}
