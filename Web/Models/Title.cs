﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web.Models
{
    public class Title
    {
        [XmlAttribute("text")]
        public string text { get; set; }
    }
}