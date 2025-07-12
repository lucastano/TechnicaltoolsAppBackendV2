using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoConfiguraciones
{
    public interface IConfiguracionSenderEmail
    {
        void Ejecutar(string email);
    }
}
