using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoSeguridad
{
    public class GenerarPasswordRandom : IGenerarPasswordRandom
    {
        public string Ejecutar()
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyz";
            const string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numeros = "0123456789";
            Random random = new Random();
            string resultadoCaracteres = string.Empty;

            string resultadoNumeros = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                int indice;
                if (i == 0)
                {
                    indice = random.Next(mayusculas.Length);
                    resultadoCaracteres += mayusculas[indice];

                }
                else
                {
                    indice = random.Next(caracteres.Length);
                    resultadoCaracteres += caracteres[indice];

                }
            }

            for (int j = 0; j < 7; j++)
            {
                int indice = random.Next(numeros.Length);
                resultadoNumeros += numeros[indice];
            }



            return resultadoCaracteres + resultadoNumeros;
        }
    }
}
