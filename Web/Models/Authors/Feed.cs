using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web.Models.Authors
{
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed
    {
        [XmlElement("entry")]
        public Entry entry { get; set; }
    }

    public class Entry
    {
        public string id { get; set; }
        public string title { get; set; }
        public string updated { get; set; }
        public string blogapp { get; set; }
        public string avatar { get; set; }
        public string postcount { get; set; }
    }
}