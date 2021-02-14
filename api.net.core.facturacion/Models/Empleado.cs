using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.net.core.facturacion.Models
{
    public class Empleado
    {

        [Key]
        public int EmpleadoId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public Boolean EsAdministrador { get; set; }


    }
}
