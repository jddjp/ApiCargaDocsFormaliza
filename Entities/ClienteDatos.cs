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
        
      
        public DateTime Fecha_Emision { get; set; }
        public DateTime Fecha_Vigencia { get; set; }
        //TipoExpediente
        public int TipoExpediente { get; set; }
        //ClaveExpediente 
        public int TipocSubExpediente { get; set; }
        //IdentificadorExpediente
        public string IdExpediente { get; set; }
        //Pedir Credenciales Cliente
        public string CredencialesCliente { get; set; }
        //DocumentoFisico
        public IFormFile Documento { get; set; }
        public int Tipo_Documento { get; set; }

    }
}
