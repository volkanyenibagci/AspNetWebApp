using System.Web.Mvc;

namespace AspNetWebApp.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        // GET
        public ActionResult Login()
        {
            return View();
        }
    }
}