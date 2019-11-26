using System.ComponentModel;
using System.Web.Http;
using WebApp.Demo.Models;
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
        public IHttpActionResult Search([FromUri]string id)
        {
            return Ok(id);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login([FromBody]UserLoginModel model)
        {
            return Ok(model);
        }
    }
}