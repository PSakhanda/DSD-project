using MicroBolt.Stock.Data.Contracts.Models;
using MicroBolt.Stock.Data.Contracts.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace MicroBolt.Stock.Data
{
    public class StoreContext
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

        // обращаемся к коллекции Bolts
        public IMongoCollection<Bolt> Bolts
        {
            get { return database.GetCollection<Bolt>("Bolts"); }
        }
    }
}
