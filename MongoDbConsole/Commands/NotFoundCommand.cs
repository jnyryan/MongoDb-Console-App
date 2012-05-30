using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDbConsole.Domain;

namespace MongoDbConsole.Commands
{
    public class InvalidCommand: ICommand
    {
        public string Name { get; set; }

        public void Execute()
        {
            Console.WriteLine("Couldn't find command: " + Name);
        }
    }
}
