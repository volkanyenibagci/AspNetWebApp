using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetWebApp.Models.Siniflar;

namespace AspNetWebApp.Controllers
{
    public class HomeController : Controller
    {

        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult Kategori()
        {
            
            var degerler = db.Kategoris.ToList();
            //IQueryable<Kategori> query = db.Kategoris;

            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            db.Kategoris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = db.Kategoris.Find(id);
            db.Kategoris.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoris.Find(id);
            return View("KategoriGetir",kategori);

        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = db.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Kategori");

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