using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{
    public class Permiso
    {
        [Key]
        public int IdPermiso { get; set; }
        public string PermisoCodigo { get; set; }
        public string PermisoDescripcion { get; set; }

    }
}
