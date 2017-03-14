using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web.Models.Blogs
{
    public class Entry
    {
        public string id { get; set; }

        public string title { get; set; }

        public string summary { get; set; }

        public string published { get; set; }

        public string updated { get; set; }

        public Author author { get; set; }

        public Link link { get; set; }

        public string blogapp { get; set; }
        public string diggs { get; set; }
        public string views { get; set; }
        public string comments { get; set; }

    }
}