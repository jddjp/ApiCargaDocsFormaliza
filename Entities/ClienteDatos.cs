using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiCargaDocsFormaliza.Entities
{
    public class ClienteDatos
    {
        
      
        public string Fecha_Emision { get; set; }
        public string Fecha_Vigencia { get; set; }
        //TipoExpediente
        public string TipoExpediente { get; set; }
        //ClaveExpediente 
        public string TipocSubExpediente { get; set; }
        //IdentificadorExpediente
        public string IdExpediente { get; set; }
        //Pedir Credenciales Cliente
        public string CredencialesCliente { get; set; }
        //DocumentoFisico
        public IFormFile Documento { get; set; }
        public string Tipo_Documento { get; set; }

    }
}
