using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.net.core.facturacion.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        public int ClienteId { get; set; }

        public int EmpleadoId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal ValorTotal { get; set; }

    
    }

        


}
