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
    public class TipoDocumentoController : ControllerBase
    {

        private readonly ClientesDb _clienteDb;
        private Cliente cliente;

        public TipoDocumentoController(ClientesDb clienteDb)
        {
            _clienteDb = clienteDb;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteDb.GetTipoDocumento());
        
        }

        [HttpGet("{id}", Name = "GetTipoDocumento")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteDb.GetByIdTipoDocumento(id);

           return Ok(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(TipoDocumento tipodocumento)
        {
              _clienteDb.CreateTipoDocumento(tipodocumento);
            return Ok(tipodocumento);
        }

        [HttpPut]
        public IActionResult Update(TipoDocumento cli)
        {
            var cliente = _clienteDb.GetByIdTipoDocumento(cli.Cod_Documento);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.UpdateTipoDocumento(cli);

            return Ok("se Actualizo el Registro");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var cliente = _clienteDb.GetByIdTipoDocumento(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.DeleteByCodTipodocumento(cliente.Cod_Documento);

            return Ok();
        }

    }
}