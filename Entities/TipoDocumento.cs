using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCargaDocsFormaliza.Entities
{
    public class TipoDocumento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Cod_Documento { get; set; }
        public string Descripcion_Documento { get; set; }

    }
}
