using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MongoDB.Driver;

namespace TaskManagerProject.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        internal IMongoCollection<T>? GetCollection<T> (string collectionName)
        {
            return _database.GetCollection <T> (collectionName);
            
        }
        

    }
}
