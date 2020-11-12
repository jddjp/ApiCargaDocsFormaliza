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

        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult GetById(string id)
        {
            var cliente = _clienteDb.GetByClave_Expediente(id);
            if (cliente.Count == 0)
            {
                return NotFound();
            }
           
            return Ok(cliente);
           
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
            var tipoexpediente = _clienteDb.GetByIdExpedienteClave(data.TipoExpediente).Descripcion_Expediente;
            string pathString = System.IO.Path.Combine(
                  _clienteDb.GetById2(data.CredencialesCliente).UbicacionRaiz + _clienteDb.GetById2(data.CredencialesCliente).Clave,
                tipoexpediente, data.IdExpediente,
                  subex);
         //Creamos el Directorio 
            System.IO.Directory.CreateDirectory(pathString);
            pathString = System.IO.Path.Combine(pathString, data.Documento.FileName);
          //Validamos si el documento Existe
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
            //Copiamos el documento y o archivo en el servidor
            using (var stream = new FileStream(pathString, FileMode.Create))
            {
                await data.Documento.CopyToAsync(stream);

            }
            Expediente obj = new Expediente();
            var doc = "";
            using (var memoryStream = new MemoryStream())
            {
                await data.Documento.CopyToAsync(memoryStream);
                byte[] barray = memoryStream.ToArray();
                obj.Documento = barray;
                doc = Convert.ToBase64String(obj.Documento);
            }
            //Guardamos La informacion Correspondiente en la base de datos
            cliente = new Cliente()
            {
                Clave_Origen = _clienteDb.GetById2(data.CredencialesCliente).Clave,
                Fecha_Emision = data.Fecha_Emision,
                Fecha_Vigencia = data.Fecha_Vigencia,
                Clave_Expediente = data.IdExpediente,
                Fecha_Registro = DateTime.Now.ToString(),
                Tipo_Expediente = tipoexpediente,
                Tipo_Documento=data.Tipo_Documento,
                Documento_data = doc,
                URL = "https://qa.adocs.aprecia.com.mx:9048/Documentos/"+_clienteDb.GetById2(data.CredencialesCliente).Clave+"/"+
                 _clienteDb.GetByIdExpedienteClave(data.TipoExpediente).Descripcion_Expediente+"/"+
                data.IdExpediente+"/"+
                subex
                +"/"+data.Documento.FileName
            };
            //Se crea el documento en la base de datos 
            _clienteDb.Create(cliente);
            //redireccionamos la api a la funcin getcliente donde busca sus clientes 
            return CreatedAtRoute("GetCliente", new
            {
                id = cliente.Clave_Expediente.ToString()
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