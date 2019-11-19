using System.Web.Http;
using WebApp.Demo.Services;

namespace WebApp.Demo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeApiController : ApiController
    {
        private readonly IUserService _userService;

        public HomeApiController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Search(string id)
        {
            return Ok(id);
        }
    }
}