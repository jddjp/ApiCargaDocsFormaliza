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

        [HttpGet("{id:length(24)}/{claveinformacion}", Name = "GetCliente")]
        public IActionResult GetById(string id,string claveinformacion)
        {
            var cliente = _clienteDb.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }
            if (claveinformacion == "01")
            {
                return Ok(cliente.RutaDoc);
            }
            if(claveinformacion == "02")
            {
                return Ok(cliente.Documento);
            }
            if (claveinformacion == "03")
            {
                return Ok(cliente.ClaveOrigen);
            }
            if (claveinformacion == "04")
            {
                return Ok(cliente.ClaveOrigen);
            }
            if (claveinformacion == "05")
            {
                return Ok(cliente.FechaHoraRegistro);
            }
            if (claveinformacion == "10")
            {
                return Ok(cliente);
            }
            return BadRequest(cliente);
        }
        public static void Rename(string OldPath, string NewPath){ }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]ClienteDatos data)
        {
          //Folder name nivel alto donde se almacenan los documentos 
          //Cartera,personas,Originacion
            string folderName = @"C:\Users\DanielPerez\source\repos\ApiCargaDocsFormaliza\ExpedientesCartera";
          //Combinamos el foldername mas la clave del cliente para crear una ruta unica del cliente
            string pathString = System.IO.Path.Combine(folderName,data.ClaveExpediente);
            System.IO.Directory.CreateDirectory(pathString);
           pathString = System.IO.Path.Combine(pathString,data.Documento.FileName);
            if (!System.IO.File.Exists(pathString))
            {
             using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                    using (var stream = new FileStream(pathString, FileMode.Create))
                    {
                        await data.Documento.CopyToAsync(stream);

                    }
                }
            }else
            {

               

            }
            ////// var size = data.Documento.Length;
            //if (data.ClaveOrigen == "1")
            //{
            //    rutadoc = "192.168.200.203:9048/cartera/";
            //    filePath = "C:\\Users\\DanielPerez\\source\\repos\\ApiCargaDocsFormaliza\\cartera\\" + data.Documento.FileName + "";
            //}
            //if (data.ClaveOrigen == "2")
            //{
            //    rutadoc = "192.168.200.203:9048/personas/";
            //    filePath = "C:\\Users\\DanielPerez\\source\\repos\\ApiCargaDocsFormaliza\\personas\\" + data.Documento.FileName + "";
            //}
            //if (data.ClaveOrigen == "3")
            //{
            //    rutadoc = "192.168.200.203:9048/originacion/";
            //    filePath = "C:\\Users\\DanielPerez\\source\\repos\\ApiCargaDocsFormaliza\\originacion\\" + data.Documento.FileName + "";
            //}

            // string filePath = "C:\\inetpub\\wwwroot\\ApiBackDocumentos\\Documentos\\" + data.Documento.FileName+"";
           
            MyObject obj = new MyObject();
            var doc ="";
            using (var memoryStream = new MemoryStream())
            {
                await data.Documento.CopyToAsync(memoryStream);
                byte[] barray = memoryStream.ToArray();
                obj.Documento = barray;
                doc = Convert.ToBase64String(obj.Documento);
            }
         
              cliente = new Cliente()
            {
                Fecha_Emision=data.Fecha_Emision,
                Fecha_Vigencia=data.Fecha_Vigencia,
                ClaveOrigen = data.ClaveOrigen,
                FechaHoraRegistro=DateTime.Now.ToString(),
                Tipo_Documento=data.Tipo_Documento,
                Documento= obj,
                RutaDoc= pathString,
                 ClaveExpediente = data.ClaveExpediente,
                 //RutaDoc= "192.168.200.203:9048/Documentos/"+data.Documento.FileName
            };
            _clienteDb.Create(cliente);
           
            return CreatedAtRoute("GetCliente", new
            {
                id = cliente.Id.ToString(),
                claveinformacion="10"
            }, cliente);
            //return Ok(cliente);
        }

        [HttpPut("{id:length(24)}")]
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

        [HttpDelete("{id:length(24)}")]
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