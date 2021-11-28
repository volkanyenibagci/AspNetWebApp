using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using AspNetWebApp.Dal.Abstract.DepartmanDal;
using AspNetWebApp.Entities.Models.Siniflar;
using AspNetWebApp.Dal.Concrete.EntityFramework.Context;

namespace AspNetWebApp.Dal.Concrete.EntityFramework.Repository
{
    public class EfDepartmanRepository : IDepartmanDal
    {
        private AspNetWebAppContext context = new AspNetWebAppContext();
        
        public Departman Kaydet(Departman entity)
        {
            context.Departmans.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Departman> Listele()
        {
            return context.Departmans.AsNoTracking().ToList();
        }

        public List<Departman> Listele(Expression<Func<Departman, bool>> predicate)
        {
            return context.Departmans.Where(predicate).ToList();
        }

        public Departman Getir(int id)
        {
            return context.Departmans.AsNoTracking().Where(x => x.DepartmanID == id).SingleOrDefault();
        }

        public int Guncelle(Departman entity)
        {
            context.Departmans.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public bool Sil(int id)
        {
            var departman = Getir(id);
            return Sil(departman);
        }

        public bool Sil(Departman entity)
        {
            context.Departmans.Remove(entity);
            return context.SaveChanges()>0;
        }
    }
}