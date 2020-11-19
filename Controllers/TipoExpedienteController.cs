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
    public class TipoExpedienteController : ControllerBase
    {

        private readonly ClientesDb _clienteDb;
        private Cliente cliente;

        public TipoExpedienteController(ClientesDb clienteDb)
        {
            _clienteDb = clienteDb;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteDb.GetExpedientes());
        
        }

        [HttpGet("{id}", Name = "GetExpedientes")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteDb.GetByIdExpedienteClave(id);

           return Ok(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(TipoExpediente tipoexpediente)
        {

            _clienteDb.CreateExpediente(tipoexpediente);
            return Ok(tipoexpediente);
        }

        [HttpPut()]
        public IActionResult Update(TipoExpediente cli)
        {
            var cliente = _clienteDb.GetByIdExpediente(cli.Clave);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.UpdateExpediente(cli);

            return Ok("Registro Actualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var cliente = _clienteDb.GetByIdExpediente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.DeleteByIdExpediente(cliente.Id);

            return Ok("Registro Eliminado");
        }

    }
}