using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ApiCargaDocsFormaliza.Entities
{
    public class Cliente2
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Clave_Origen { get; set;}
        public string Razon_Social { get; set; }
        public string Ubicacion_Raiz { get; set; }
      
    }
}
