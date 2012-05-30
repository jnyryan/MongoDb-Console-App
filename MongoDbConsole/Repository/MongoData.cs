using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbConsole.Contracts;

namespace MongoDbConsole.Repository
{

    /// <summary>
    /// http://joedoyle.us/getting-started-with-mongodb-and-the-10gen-c
    /// 
    /// </summary>
    public class MongoData
    {
        public const string MongoDbLocation = "mongodb://localhost";
        public const string MongoDbName = "blogtest";
        public MongoServer MongoDbServer { get; set; }
        public MongoDatabase MongoDb { get; set; }

        public MongoData()
        {
            MongoDbServer = null;
            MongoDb = null;
        }

        public void Connect()
        {
            MongoDbServer = MongoServer.Create(MongoDbLocation);
            MongoDb = MongoDbServer.GetDatabase(MongoDbName);
        }

        public void Disconnect()
        {
            if (MongoDbServer != null)
                MongoDbServer.Disconnect();
        }

        public void Clean()
        {
            Connect();
            MongoDb.Drop();
            Console.WriteLine(String.Format("Clean\t\t\tDropped MongoDB {0}", MongoDbName));

        }

        public void Save(Post post)
        {
            MongoCollection posts = MongoDb.GetCollection("posts");
            posts.Save(post);
        }

        public void Save(List<Post> posts)
        {
            MongoCollection postCollection = MongoDb.GetCollection("posts");
            foreach (var post in posts)
            {
                postCollection.Save(post);
            }
        }

        public void SaveBatch(List<Post> posts)
        {
            MongoCollection postCollection = MongoDb.GetCollection("posts");
            postCollection.InsertBatch(posts);
        }

        public void Update(Post post)
        {
            MongoCollection posts = MongoDb.GetCollection("posts");
            post.Body = "Updated";
            posts.Save(post);
            Console.WriteLine(String.Format("Update"));
            Console.WriteLine(String.Format("\t{0}", post));

        }

        public void QueryBlogCount()
        {
            MongoCollection posts = MongoDb.GetCollection("posts");
            Console.WriteLine(String.Format("QueryBlogCount"));
            Console.WriteLine(String.Format("\t{0}", posts.Count()));

        }

        public Post QueryBlogByTitle(string title)
        {
            MongoCollection posts = MongoDb.GetCollection("posts");
            var post = posts.AsQueryable<Post>().FirstOrDefault(c => c.Title == title);
            Console.WriteLine(String.Format("QueryBlogByTitle"));
            Console.WriteLine(String.Format("\t{0}", post));
            return post;
        }

        public void GetFirstPost()
        {
            MongoCollection posts = MongoDb.GetCollection("posts");
            var query = posts.AsQueryable<Post>();
            Console.WriteLine(String.Format("GetFirstPost"));
            Console.WriteLine(String.Format("\t{0}", query.FirstOrDefault()));
        }

        public void GetAllPosts()
        {
            MongoCollection posts = MongoDb.GetCollection("posts");
            var query = posts.AsQueryable<Post>();
            Console.WriteLine(String.Format("GetAllPosts"));

            foreach (var post in query)
            {
                Console.WriteLine(String.Format("\t{0}", post));
                
            }
        }

        public void QueryBlogBodyContaining(string s)
        {
            var posts = MongoDb.GetCollection<Post>("posts");

            var query = MongoDB.Driver.Builders.Query.Matches("Body", BsonRegularExpression.Create(new Regex(s)));
            
            var result = posts.Find(query);
            Console.WriteLine(String.Format("QueryBlogBodyContaining"));
            foreach (var post in result)
            {
                Console.WriteLine(String.Format("\t{0}", post));

            }
        }

        public void QueryCommentsBodyContaining(string s)
        {
            var posts = MongoDb.GetCollection<Post>("posts");

            var query = MongoDB.Driver.Builders.Query.Matches("Comments.Body", BsonRegularExpression.Create(new Regex(s)));

            var result = posts.Find(query);
            Console.WriteLine(String.Format("QueryCommentsBodyContaining"));
            foreach (var post in result)
            {
                Console.WriteLine(String.Format("\t{0}", post));
            }
        }

        public void SaveManuscript(Manuscript doc)
        {
            MongoCollection docs = MongoDb.GetCollection("manuscript");
            docs.Save(doc);
        }

        public Word QueryWordByName(string name)
        {
            MongoCollection docs = MongoDb.GetCollection("manuscript");
            var doc = docs.AsQueryable<Word>().First(c => c.Name == name);
            Console.WriteLine(String.Format("QueryWordByName"));
            Console.WriteLine(String.Format("\t{0}", doc));
            return doc;
        }

        public Excel QueryExcelByName(string name)
        {
            MongoCollection docs = MongoDb.GetCollection("manuscript");
            var doc = docs.AsQueryable<Excel>().FirstOrDefault(c => c.Name == name);
            Console.WriteLine(String.Format("QueryExcelByName"));
            Console.WriteLine(String.Format("\t{0}", doc));
            return doc;
        }

        public void GetAllManuscripts()
        {
            MongoCollection docs = MongoDb.GetCollection("manuscript");
            var query = docs.AsQueryable<Manuscript>();
            Console.WriteLine(String.Format("GetAllManuscripts"));

            foreach (var doc in query)
            {
                Console.WriteLine(String.Format("\t{0}", doc));
            }
        }

        public void GetAllManuscriptsAsJson()
        {
            MongoCollection docs = MongoDb.GetCollection("manuscript");
            var query = docs.AsQueryable<Manuscript>();
            Console.WriteLine(String.Format("GetAllManuscripts"));

            foreach (var doc in query)
            {
                Console.WriteLine(String.Format("\t{0}", doc.ToJson()));
            }
        }

        public void GetAllExcel()
        {
            MongoCollection docs = MongoDb.GetCollection("manuscript");
            //var query = docs.AsQueryable<IEnumerable<Excel>>().FirstOrDefault(c => c.() == typeof(Excel));
            //Console.WriteLine(String.Format("GetAllExcel"));

            //foreach (var doc in query)
            //{
            //    Console.WriteLine(String.Format("\t{0}", doc));
            //}
        }
    }
}
