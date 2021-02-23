using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCargaDocsFormaliza.Data;
using ApiCargaDocsFormaliza.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCargaDocsFormaliza.Controllers
{
    //[Route("api/Filtros")]
   // [ApiController]
    public class FiltrosExpedientesController : ControllerBase
    {
        private readonly ClientesDb _clienteDb;
        private Cliente cliente;

        public FiltrosExpedientesController(ClientesDb clienteDb)
        {
            _clienteDb = clienteDb;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // GET: api/<FiltrosExpedientesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteDb.Get());
        }

     
        [HttpGet]
        [Route("api/Filtros")]
        public IActionResult GetById(string ClaveExpediente, int ClaveSubTipoOriginacion)
        {
            var cliente = _clienteDb.GetByClave_ExpedienteAndTipoSubExpediente(ClaveExpediente, ClaveSubTipoOriginacion);

          

            if (cliente.Count == 0)
            {
                return NotFound();
            }



            return Ok(cliente);

        }
        [ApiExplorerSettings(IgnoreApi = true)]
        // POST api/<FiltrosExpedientesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        // PUT api/<FiltrosExpedientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        // DELETE api/<FiltrosExpedientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
