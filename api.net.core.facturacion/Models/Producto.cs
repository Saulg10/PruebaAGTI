using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.net.core.facturacion.Models
{
    public class Producto
    {

        [Key]

        public int ProductoId { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int CantidadDisponible { get; set; }
    }

}
