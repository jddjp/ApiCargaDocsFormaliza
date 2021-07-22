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
        public DateTime Fecha_Emision { get; set; }
        public DateTime Fecha_Vigencia { get; set; }
        public string Tipo_Documento { get; set; }
        public string Tipo_Expediente { get; set; }
        
        public string Clave_Expediente { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string URL { get; set; }
        [BsonElement("Documento_data")]
        [BsonRepresentation(BsonType.String)]
        public string Documento_data { get; set; }
        //Agregar el tipo de ruta para 
        public int Tipo_Sub_SubExpediente { get; set; }
        //Se agreaga el tipo de documento para poder escagar el expediente con todo y nombre
        public string NombreDocumento { get; set; }

    }
}
