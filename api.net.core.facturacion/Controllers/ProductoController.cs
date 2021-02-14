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


    public class ProductoController : ControllerBase
    {

        private readonly AppDbContext context;
        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Producto.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}", Name = "GetProducto")]
        public ActionResult Get(int id)
        {
            try
            {
                var pr = context.Producto.FirstOrDefault(pr => pr.ProductoId == id);
                return Ok(pr);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {

            try
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return CreatedAtRoute("GetProducto", new { id = producto.ProductoId }, producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if (producto.ProductoId == id)
                {
                    context.Entry(producto).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProducto", new { id = producto.ProductoId }, producto);
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
        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var producto = context.Producto.FirstOrDefault(p => p.ProductoId == id);
                if (producto != null)
                {
                    context.Producto.Remove(producto);
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
