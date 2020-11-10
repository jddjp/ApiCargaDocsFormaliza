using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCargaDocsFormaliza.Data;
using ApiCargaDocsFormaliza.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCargaDocsFormaliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredencialesClientesController : ControllerBase
    {
        private readonly CredencialesClienteDb _clienteDb;
        private CredencialesCliente CredencialesCliente;

        public CredencialesClientesController(CredencialesClienteDb clienteDb)
        {
            _clienteDb = clienteDb;
        }

        // GET: api/CredencialesClientes

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteDb.Get());
        }


        // GET: api/CredencialesClientes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CredencialesClientes
        [HttpPost]
        public ActionResult<CredencialesCliente> create(CredencialesCliente credencialesCliente)
        {
            _clienteDb.Create(credencialesCliente);
          //  cliente.Create(credencialesCliente);
            return Ok("");
        }

        // PUT: api/CredencialesClientes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
