using NShine.Web.WebApi.Binders;
using System.Web.Http;
using WebApp.Demo.Services;
using WebApp.Demo.ViewModels;
using System.Collections.Generic;

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
        /// 登录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login([FromBody]UserLoginModel model)
        {
            return Ok(model);
        }

        /// <summary>
        /// 登录扩展
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult LoginEx([FromBodyEx]UserLoginModel model)
        {
            return Ok(model);
        }

        /// <summary>
        /// 登录扩展集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult LoginExCollection([FromBodyEx]IEnumerable<UserLoginModel> models)
        {
            return Ok(models);
        }
    }
}