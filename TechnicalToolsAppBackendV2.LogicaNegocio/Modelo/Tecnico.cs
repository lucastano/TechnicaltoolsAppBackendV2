
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo
{
    [Table("tecnicos")]
    public class Tecnico
    {
        [Key]
        public int IdTecnico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Empresa Empresa { get; set; }


    }
}
