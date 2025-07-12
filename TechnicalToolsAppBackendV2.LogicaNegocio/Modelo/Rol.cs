using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string RolCodigo { get; set; }
        public string RolDescripcion { get; set; }

        public Rol (string rolCodigo, string rolDescripcion)
        {
            RolCodigo = rolCodigo;
            RolDescripcion = rolDescripcion;
        }
    }
}
