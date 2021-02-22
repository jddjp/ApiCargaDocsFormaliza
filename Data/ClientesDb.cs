using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using ApiCargaDocsFormaliza.Data.Configuracion;
using ApiCargaDocsFormaliza.Entities;

namespace ApiCargaDocsFormaliza.Data
{
    public class ClientesDb
    {

        //Collection Expedientes
        private readonly IMongoCollection<Cliente> _clientesCollection;
        //Collection Credenciales
        private readonly IMongoCollection<Cliente2> _clientes2Collection;
        //Collection TipoExpediente
        private readonly IMongoCollection<TipoExpediente> _clientes3Collection;
        //Collection TipoSubExpediente
        private readonly IMongoCollection<TipoSubExpediente> _clientes4Collection;
        //Collection TipoDocumento
        private readonly IMongoCollection<TipoDocumento> _clientes5Collection;
        //Collection TipoSubSubExpediente
        private readonly IMongoCollection<TipoSubSubExpediente> _clientes6Collection;

        public ClientesDb(IClientesStoreDatabaseSettings settings)
        {

            var mdbClient = new MongoClient(
            settings.ConnectionString);
            var database = mdbClient.GetDatabase(settings.DatabaseName);
            _clientesCollection = database.GetCollection<Cliente>(settings.ClientesCollectionName);
            _clientes2Collection = database.GetCollection<Cliente2>(settings.ClientesCollectionName2);
            _clientes3Collection = database.GetCollection<TipoExpediente>(settings.ClientesCollectionName3);
            _clientes4Collection = database.GetCollection<TipoSubExpediente>(settings.ClientesCollectionName4);
            _clientes5Collection = database.GetCollection<TipoDocumento>(settings.ClientesCollectionName5);
            _clientes6Collection = database.GetCollection<TipoSubSubExpediente>(settings.ClientesCollectionName6);
        }
     
        //FuncionesGet de cada Collection
        public List<Cliente> Get()
        {
            return _clientesCollection.Find<Cliente>(cli => true).ToList();
        }
        public List<Cliente2> Get2()
        {
            return _clientes2Collection.Find(cli => true).ToList();
        }
        public List<TipoExpediente>GetExpedientes()
        {
            return _clientes3Collection.Find(cli => true).ToList();
        }
        public List<TipoSubExpediente> GetSubExpedientes()
        {
            return _clientes4Collection.Find(cli => true).ToList();
        }
        public List<TipoDocumento> GetTipoDocumento()
        {
            return _clientes5Collection.Find(cli => true).ToList();
        }
        public List<TipoSubSubExpediente> GetTipoSubSubExpedientes()
        {
            return _clientes6Collection.Find(cli => true).ToList();
        }

        //FuncionesGetByid de cada Collection
        public Cliente GetById(string id)
        {
            return _clientesCollection.Find<Cliente>(cliente => cliente.Id == id).FirstOrDefault();
        }
        public List<Cliente> GetByClave_Expediente(string id)
        {
            return _clientesCollection.Find<Cliente>(cli => cli.Clave_Expediente == id).ToList();
        }
        public Cliente2 GetById2(string id)
        {
            return _clientes2Collection.Find<Cliente2>(cliente2 => cliente2.Clave_Origen == id).FirstOrDefault();
        }
        public Cliente2 GetByidclavecredenciales(string id)
        {
            return _clientes2Collection.Find<Cliente2>(cliente3 => cliente3.Clave_Origen == id).FirstOrDefault();
        }
        public TipoExpediente GetByIdExpediente(int id)
        {
            return _clientes3Collection.Find<TipoExpediente>(expediente => expediente.Clave == id).FirstOrDefault();
        }
        public TipoExpediente GetByIdExpedienteClave(int id)
        {
            return _clientes3Collection.Find<TipoExpediente>(expediente => expediente.Clave == id).FirstOrDefault();
        }
        public TipoSubExpediente GetByIdsubExpedienteClave(int id)
        {
            return _clientes4Collection.Find<TipoSubExpediente>(subexpediente => subexpediente.Clave == id).FirstOrDefault();
        }
        public TipoDocumento GetByIdTipoDocumento(int id)
        {
            return _clientes5Collection.Find<TipoDocumento>(tipodocumento => tipodocumento.Cod_Documento == id).FirstOrDefault();
        }
        public TipoSubSubExpediente GetByIdTipoSubSubExpediente(int id)
        {
            return _clientes6Collection.Find<TipoSubSubExpediente>(TipoSubSubExpediente => TipoSubSubExpediente.Clave == id).FirstOrDefault();
        }
        //Funciones Create de cada Collection
        public Cliente Create(Cliente cli)
        {
            _clientesCollection.InsertOne(cli);
            return cli;
        }

        public Cliente2 Create2(Cliente2 cli)
        {
            _clientes2Collection.InsertOne(cli);
            return cli;
        }
        public TipoExpediente CreateExpediente(TipoExpediente cli)
        {
            _clientes3Collection.InsertOne(cli);
            return cli;
        }
        public TipoSubExpediente CreateSubExpediente(TipoSubExpediente cli)
        {
            _clientes4Collection.InsertOne(cli);
            return cli;
        }
        public TipoDocumento CreateTipoDocumento(TipoDocumento cli)
        {
            _clientes5Collection.InsertOne(cli);
            return cli;
        }
        public TipoSubSubExpediente CreateTipoSubSubExpediente(TipoSubSubExpediente cli)
        {
            _clientes6Collection.InsertOne(cli);
            return cli;
        }

        //Funciones Update de cada collection
        public void Update(string id, Cliente cli)
        {
            _clientesCollection.ReplaceOne(cliente => cliente.Id == id, cli);
        }
        public void Update2(Cliente2 cli)
        {
            _clientes2Collection.ReplaceOne(cliente2 => cliente2.Id == cli.Id, cli);
        }
        public void UpdateSubexpediente(TipoSubExpediente cli)
        {
            _clientes4Collection.ReplaceOne(subexpediente => subexpediente.Clave == cli.Clave, cli);
        }
        public void UpdateExpediente(TipoExpediente cli)
        {
            _clientes3Collection.ReplaceOne(expediente => expediente.Clave == cli.Clave, cli);
        }
        public void UpdateTipoDocumento(TipoDocumento cli)
        {
            _clientes5Collection.ReplaceOne(tipodocumento => tipodocumento.Cod_Documento == cli.Cod_Documento, cli);
        }

        public void UpdateTipoSubSubExediente(TipoSubSubExpediente cli)
        {
            _clientes6Collection.ReplaceOne(TipoSubSubExpediente => TipoSubSubExpediente.Clave == cli.Clave, cli);
        }

        //Funciones delete de cada Collection
        public void Delete(Cliente cli)
        {
            _clientesCollection.DeleteOne(cliente => cliente.Id == cli.Id);
        }
        public void DeleteTipoDocumento(TipoDocumento cli)
        {
            _clientes5Collection.DeleteOne(cliente => cliente.Cod_Documento == cli.Cod_Documento);
        }

        //Funciones delete byid de cada collection
        public void DeleteById(string id)
        {
            _clientesCollection.DeleteOne(cliente => cliente.Id == id);
        }

        public void DeleteById2(string id)
        {
            _clientes2Collection.DeleteOne(cliente2 => cliente2.Id == id);
        }
        public void DeleteByIdExpediente(string id)
        {
            _clientes3Collection.DeleteOne(expediente => expediente.Id == id);
        }
        public void DeleteByIdSubExpediente(string id)
        {
            _clientes4Collection.DeleteOne(expediente => expediente.Id == id);
        }
        public void DeleteByCodTipodocumento(int id)
        {
            _clientes5Collection.DeleteOne(tipodocumento => tipodocumento.Cod_Documento == id);
        }
        public void DeleteByIDSubSubExpediente(int id)
        {
            _clientes6Collection.DeleteOne(TipoSubSubExpediente => TipoSubSubExpediente.Clave == id);
        }

    }
    
    
}