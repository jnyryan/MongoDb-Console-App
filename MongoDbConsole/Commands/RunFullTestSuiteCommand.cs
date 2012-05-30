using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDbConsole.Domain;

namespace MongoDbConsole.Commands
{
    public class RunFullTestSuiteCommand: ICommand , ICommandFactory
    {
        public void Execute()
        {
            RunFullTestSuite.Run();
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
            return new RunFullTestSuiteCommand();
        }
    }
}
