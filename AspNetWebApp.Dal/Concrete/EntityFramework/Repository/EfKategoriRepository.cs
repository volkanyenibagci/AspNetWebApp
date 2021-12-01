using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using AspNetWebApp.Dal.Abstract.KategoriDal;
using AspNetWebApp.Dal.Concrete.EntityFramework.Context;
using AspNetWebApp.Entities.Models.Siniflar;

namespace AspNetWebApp.Dal.Concrete.EntityFramework.Repository
{
    public class EfKategoriRepository : IKategoriDal
    {
        private AspNetWebAppContext context = new AspNetWebAppContext();

        
        public Kategori Kaydet(Kategori entity)
        {
            context.Kategoris.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Kategori> Listele()
        {
            return context.Kategoris.AsNoTracking().ToList();
        }

        public List<Kategori> Listele(Expression<Func<Kategori, bool>> predicate)
        {
            return context.Kategoris.Where(predicate).ToList();
        }

        public Kategori Getir(int id)
        {
            return context.Kategoris.AsNoTracking().Where(x => x.KategoriID == id).SingleOrDefault();
        }

        public int Guncelle(Kategori entity)
        {
            context.Kategoris.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public bool Sil(int id)
        {
            var kategori = Getir(id);
            return Sil(kategori);
        }

        public bool Sil(Kategori entity)
        {
            context.Kategoris.Remove(entity);
            return context.SaveChanges()>0;
        }

        public IQueryable KategoriRaporu(DateTime baslangic, DateTime bitis)
        {
            throw new NotImplementedException();
        }
    }
}