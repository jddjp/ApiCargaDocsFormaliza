using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCargaDocsFormaliza.Data.Configuracion
{
    public class ClientesStoreDatabaseSettings : IClientesStoreDatabaseSettings
    {
        public string ClientesCollectionName { get; set; }
        public string ClientesCollectionName2 { get; set; }
        public string ClientesCollectionName3 { get; set; }
        public string ClientesCollectionName4 { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IClientesStoreDatabaseSettings
    {
        public string ClientesCollectionName2 { get; set; }
        public string ClientesCollectionName3 { get; set; }
        public string ClientesCollectionName4 { get; set; }
        string ClientesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
