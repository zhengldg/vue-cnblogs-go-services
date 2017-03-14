using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web.Models
{
    public class Link
    {
        [XmlAttribute("href")]
        public string href { get; set; }
    }
}