using MongoDB.Driver;
using MongoDbEg2.Models;
using MongoDbEg2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDbEg2.App_Start
{
    
    public class Democontext
    {
        public IMongoDatabase Database;

        public Democontext()
        {
            var ConnectionString = Settings.Default.DbConnectionString;
            var settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
            var Client = new MongoClient(settings);
            Database = Client.GetDatabase(Settings.Default.DatabaseName);
        }
        public IMongoCollection<Batch> Batch => Database.GetCollection<Batch>("batch");
    }
}