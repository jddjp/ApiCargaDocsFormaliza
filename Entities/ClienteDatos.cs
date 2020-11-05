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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ClaveOrigen { get; set; }
        public string Fecha_Emision { get; set; }
        public string Fecha_Vigencia { get; set; }
        public string Tipo_Documento { get; set; }
        public string claveCliente { get; set; }
       public string RutaDoc { get; set; }
        public string info { get; set; }
        
       public IFormFile Documento { get; set; }
      

    }
}
