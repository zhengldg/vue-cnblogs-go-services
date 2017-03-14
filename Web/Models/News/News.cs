using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web.Models.News
{
    [XmlRoot( ElementName = "NewsBody")]
    public class News
    {
        public string Title { get; set; }

        public string SourceName { get; set; }
        public string SubmitDate { get; set; }
        public string Content { get; set; }
        public string CommentCount { get; set; }
    }
}