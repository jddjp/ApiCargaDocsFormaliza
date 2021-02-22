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
    public class TipoSubSubExpedienteController : ControllerBase
    {

        private readonly ClientesDb _clienteDb;
        private Cliente cliente;

        public TipoSubSubExpedienteController(ClientesDb clienteDb)
        {
            _clienteDb = clienteDb;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteDb.GetTipoSubSubExpedientes());
        
        }

        [HttpGet("{id}", Name = "GetSubSubExpedientes")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteDb.GetByIdTipoSubSubExpediente(id);

           return Ok(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(TipoSubSubExpediente subexpediente)
        {
              _clienteDb.CreateTipoSubSubExpediente(subexpediente);
            return Ok(subexpediente);
        }

        [HttpPut]
        public IActionResult Update(TipoSubSubExpediente cli)
        {
            var cliente = _clienteDb.GetByIdTipoSubSubExpediente(cli.Clave);

            if (cliente == null)
            {
                return NotFound();
            }

           _clienteDb.UpdateTipoSubSubExediente(cli);

            return Ok("Se Actualizo el registro");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var cliente = _clienteDb.GetByIdTipoSubSubExpediente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.DeleteByIDSubSubExpediente(cliente.Clave);

            return Ok("Se elimino el registro");
        }

    }
}