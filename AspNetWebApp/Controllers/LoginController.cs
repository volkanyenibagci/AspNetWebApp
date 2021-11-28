using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AspNetWebApp.Models.Siniflar;

namespace AspNetWebApp.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin a)
        {
            
            return View();
        }
        
        // GET
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin a)
        {
            var bilgiler = c.Admins.FirstOrDefault(x=>x.KullaniciAd==a.KullaniciAd&&x.Sifre==a.Sifre);

            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd,false);
                Session["AdminKullaniciAdi"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Anasayfa", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}