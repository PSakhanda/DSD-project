using MicroBolt.Clients.Data.Contracts;
using MicroBolt.Clients.Data.Contracts.Entity;
using MicroBolt.Clients.Data.Contracts.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace MicroBolt.Clients.Data
{
    public class StoreContext:IStoreContext
    {
        IMongoDatabase database; // база данных
        IGridFSBucket gridFS;   // файловое хранилище
        public StoreContext(IOptions<Settings> options)
        {

            // строка подключения
            string connectionString = options.Value.ConnectionString;
            var connection = new MongoUrlBuilder(connectionString);

            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);

            // получаем доступ к самой базе данных
            database = client.GetDatabase(connection.DatabaseName);

            // получаем доступ к файловому хранилищу
            gridFS = new GridFSBucket(database);
        }

        // обращаемся к коллекции Client
        public IMongoCollection<Client> Clients
        {
            get { return database.GetCollection<Client>("Clients"); }
        }
    }
}
