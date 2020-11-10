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
        public string ClaveOrigen { get; set; }
        public string Fecha_Emision { get; set; }
        public string Fecha_Vigencia { get; set; }
        public string Tipo_Documento { get; set; }
        public string ClaveExpediente { get; set; }
        public String FechaHoraRegistro { get; set; }
        public string RutaDoc { get; set; }
        public object Documento { get; set; }
      

    }
}
