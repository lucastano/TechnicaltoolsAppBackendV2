using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string CodigoSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Empresa Empresa { get; set; }
        public bool avisosEmail { get; set; }
        public bool avisosWsp { get; set; }
        [NotMapped]
        public static int ultimoCodigoSucursal = 001;

        public Sucursal() 
        {
            this.avisosEmail = true;
            this.avisosWsp = false;
            this.CodigoSucursal = ultimoCodigoSucursal.ToString();
            ultimoCodigoSucursal++;
        }
    }
}
