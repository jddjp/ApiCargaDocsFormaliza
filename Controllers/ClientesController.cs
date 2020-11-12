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
    public class ClientesController : ControllerBase
    {

        private readonly ClientesDb _clienteDb;
        private Cliente cliente;

        public ClientesController(ClientesDb clienteDb)
        {
            _clienteDb = clienteDb;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteDb.Get());
        }

        [HttpGet("{id}/{claveinformacion}", Name = "GetCliente")]
        public IActionResult GetById(string id, string claveinformacion)
        {
            var cliente = _clienteDb.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }
            if (claveinformacion == "01")
            {
                return Ok(cliente.URL);
            }
            if (claveinformacion == "02")
            {
                return Ok(cliente.Documento_data);
            }
            if (claveinformacion == "03")
            {
                return Ok(cliente.Clave_Origen);
            }
            if (claveinformacion == "04")
            {
                return Ok(cliente.Clave_Origen);
            }
            if (claveinformacion == "05")
            {
                return Ok(cliente.Fecha_Registro);
            }
            if (claveinformacion == "10")
            {
                return Ok(cliente);
            }
            return BadRequest(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]ClienteDatos data)
        {
           
          //Validamos si los credenciales de quien solicita la peticion existen 
         //y nos traemos la carpeta raiz definida para sus documentos
            if (_clienteDb.GetById2(data.CredencialesCliente) == null) return BadRequest("No tiene acceso");
            //Vamos a validar la ruta de Expedientecliente pues esta ruta no tiene TipóSubExpediente
            var subex="";
            if (data.TipoExpediente == "0027")
            {
                subex = data.IdExpediente;
            }
            else 
            {
                subex =_clienteDb.GetByIdsubExpedienteClave(data.TipocSubExpediente).Descripcion_SubExpediente;

            }
            //Combinamos el foldername mas la clave del cliente para crear una ruta unica del cliente de Peticiones para Api
            string pathString = System.IO.Path.Combine(
                  _clienteDb.GetById2(data.CredencialesCliente).UbicacionRaiz + _clienteDb.GetById2(data.CredencialesCliente).Clave,
                  _clienteDb.GetByIdExpedienteClave(data.TipoExpediente).Descripcion_Expediente, data.IdExpediente,
                subex);
         
            System.IO.Directory.CreateDirectory(pathString);
            pathString = System.IO.Path.Combine(pathString, data.Documento.FileName);
           
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }

                }
            }
            else
            {
                return BadRequest("El documento ya Existe");

            }
            using (var stream = new FileStream(pathString, FileMode.Create))
            {
                await data.Documento.CopyToAsync(stream);

            }

            // string filePath = "C:\\inetpub\\wwwroot\\ApiBackDocumentos\\Documentos\\" + data.Documento.FileName + "";

            Expediente obj = new Expediente();
            var doc = "";
            using (var memoryStream = new MemoryStream())
            {
                await data.Documento.CopyToAsync(memoryStream);
                byte[] barray = memoryStream.ToArray();
                obj.Documento = barray;
                doc = Convert.ToBase64String(obj.Documento);
            }

            cliente = new Cliente()
            {
                Clave_Origen = _clienteDb.GetById2(data.CredencialesCliente).Clave,
                Fecha_Emision = data.Fecha_Emision,
                Fecha_Vigencia = data.Fecha_Vigencia,
                Clave_Expediente = data.IdExpediente,
                Fecha_Registro = DateTime.Now.ToString(),
                Tipo_Documento = data.TipoExpediente,
                Documento_data = obj,
                URL = pathString,
                // ClaveExpediente = data.ClaveExpediente,
                //RutaDoc= "192.168.200.203:9048/Documentos/"+data.Documento.FileName
            };
            _clienteDb.Create(cliente);

            return CreatedAtRoute("GetCliente", new
            {
                id = cliente.Id.ToString(),
                claveinformacion = "10"
            }, cliente);
            //return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Cliente cli)
        {
            var cliente = _clienteDb.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.Update(id, cli);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            var cliente = _clienteDb.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteDb.DeleteById(cliente.Id);

            return NoContent();
        }

    }
}