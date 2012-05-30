using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDbConsole.Domain;

namespace MongoDbConsole.Commands
{
    public class InitializeDatabaseCommand: ICommand , ICommandFactory
    {
        public int NumberOfItemsToCreate { get; set; }
        public int CommentLimit { get; set; }

        public void Execute()
        {
            InitializeDatabase.Run(NumberOfItemsToCreate, CommentLimit);
        }

        public string CommandName
        {
            get { return "InitializeDatabase"; }
        }

        public string Description
        {
            get { return "Recreates the Mongo Database"; }
        }

        public ICommand MakeCommand(string[] args)
        {
            return new InitializeDatabaseCommand
                       {
                           NumberOfItemsToCreate = int.Parse(args[0]),
                           CommentLimit = int.Parse(args[1])
                       };
        }
    }
}
