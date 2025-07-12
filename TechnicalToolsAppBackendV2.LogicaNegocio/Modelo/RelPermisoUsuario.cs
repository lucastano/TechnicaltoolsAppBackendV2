using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{
    public class RelPermisoUsuario
    {
        [Key]
        public int IdRelPermisoUsuario { get; set; }
        public Permiso Permiso { get; set; }
        public Usuario Usuario { get; set; }
    }
}
