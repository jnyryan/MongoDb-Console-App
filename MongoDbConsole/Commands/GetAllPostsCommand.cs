using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDbConsole.Domain;
using MongoDbConsole.Repository;

namespace MongoDbConsole.Commands
{
    public class GetAllPostsCommand: ICommand , ICommandFactory
    {
        public void Execute()
        {
            var repo = new MongoData();
            repo.GetAllPosts();
        }

        public string CommandName
        {
            get { return "RunFullTestSuite"; }
        }

        public string Description
        {
            get { return "Runs all MongoDb Tests"; }
        }

        public ICommand MakeCommand(string[] args)
        {
            return new GetAllPostsCommand();
        }
    }
}
