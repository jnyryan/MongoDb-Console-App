using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDbConsole.Contracts;
using MongoDbConsole.Repository;

namespace MongoDbConsole.Domain
{
    public class InitializeDatabase
    {
        static Random _random = new Random();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfItemsToCreate">The number of test posts to create</param>
        /// <param name="commentLimit">The upper limit of the number of random comments to create per post</param>
        static public void Run(int numberOfItemsToCreate, int commentLimit)
        {
            Console.WriteLine(String.Format("InitializeDatabase"));

            List<Post> posts = new List<Post>();
            var repo = new MongoData();
            
            repo.Clean();

            for (int i = 0; i < numberOfItemsToCreate; i++)
            {
                var post = CreateTestPost("Discussion " + i, "email" + i + "@here.com", commentLimit);
                posts.Add(post);
            }

            Console.WriteLine(String.Format("\tTotal posts[{0}] and comments[{1}]",posts.Count(),posts.Sum(post => post.Comments.Count())));
            DateTime start = DateTime.Now;
            repo.SaveBatch(posts);
            //repo.Save(posts);
            DateTime end = DateTime.Now;

            Console.WriteLine(String.Format("\tTime to insert {0} items:{1} seconds. {2} per insert"
                                            , (posts.Count() + posts.Sum(post => post.Comments.Count()))
                                            , (end - start).TotalSeconds
                                            ,
                                            (end - start).TotalSeconds/
                                            (posts.Count() + posts.Sum(post => post.Comments.Count()))));
            
            Console.WriteLine(String.Format("\tCreated MongoDB {0} with {1} rows", MongoData.MongoDbName, numberOfItemsToCreate));

            repo.SaveManuscript(CreateTestWord());
            repo.SaveManuscript(CreateTestExcel());
        }

        private static Post CreateTestPost(String title, String email, int commentLimit)
        {
            var randomString = new String(Enumerable.Range(0, 10).Select(n => (Char)(_random.Next(32, 127))).ToArray());
                
            var post = new Post
                           {
                               //Id = Guid.NewGuid(),
                               Body = randomString,
                               Title = title,
                               Comments = CreateTestComments(title, email, commentLimit)
                           };
            return post;
        }

        private static IList<Comment> CreateTestComments(String title, String email, int commentLimit)
        {
            List<Comment> comments = new List<Comment>();
            int rInt = _random.Next(0, commentLimit); //for ints

            for (int i = 0; i < rInt; i++)
            {
                var randomString = new String(Enumerable.Range(0, 10).Select(n => (Char)(_random.Next(32, 127))).ToArray());
                var comment = new Comment
                                  {
                                      TimePosted = DateTime.Now,
                                      Body = title + "... " + randomString,
                                      Email = email
                                  };
                comments.Add(comment);
            }
            return comments;
        }

        private static Word CreateTestWord()
        {
            var randomString = new String(Enumerable.Range(0, 10).Select(n => (Char)(_random.Next(32, 127))).ToArray());

            var doc = new Word()
            {
                Id = Guid.NewGuid(),
                Name = "WordName",
                Body = randomString,
                Creator = "some dude"
            };
            return doc;
        }

        private static Excel CreateTestExcel()
        {
            var randomString = new String(Enumerable.Range(0, 10).Select(n => (Char)(_random.Next(32, 127))).ToArray());

            var doc = new Excel()
            {
                Id = Guid.NewGuid(),
                Name = "ExcelName",
                SpreadsheetData = randomString,
                NumberOfRows = 23,
                Creator = "some dude"
            };
            return doc;
        }
    }
}
