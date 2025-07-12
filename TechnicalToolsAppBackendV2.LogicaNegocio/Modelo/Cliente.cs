using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo.ValueObjects;




namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Ci { get; set; }



        public  bool validarCi()
        {
            bool retorno = true;
            if (this.Ci == null)
            {
                retorno = false;
            }
            if (this.Ci.Length<8)
            {
                retorno = false;
            }
            return retorno;
        }        
    }
}
