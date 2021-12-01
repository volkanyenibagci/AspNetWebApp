using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AspNetWebApp.Entities.Models.Siniflar;

namespace AspNetWebApp.Dal.Abstract.KategoriDal
{
    public interface IKategoriDal
    {
        Kategori Kaydet(Kategori entity);
        
        List<Kategori> Listele();

        List<Kategori> Listele(Expression<Func<Kategori,bool>> predicate);
        
        Kategori Getir(int id);
        
        int Guncelle(Kategori entity);

        bool Sil(int id);
        
        bool Sil(Kategori entity);
        
        IQueryable KategoriRaporu(DateTime baslangic,DateTime bitis);
    }
}