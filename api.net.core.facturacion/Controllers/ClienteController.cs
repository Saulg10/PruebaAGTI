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
    public class ClienteController : ControllerBase
    {

        private readonly AppDbContext context;

        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Cliente.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name ="GetCliente")]
        public ActionResult Get(int id)
        {
            try
            {
                var cl = context.Cliente.FirstOrDefault(c => c.ClienteId == id);
                return Ok(cl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody]Cliente cliente)
        {

            try
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return CreatedAtRoute("GetCliente", new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == id)
                {
                    context.Entry(cliente).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCliente", new { id = cliente.ClienteId }, cliente);
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

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var cliente = context.Cliente.FirstOrDefault(c => c.ClienteId == id);
                if(cliente != null)
                {
                    context.Cliente.Remove(cliente);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
