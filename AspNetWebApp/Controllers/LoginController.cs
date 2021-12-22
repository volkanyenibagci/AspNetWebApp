using System;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using AspNetWebApp.Dal.Abstract.KullaniciDal;
using AspNetWebApp.Dal.Concrete.EntityFramework.Context;
using AspNetWebApp.Dal.Concrete.EntityFramework.Repository;
using AspNetWebApp.Models.Siniflar;

namespace AspNetWebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        /*
        private IKullaniciService _kullaniciService = new KullaniciManager(new EfKullaniciRepository());
        */
        /*Context c = new Context();*/
        private IKullaniciDal _kullaniciDal;
        
        public LoginController()  
        {  
            this._kullaniciDal = new EfKullaniciRepository(new AspNetWebAppContext());
        }

        public LoginController(IKullaniciDal kullaniciDal)
        {
            this._kullaniciDal = kullaniciDal;
        }
        
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
            
            
           

            /*try
            {
              
                var _kullanici=_kullaniciService.KullaniciGiris(a.KullaniciAd, a.Sifre);
                if (_kullanici!=null)
                {
                    FormsAuthentication.SetAuthCookie(_kullanici.KullaniciAd,false);
                    Session["AdminKullaniciAdi"] = _kullanici.KullaniciAd.ToString();
                    return RedirectToAction("Anasayfa", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }*/


            try
            {
                var bilgiler = _kullaniciDal.Listele().FirstOrDefault(x=>x.KullaniciAd==a.KullaniciAd&&x.Sifre==a.Sifre);

                if (bilgiler!=null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd,false);
                    Session["AdminKullaniciAdi"] = bilgiler.KullaniciAd.ToString();

                    try
                    {
                        return RedirectToAction("Anasayfa", "Home");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        string HataMesaj = e.Message;
                        throw;
                    }
                    
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
            
            
        }
    }
}