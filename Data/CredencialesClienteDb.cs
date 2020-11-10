using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using ApiCargaDocsFormaliza.Data.Configuracion;
using ApiCargaDocsFormaliza.Entities;

namespace ApiCargaDocsFormaliza.Data
{
    public class CredencialesClienteDb
    {
        private readonly IMongoCollection<CredencialesCliente> _CredencialesClientesCollection;

        public CredencialesClienteDb(ICredencialesClienteDatabaseSettings settings)
        {

             var mdbClient = new MongoClient(
                 settings.ConnectionString);
           
            var database = mdbClient.GetDatabase(settings.DatabaseName);
            _CredencialesClientesCollection = database.GetCollection<CredencialesCliente>(settings.ClientesCollectionName);
        }

        public List<CredencialesCliente> Get()
        {
            return _CredencialesClientesCollection.Find(cli => true).ToList();
        }

        public CredencialesCliente GetById(string clave)
        {
            return _CredencialesClientesCollection.Find<CredencialesCliente>(CredencialesCliente => CredencialesCliente.clave == clave).FirstOrDefault();
        }

        public CredencialesCliente Create(CredencialesCliente cli)
        {
            _CredencialesClientesCollection.InsertOne(cli);
            return cli;
        }

        public void Update(string clave, CredencialesCliente cli)
        {
            _CredencialesClientesCollection.ReplaceOne(CredencialesCliente => CredencialesCliente.clave == clave, cli);
        }

        public void Delete(Cliente cli)
        {
            _CredencialesClientesCollection.DeleteOne(CredencialesCliente => CredencialesCliente.clave == cli.Id);
        }

        public void DeleteById(string clave)
        {
            _CredencialesClientesCollection.DeleteOne(CredencialesCliente => CredencialesCliente.clave == clave);
        }
    }

}