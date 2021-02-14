using api.net.core.facturacion.Context;
using api.net.core.facturacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.net.core.facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaProductoController : ControllerBase
    {


        private readonly AppDbContext context;

        public FacturaProductoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<FacturaProductoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.FacturaProducto.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<FacturaProductoController>/5
        [HttpGet("{id}", Name = "GetFacturaProducto")]
        public ActionResult Get(int id)
        {
            try
            {
                var fp = context.FacturaProducto.FirstOrDefault(fpc => fpc.FacturaProductoId == id);
                return Ok(fp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<FacturaProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] FacturaProducto facturaproducto)
        {
            try
            {
                context.FacturaProducto.Add(facturaproducto);
                context.SaveChanges();
                return CreatedAtRoute("GetFacturaProducto", new { id = facturaproducto.FacturaProductoId }, facturaproducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<FacturaProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] FacturaProducto facturaproducto)
        {
            try
            {
                if (facturaproducto.FacturaProductoId == id)
                {
                    context.Entry(facturaproducto).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetFacturaProducto", new { id = facturaproducto.FacturaProductoId }, facturaproducto);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FacturaProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var facturaproducto = context.FacturaProducto.FirstOrDefault(fpc => fpc.FacturaProductoId == id);
                if (facturaproducto != null)
                {
                    context.FacturaProducto.Remove(facturaproducto);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
