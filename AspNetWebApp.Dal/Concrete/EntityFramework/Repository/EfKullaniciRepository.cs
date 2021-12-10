using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using AspNetWebApp.Dal.Abstract.KullaniciDal;
using AspNetWebApp.Entities.Models.Siniflar;
using AspNetWebApp.Dal.Concrete.EntityFramework.Context;

namespace AspNetWebApp.Dal.Concrete.EntityFramework.Repository
{
    public class EfKullaniciRepository : IKullaniciDal
    {
        /*
        private AspNetWebAppContext context = new AspNetWebAppContext();
        */
        AspNetWebAppContext _context = new AspNetWebAppContext();
        
        public EfKullaniciRepository(AspNetWebAppContext aspNetWebAppContext)
        {
            this._context = aspNetWebAppContext;
        }
        public Admin Kaydet(Admin entity)
        {
            _context.Admins.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<Admin> Listele()
        {
            return _context.Admins.AsNoTracking().ToList();
        }

        public List<Admin> Listele(Expression<Func<Admin, bool>> predicate)
        {
            return _context.Admins.Where(predicate).ToList();
        }

        public Admin Getir(int id)
        {
            return _context.Admins.AsNoTracking().Where(x => x.AdminID == id).SingleOrDefault();
        }

        public int Guncelle(Admin entity)
        {
            _context.Admins.AddOrUpdate(entity);
            return _context.SaveChanges();
        }

        public bool Sil(int id)
        {
            var admin = Getir(id);
            return Sil(admin);
        }

        public Admin KullaniciGiris(string KullaniciAdi, string sifre)
        {
            try
            {
                var bilgiler = _context.Admins.FirstOrDefault(x => x.KullaniciAd == KullaniciAdi && x.Sifre == sifre);
                return _context.Admins.Where(x=>x.KullaniciAd==KullaniciAdi && x.Sifre==sifre).SingleOrDefault();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Sil(Admin entity)
        {
            _context.Admins.Remove(entity);
            return _context.SaveChanges()>0;
        }
    }
}