using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDbConsole.Contracts
{
    public abstract class Manuscript
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Creator { get; set; }
    }

    public class Word : Manuscript
    {
        public string Body { get; set; }

        public override string ToString()
        {
            return String.Format("[Name] {0} [Body] {1}",Name, Body);
        }
    }

    public class Excel : Manuscript
    {
        public string SpreadsheetData { get; set; }
        public int NumberOfRows { get; set; }

        public override string ToString()
        {
            return String.Format("[Name] {0} [SpreadsheetData] {1} NumberOfRows {2}", Name, SpreadsheetData, NumberOfRows);
        }
    }
}
