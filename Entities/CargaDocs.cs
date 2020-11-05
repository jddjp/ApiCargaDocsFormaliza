using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCargaDocsFormaliza.Entities
{
    public class CargaDocs
    {

        public string NombreDoc { get; set; }
        public IFormFile Documento { get; set; }
    }
}
