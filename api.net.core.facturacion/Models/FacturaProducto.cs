using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.net.core.facturacion.Models
{
    public class FacturaProducto
    {

        [Key]

        public int FacturaProductoId { get; set; }

        public int FacturaId { get; set; }

        public int ProductoId { get; set; }

        public int CantidadProducto { get; set; }

        public int Subtotal {get; set;}
    }
}
