using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCargaDocsFormaliza.Entities
{
    public class TipoSubExpediente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Clave { get; set; }
        public string Descripcion_SubExpediente { get; set; }
    }
}
