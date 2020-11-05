using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCargaDocsFormaliza.Data.Configuracion
{
    public class IClientSettingsService
    {
        MongoClient Client { get; }
    }
}
