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
        private AspNetWebAppContext context = new AspNetWebAppContext();
        
        public Admin Kaydet(Admin entity)
        {
            context.Admins.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Admin> Listele()
        {
            return context.Admins.AsNoTracking().ToList();
        }

        public List<Admin> Listele(Expression<Func<Admin, bool>> predicate)
        {
            return context.Admins.Where(predicate).ToList();
        }

        public Admin Getir(int id)
        {
            return context.Admins.AsNoTracking().Where(x => x.AdminID == id).SingleOrDefault();
        }

        public int Guncelle(Admin entity)
        {
            context.Admins.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public bool Sil(int id)
        {
            var admin = Getir(id);
            return Sil(admin);
        }

        public Admin KullaniciGiris(string KullaniciAdi, string sifre)
        {
            return context.Admins.Where(x=>x.KullaniciAd==KullaniciAdi && x.Sifre==sifre).SingleOrDefault();
        }

        public bool Sil(Admin entity)
        {
            context.Admins.Remove(entity);
            return context.SaveChanges()>0;
        }
    }
}