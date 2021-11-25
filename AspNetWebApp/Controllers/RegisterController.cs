using System.Web.Mvc;
using AspNetWebApp.Models.Siniflar;

namespace AspNetWebApp.Controllers
{
    public class RegisterController : Controller
    {
        
        Context c = new Context();
        // GET
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult KullaniciEkle(Admin a)
        {

            //TODO Durum True yapılacak listeye gelmesi için
            
            c.Admins.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}