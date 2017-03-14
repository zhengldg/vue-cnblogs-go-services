using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web.Models.Comments
{
    public class Comment
    {
        public string id { get; set; }
        public string title { get; set; }
        public string published { get; set; }
        public string updated { get; set; }
        public Author author { get; set; }

        public string content { get; set; }
    }

    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class CommentFeed
    {
        [XmlElement("entry")]
        public Comment[] entry { get; set; }
    }
}