using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MongoDbConsole.Contracts
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CharCount { get { return Body.Count(); } }
        public IList<Comment> Comments { get; set; }

        public override string ToString()
        {
            return String.Format("[Title] {0} [Body] {1} [#Comments] {2}", Title, Body, Comments.Count);
        }
    }

    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime TimePosted { get; set; }
        public String Body { get; set; }
        public String Email { get; set; }
    }
}
