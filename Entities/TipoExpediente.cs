using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCargaDocsFormaliza.Entities
{
    public class TipoExpediente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Clave { get; set; }
        public string Descripcion_Expediente { get; set; }
    }
}
