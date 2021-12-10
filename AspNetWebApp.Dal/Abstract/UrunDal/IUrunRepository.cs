using System;
using System.Collections;
using System.Collections.Generic;
using AspNetWebApp.Entities.Models.Siniflar;

namespace AspNetWebApp.Dal.Abstract.UrunDal
{
    public interface IUrunRepository : IDisposable
    {
        IEnumerable<Urun> GetUruns();
        Urun GetUrunByID(int urunId);
        void InsertUrun(Urun urun);
        void DeleteUrun(int urunId);
        void UpdateUrun(Urun urun);
        void Save();
        
    }
}