using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MongoDbConsole.Commands;
using MongoDbConsole.Contracts;
using MongoDbConsole.Domain;
using MongoDbConsole.Repository;

namespace MongoDbConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("App:   MongoDbConsole"); 
                
                var availableCommands = GetAvailableCommands();

                if(args.Length == 0)
                {
                    CommandParser.PrintUsage(availableCommands);
                    return;
                }
                CommandParser.Run(args, availableCommands);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
                       {
                           new InitializeDatabaseCommand(),
                           new RunFullTestSuiteCommand(), 
                           new CreateSecureDatabaseCommand(), 
                       };
        }

        
    }
}
