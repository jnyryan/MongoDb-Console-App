using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MongoDB.Driver;
using MongoDbConsole.Repository;

namespace MongoDbConsole.Domain
{
    public class CreateSecureDatabase
    {
        //public const string MongoDbLocation = "mongodb://localhost";
        public const string MongoDbLocation = "mongodb://john:123456@GLGDUBJARYAN01.GLGDEV.COM/secdb";
        public const string MongoDbName = "secdb";
        public MongoServer MongoDbServer { get; set; }
        public MongoDatabase MongoDb { get; set; }
        
        public void Run()
        {
            
            try
            {
                MongoDbServer = MongoServer.Create(MongoDbLocation);
                MongoDb = MongoDbServer.GetDatabase(MongoDbName);

                MongoCollection docs = MongoDb.GetCollection("docs");
                docs.Save(new { Id = Guid.NewGuid(), Name = "John"});
                

            }
            finally
            {
                Console.WriteLine("Finished");
                MongoDbServer.Disconnect();
            }
        }
    }
}
