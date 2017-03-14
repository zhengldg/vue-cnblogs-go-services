using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web.Models.Blogs
{
    [XmlRoot()]
    public class Blog
    {
        public string text { get; set; }
    }
}