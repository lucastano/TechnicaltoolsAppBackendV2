using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{

    public class Empresa
    {
        public int Id { get; set; }
        public string NombreFantasia { get; set; }
        public string RazonSocial { get; set; }
        public string NumeroRUT { get; set; }
        public string? Foto { get; set; }
        public string? PoliticasEmpresa { get; set; }
        [JsonIgnore]
        public List<Sucursal> Sucursales { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; } // habilitado, deshabilitado
        public DateTime FechaRegistro { get; set; }

        public Empresa()
        {
            Estado = "habilitado"; // Estado por defecto
            FechaRegistro = DateTime.Now;
            Sucursales = new List<Sucursal>();
            Sucursal sucursalInicial = new Sucursal
            {
                //CodigoSucursal = "001",
                Direccion = "Sucursal Principal",
                Telefono = "0000000000",
                Empresa = this
            };
            Sucursales.Add(sucursalInicial);
        }


    }
}
