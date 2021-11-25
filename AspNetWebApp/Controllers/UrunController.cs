using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using AspNetWebApp.Models.Siniflar;

namespace AspNetWebApp.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        private readonly IUrunRepository _urunRepository;  
        public UrunController()  
        {  
            _urunRepository = new UrunRepository(new Context()); 
        }  
        public ActionResult Index()
        {
            /*var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);*/
            
            var urunler=_urunRepository.GetUruns();
            return View(urunler);        }

        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            if (ModelState.IsValid)
            {
                _urunRepository.InsertUrun(p);
                _urunRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
            /*c.Uruns.Add(p);
            c.SaveChanges();*/
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urunDeger = c.Uruns.Find(id);
            return View("UrunGetir", urunDeger);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            _urunRepository.UpdateUrun(p);
            _urunRepository.Save();
            // var urn = c.Uruns.Find(p.UrunID);
            // urn.AlisFiyati = p.AlisFiyati;
            // urn.Durum = p.Durum;
            // urn.KategoriId = p.KategoriId;
            // urn.Marka = p.Marka;
            // urn.SatisFİyati = p.SatisFİyati;
            // urn.Stok = p.Stok;
            // urn.UrunAd = p.UrunAd;
            // urn.UrunGorsel = p.UrunGorsel;
            // c.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}