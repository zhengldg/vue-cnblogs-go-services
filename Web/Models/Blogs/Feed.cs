using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web.Models.Blogs
{
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed
    {
        public string id { get; set; }

        public string title { get; set; }
        public string updated { get; set; }

        public Link link { get; set; }

        [XmlElement(ElementName = "entry")]  
        public  Entry[] entry { get; set; }
    }
}