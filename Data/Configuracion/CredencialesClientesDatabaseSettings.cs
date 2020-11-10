namespace ApiCargaDocsFormaliza.Data.Configuracion
{
    public class CredencialesClientesDatabaseSettings : ICredencialesClienteDatabaseSettings
    {
        public string ClientesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ICredencialesClienteDatabaseSettings
    {
        string ClientesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}