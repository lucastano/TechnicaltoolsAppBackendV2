using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.LogicaNegocio
{
    public class ObjetoSeguridad
    {
        public Tecnico tecnico {  get; set; }
        public Usuario usuario { get; set; }
        public string Token { get; set; }
    }
}
