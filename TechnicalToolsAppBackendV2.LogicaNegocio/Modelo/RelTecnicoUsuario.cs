using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{
    public class RelTecnicoUsuario
    {
        [Key]
        public int IdRelTecnicoUsuario {  get; set; }
        public  Usuario Usuario { get; set; }
        public Tecnico Tecnico { get; set; }
    }
}
