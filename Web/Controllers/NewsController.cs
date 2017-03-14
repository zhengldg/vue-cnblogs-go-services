using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using Web.Models.Comments;
using Web.Models.News;

namespace Web.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiController
    {
        /// <summary>
        /// 最近博客
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页数量</param>
        [Route("recent/paged/{pageIndex}/{pageSize}")]
        [HttpGet()]
        public async Task<Feed> GetRecent(int pageIndex, int pageSize)
        {
            HttpClient client = new HttpClient();
            int num = pageIndex * pageSize;
            var url = string.Format("{0}news/recent/{1}", Config.API_BASEURL, num);
            var content = await client.GetStringAsync(url);
            Feed feed = XmlHelper.XmlDeserialize<Feed>(content, Encoding.UTF8);
            if (pageIndex > 1 && feed.entry.Length > pageSize)
            {
                var page = feed.entry.Length / pageSize;
                int len = pageSize;
                var div = feed.entry.Length % pageSize;
                if (div == 0)
                {
                    page = page - 1;
                }
                else
                {
                    len = div;
                }
                var array = new Entry[len];
                Array.Copy(feed.entry, page * pageSize, array, 0, len);
                feed.entry = array;
            }

            foreach(var item in feed.entry)
            {
                if(!string.IsNullOrWhiteSpace(item.topicIcon)) 
                item.topicIcon = item.topicIcon.Replace("///images0.cnblogs.com/news_topic","");
            }

            return feed;
        }

        /// <summary>
        /// 获取博客内容
        /// </summary>
        [Route("item/{id}")]
        [HttpGet()]
        public async Task<News> GetBody(string id)
        {
            HttpClient client = new HttpClient();
            var url = string.Format("{0}news/item/{1}", Config.API_BASEURL, id);
            var content = await client.GetStringAsync(url);
            var article = XmlHelper.XmlDeserialize<News>(content, Encoding.UTF8);
            return article;
        }

        /// <summary>
        /// 获取博客评论
        /// </summary>
        [Route("comments/paged/{id}/{pageIndex}/{pageSize}")]
        [HttpGet()]
        public async Task<CommentFeed> GetComments(string id, string pageIndex, string pageSize)
        {
            HttpClient client = new HttpClient();
            var url = string.Format("{0}news/item/{1}/comments/{2}/{3}", Config.API_BASEURL, id, pageIndex, pageSize);
            var content = await client.GetStringAsync(url);
            var comments = XmlHelper.XmlDeserialize<CommentFeed>(content, Encoding.UTF8);
            return comments;
        }
    }
}
