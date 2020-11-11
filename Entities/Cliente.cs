using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;

namespace ApiCargaDocsFormaliza.Entities
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Clave_Origen { get; set; }
        public string Fecha_Emision { get; set; }
        public string Fecha_Vigencia { get; set; }
        public string Tipo_Documento { get; set; }
        public string Clave_Expediente { get; set; }
        public String Fecha_Registro { get; set; }
        public string URL { get; set; }
        public object Documento_data { get; set; }
      

    }
}
