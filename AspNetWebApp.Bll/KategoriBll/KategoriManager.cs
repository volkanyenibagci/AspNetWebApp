using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AspNetWebApp.Dal.Abstract.KategoriDal;
using AspNetWebApp.Entities.Models.Siniflar;
using AspNetWebApp.Interfaces.Kategori;

namespace AspNetWebApp.Bll.KategoriBll
{
    public class KategoriManager : IKategoriService
    {
        private IKategoriDal _kategoriDal;

        public KategoriManager(IKategoriDal kategoriDal)
        {
            this._kategoriDal = kategoriDal;
        }
        
        
        public Kategori Kaydet(Kategori entity)
        {
            throw new NotImplementedException();
        }

        public List<Kategori> Listele()
        {
            throw new NotImplementedException();
        }

        public List<Kategori> Listele(Expression<Func<Kategori, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Kategori Getir(int id)
        {
            
            return _kategoriDal.Getir(id);
        }

        public int Guncelle(Kategori entity)
        {
            return _kategoriDal.Guncelle(entity);
        }

        public bool Sil(int id)
        {
            throw new NotImplementedException();
        }

        public bool Sil(Kategori entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable KategoriRaporu(DateTime baslangic, DateTime bitis)
        {
            return _kategoriDal.KategoriRaporu(baslangic, bitis);
        }

       
    }
}