using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDbConsole.Repository;

namespace MongoDbConsole.Domain
{
    public class RunFullTestSuite
    {
        public static void Run()
        {
            var repo = new MongoData();
            try
            {
                repo.Connect();
                InitializeDatabase.Run(10, 10);
                repo.GetAllPosts();
                repo.GetAllManuscripts();
                repo.GetAllManuscriptsAsJson();
                repo.GetAllExcel();
                repo.QueryBlogCount();
                var post = repo.QueryBlogByTitle("Discussion 2");
                repo.Update(post);
                repo.QueryBlogBodyContaining("!");
                repo.QueryCommentsBodyContaining("s");
                repo.QueryWordByName("WordName");
                repo.QueryExcelByName("ExcelName");

            }
            finally
            {
                Console.WriteLine("Finished");
                repo.Disconnect();
            }
        }
    }
}
