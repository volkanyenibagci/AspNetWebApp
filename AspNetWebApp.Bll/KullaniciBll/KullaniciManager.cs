using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AspNetWebApp.Dal.Abstract.KullaniciDal;
using AspNetWebApp.Entities.Models.Siniflar;
using AspNetWebApp.Interfaces.Kullanici;

namespace AspNetWebApp.Bll.KullaniciBll
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            this._kullaniciDal = kullaniciDal;
        }
        
        public Admin Kaydet(Admin entity)
        {
            return _kullaniciDal.Kaydet(entity);
        }

        public List<Admin> Listele()
        {
            return _kullaniciDal.Listele();
        }

        public List<Admin> Listele(Expression<Func<Admin, bool>> predicate)
        {
            return _kullaniciDal.Listele(predicate);
        }

        public Admin Getir(int id)
        {
            return _kullaniciDal.Getir(id);
        }

        public int Guncelle(Admin entity)
        {
            return _kullaniciDal.Guncelle(entity);
        }

        public bool Sil(int id)
        {
            return _kullaniciDal.Sil(id);
        }

        public bool Sil(Admin entity)
        {
            return _kullaniciDal.Sil(entity);
        }

        public Admin KullaniciGiris(string KullaniciAdi, string parola)
        {
            try
            {
                if (string.IsNullOrEmpty(KullaniciAdi.Trim()) || string.IsNullOrEmpty(parola.Trim()))
                {
                    throw new Exception("Kullanıcı Adı veya parola boş geçilemez");
                }

                /*
                var sifre = new ToPasswordRepository().Md5(parola);
                */
                var kullanici=_kullaniciDal.KullaniciGiris(KullaniciAdi, parola);
                if (kullanici==null)
                {
                    throw new Exception("Kullanıcı ve parola uyuşmuyor");
                }
                else
                {
                    return kullanici;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Kullanıcı giriş hata" + e.Message);
            }
        }
    }
}