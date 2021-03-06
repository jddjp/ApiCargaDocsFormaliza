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
        public IActionResult GetById(int id)
        {
            var cliente = _clienteDb.GetByIdsubExpedienteClave(id);

           return Ok(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(TipoSubExpediente subexpediente)
        {
              _clienteDb.CreateSubExpediente(subexpediente);
            return Ok(subexpediente);
        }

        [HttpPut]
        public IActionResult Update(TipoSubExpediente cli)
        {
            var cliente = _clienteDb.GetByIdsubExpedienteClave(cli.Clave);

            if (cliente == null)
            {
                return NotFound();
            }

           _clienteDb.UpdateSubexpediente(cli);

            return Ok("Se Actualizo el registro");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var cliente = _clienteDb.GetByIdsubExpedienteClave(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.DeleteByIdSubExpediente(cliente.Id);

            return Ok("Se elimino el registro");
        }

    }
}