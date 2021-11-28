using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AspNetWebApp.Dal.Abstract.DepartmanDal;
using AspNetWebApp.Dal.Concrete.EntityFramework.Repository;
using AspNetWebApp.Interfaces.Departman;
using AspNetWebApp.Entities.Models.Siniflar;

namespace AspNetWebApp.Bll.DepartmanBll
{
    public class DepartmanManager : IDepartmanService
    {
        private IDepartmanDal _departmanDal;

        public DepartmanManager(IDepartmanDal departmanDal)
        {
            this._departmanDal = departmanDal;
        }
        
        public Departman Kaydet(Departman entity)
        {
            return _departmanDal.Kaydet(entity);
        }

        public List<Departman> Listele()
        {
            return _departmanDal.Listele();
        }

        public List<Departman> Listele(Expression<Func<Departman, bool>> predicate)
        {
            return _departmanDal.Listele(predicate);
        }

        public Departman Getir(int id)
        {
            return _departmanDal.Getir(id);
        }

        public int Guncelle(Departman entity)
        {
            return _departmanDal.Guncelle(entity);
        }

        public bool Sil(int id)
        {
            return _departmanDal.Sil(id);
        }

        public bool Sil(Departman entity)
        {
            return _departmanDal.Sil(entity);
        }
    }
}