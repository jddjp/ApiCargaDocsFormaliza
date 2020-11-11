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
    public class TipoSubExpedienteController : ControllerBase
    {

        private readonly ClientesDb _clienteDb;
        private Cliente cliente;

        public TipoSubExpedienteController(ClientesDb clienteDb)
        {
            _clienteDb = clienteDb;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteDb.GetSubExpedientes());
        
        }

        [HttpGet("{id}", Name = "GetSubExpedientes")]
        public IActionResult GetById(string id)
        {
            var cliente = _clienteDb.GetByIdsubExpedienteClave(id);

           return BadRequest(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(TipoSubExpediente subexpediente)
        {
              _clienteDb.CreateSubExpediente(subexpediente);
            return Ok(subexpediente);
        }

        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, Cliente2 cli)
        //{
        //    var cliente = _clienteDb.GetById2(id);

        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    _clienteDb.Update2(id, cli);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public IActionResult DeleteById(string id)
        //{
        //    var cliente = _clienteDb.GetById2(id);

        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    _clienteDb.DeleteById2(cliente.Id);

        //    return NoContent();
        //}

    }
}