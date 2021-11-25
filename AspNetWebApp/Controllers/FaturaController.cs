using System.Linq;
using System.Web.Mvc;
using AspNetWebApp.Models.Siniflar;

namespace AspNetWebApp.Controllers
{
    public class FaturaController : Controller
    {
        // GET
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}