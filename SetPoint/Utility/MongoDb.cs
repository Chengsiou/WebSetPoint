using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Configuration;

namespace SetPoint.Utility
{
    public class MongoDb
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString;// "mongodb://localhost";
        static string databaseName = "db_dev";
        public static async Task<List<BsonDocument>> QueryDB(FilterDefinition<BsonDocument> filter,string collection)
        {
            var _client = new MongoClient(connectionString);
            var _database = _client.GetDatabase(databaseName);
            var _collection = _database.GetCollection<BsonDocument>(collection);
            var result = await  _collection.Find(filter).ToListAsync();
            return result;
        }
    }
}