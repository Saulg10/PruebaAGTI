using api.net.core.facturacion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.net.core.facturacion.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Factura> Factura { get; set; }

        public DbSet<FacturaProducto> FacturaProducto { get; set; }
    }
}
