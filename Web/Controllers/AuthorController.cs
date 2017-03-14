using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Models.Authors;

namespace Web.Controllers
{
    [RoutePrefix("api/author")]
    public class AuthorController : ApiController
    {
        [Route("search/{t}")]
        [HttpGet]
        public async Task<Feed>  Search(string t)
        {
            HttpClient client = new HttpClient();
            var url = string.Format("{0}blog/bloggers/search?t={1}", Config.API_BASEURL, t);
            var content = await client.GetStringAsync(url);
            Feed feed = XmlHelper.XmlDeserialize<Feed>(content, Encoding.UTF8);

            return feed;
        }
    }
}
