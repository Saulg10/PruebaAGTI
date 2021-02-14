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
    public class EmpleadoController : ControllerBase
    {

        private readonly AppDbContext context;

        public EmpleadoController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<EmpleadoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Empleado.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}", Name ="GetEmpleado")]
        public ActionResult Get(int id)
        {
            try
            {
                var em = context.Empleado.FirstOrDefault(e => e.EmpleadoId == id);
                return Ok(em);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public ActionResult Post([FromBody] Empleado empleado)
        {

            try
            {
                context.Empleado.Add(empleado);
                context.SaveChanges();
                return CreatedAtRoute("GetEmpleado", new { id = empleado.EmpleadoId }, empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Empleado empleado)
        {
            try
            {
                if (empleado.EmpleadoId == id)
                {
                    context.Entry(empleado).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEmpleado", new { id = empleado.EmpleadoId }, empleado);
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



        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var empleado = context.Empleado.FirstOrDefault(e => e.EmpleadoId == id);
                if (empleado != null)
                {
                    context.Empleado.Remove(empleado);
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
