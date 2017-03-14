using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using Web.Models.Blogs;
using Web.Models.Comments;

namespace Web.Controllers
{
    [RoutePrefix("api/blogs")]
    public class BlogsController : ApiController
    {
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        [Route("paged/{pageIndex}/{pageSize}")]
        [HttpGet()]
        public async Task<Feed> Get(int pageIndex, int pageSize)
        {
            HttpClient client = new HttpClient();
            var url = string.Format("{0}blog/sitehome/paged/{1}/{2}", Config.API_BASEURL, pageIndex, pageSize);
            var content = await client.GetStringAsync(url);
            Feed feed = XmlHelper.XmlDeserialize<Feed>(content, Encoding.UTF8);

            return feed;
        }

        /// <summary>
        /// 获取博客内容
        /// </summary>
        [Route("blog/post/{id}")]
        [HttpGet()]
        public async Task<string> Get(string id)
        {
            HttpClient client = new HttpClient();
            var url = string.Format("{0}blog/post/body/{1}", Config.API_BASEURL, id);
            var content = await client.GetStringAsync(url);
            var article = XmlHelper.XmlDeserialize<string>(content, Encoding.UTF8);
            return article;
        }

        /// <summary>
        /// 获取推荐博客
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页数量</param>
        [Route("topdiggs/paged/{pageIndex}/{pageSize}")]
        [HttpGet()]
        public async Task<Feed> GetTopDiggs(int pageIndex, int pageSize)
        {
            HttpClient client = new HttpClient();
            int num = pageIndex * pageSize ;
            var url = string.Format("{0}blog/TenDaysTopDiggPosts/{1}", Config.API_BASEURL, num);
            var content = await client.GetStringAsync(url);
            Feed feed = XmlHelper.XmlDeserialize<Feed>(content, Encoding.UTF8);
            if (pageIndex > 1 && feed.entry.Length > pageSize)
            {
                var page = feed.entry.Length / pageSize;
                int len = pageSize;
                var div = feed.entry.Length % pageSize;
                if(div == 0)
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

            return feed;
        }

        /// <summary>
        /// 获取推荐博客
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页数量</param>
        [Route("topviews/paged/{pageIndex}/{pageSize}")]
        [HttpGet()]
        public async Task<Feed> GetTopViews(int pageIndex, int pageSize)
        {
            HttpClient client = new HttpClient();
            int num = pageIndex * pageSize;
            var url = string.Format("{0}blog/48HoursTopViewPosts/{1}", Config.API_BASEURL, num);
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

            return feed;
        }

        /// <summary>
        /// 获取博客评论
        /// </summary>
        [Route("comments/paged/{id}/{pageIndex}/{pageSize}")]
        [HttpGet()]
        public async Task<CommentFeed> GetComments(string id, string pageIndex, string pageSize)
        {
            HttpClient client = new HttpClient();
            var url = string.Format("{0}blog/post/{1}/comments/{2}/{3}", Config.API_BASEURL, id, pageIndex, pageSize);
            var content = await client.GetStringAsync(url);
            var comments = XmlHelper.XmlDeserialize<CommentFeed>(content, Encoding.UTF8);
            return comments;
        }
    }
}
