using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AspNetWebApp.Entities.Models.Siniflar;

namespace AspNetWebApp.Dal.Abstract.KullaniciDal
{
    public interface IKullaniciDal
    {
        Admin Kaydet(Admin entity);
        
        List<Admin> Listele();

        List<Admin> Listele(Expression<Func<Admin,bool>> predicate);
        
        Admin Getir(int id);
        
        int Guncelle(Admin entity);

        bool Sil(int id);
        
        bool Sil(Admin entity);
        
        Admin KullaniciGiris(string KullaniciAdi, string sifre);


    }
}