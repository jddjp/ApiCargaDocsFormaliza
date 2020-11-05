using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiCargaDocsFormaliza.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ApiCargaDocsFormaliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargaDocsController : ControllerBase
    {
        // GET: api/CargaDocs
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CargaDocs/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CargaDocs
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CargaDocs cargadocs)
        {

            var size = cargadocs.Documento.Length;
            //  var filePaths = new List<String>();
             var filePath = Path.Combine(Directory.GetCurrentDirectory() ,cargadocs.Documento.FileName);
           // string filePath = "C:\\Users\\DanielPerez\\Desktop\\DocumentosCargaPruebas\\" +cargadocs.Documento.FileName + "";

                   // filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await cargadocs.Documento.CopyToAsync(stream);

                    }

            return Ok(new {size,filePath });
           
        }

        // PUT: api/CargaDocs/5
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
