using System;
using System.Collections.Generic;
using AspNetWebApp.Models.Siniflar;

namespace DAL
{
    public interface IUrunRepository : IDisposable
    {
        IEnumerable<Urun> GetUruns();  
        Urun GetUrunByID(int urunId);  
        void InsertUrun(Urun book);  
        void DeleteUrun(int urunID);  
        void UpdateUrun(Urun urun);  
        void Save(); 
    }
}