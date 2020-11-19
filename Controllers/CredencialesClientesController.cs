using System;
using System.Collections.Generic;
using System.IO;
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
    public class CredencialesController : ControllerBase
    {

        private readonly ClientesDb _clienteDb;
        private Cliente cliente;

        public CredencialesController(ClientesDb clienteDb)
        {
            _clienteDb = clienteDb;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteDb.Get2());
        
        }

        [HttpGet("{id}", Name = "GetCredenciales")]
        public IActionResult GetById(string id)
        {
            var cliente = _clienteDb.GetByidclavecredenciales(id);

           return Ok(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(Cliente2 cliente2)
        {
            _clienteDb.Create2(cliente2);
            return Ok(cliente2);
        }

        [HttpPut]
        public IActionResult Update(Cliente2 cli)
        {
            var cliente = _clienteDb.GetById2(cli.Id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.Update2(cli);

            return Ok(cli);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            var cliente = _clienteDb.GetById2(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.DeleteById2(cliente.Id);

            return Ok("Registro Eliminado");
        }

    }
}