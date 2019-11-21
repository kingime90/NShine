using System.Collections.Generic;
using System.Web.Mvc;
using WebApp.Demo.Services;

namespace WebApp.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        private readonly IEnumerable<IUserService> _userServices;

        public HomeController(IUserService userService, IEnumerable<IUserService> userServices)
        {
            _userService = userService;
            _userServices = userServices;
        }

        public ActionResult Index(string id)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}