using AspNetWebApp.Entities.Models.Siniflar;

namespace AspNetWebApp.Interfaces.Kullanici
{
    public interface IKullaniciService:IGenericService<Admin>
    {
        Admin KullaniciGiris(string KullaniciAdi, string parola);
    }
}