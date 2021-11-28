using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AspNetWebApp.Entities.Models.Siniflar;

namespace AspNetWebApp.Dal.Abstract.DepartmanDal
{
    public interface IDepartmanDal
    {
        Departman Kaydet(Departman entity);
        
        List<Departman> Listele();

        List<Departman> Listele(Expression<Func<Departman,bool>> predicate);
        
        Departman Getir(int id);
        
        int Guncelle(Departman entity);

        bool Sil(int id);
        
        bool Sil(Departman entity);


    }
}