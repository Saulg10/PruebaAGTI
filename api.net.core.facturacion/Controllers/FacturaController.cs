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
    public class FacturaController : ControllerBase
    {
        private readonly AppDbContext context;

        public FacturaController(AppDbContext context)
        {
            this.context = context;
        }



        // GET: api/<FacturaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Factura.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


      


        // GET api/<FacturaController>/5
        [HttpGet("{id}", Name = "GetFactura")]
        public ActionResult Get(int id)
        {
            try
            {
                var fac = context.Factura.FirstOrDefault(f => f.FacturaId == id);
                return Ok(fac);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<FacturaController>
        public ActionResult Post([FromBody] Factura factura)
        {

            try
            {
                context.Factura.Add(factura);
                context.SaveChanges();
                return CreatedAtRoute("GetFactura", new { id = factura.FacturaId }, factura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Factura factura)
        {
            try
            {
                if (factura.FacturaId == id)
                {
                    context.Entry(factura).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetFactura", new { id = factura.FacturaId }, factura);
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

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var factura = context.Factura.FirstOrDefault(f => f.FacturaId == id);
                if (factura != null)
                {
                    context.Factura.Remove(factura);
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
