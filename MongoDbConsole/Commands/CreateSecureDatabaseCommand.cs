using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDbConsole.Domain;

namespace MongoDbConsole.Commands
{
    public class CreateSecureDatabaseCommand: ICommand , ICommandFactory
    {
        public void Execute()
        {
            new CreateSecureDatabase().Run();
        }

        public string CommandName
        {
            get { return "CreateSecureDatabase"; }
        }

        public string Description
        {
            get { return "Runs all MongoDb Tests"; }
        }

        public ICommand MakeCommand(string[] args)
        {
            return new CreateSecureDatabaseCommand();
        }
    }
}
