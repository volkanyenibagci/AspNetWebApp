using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetWebApp.Models.Siniflar;

namespace AspNetWebApp.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]

        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            var cr = c.Carilers.Find(p.CariID);
            cr.CariAd= p.CariAd;
            cr.CariSoyad= p.CariSoyad;
            cr.CariSehir= p.CariSehir;
            cr.CariMail= p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();

            ViewBag.CariAdi = cr;

            return View(degerler);
        }
    }
}