using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AspNetWebApp.Models.Siniflar;

namespace DAL
{
    public class UrunRepository : IUrunRepository  
    {  
        private Context _context;  
        public UrunRepository(Context urunContext)  
        {  
            this._context = urunContext;  
        }  
        public IEnumerable<Urun> GetUruns()  
        {  
            return _context.Uruns.ToList();  
        }
        public Urun GetUrunByID(int id)  
        {  
            return _context.Uruns.Find(id);  
        }  
        public void InsertUrun(Urun urun)  
        {  
            _context.Uruns.Add(urun);  
        }  
        public void DeleteUrun(int urunID)  
        {  
            Urun urun = _context.Uruns.Find(urunID);  
            _context.Uruns.Remove(urun);  
        }  
        public void UpdateUrun(Urun urun)  
        {  
            _context.Entry(urun).State = EntityState.Modified;  
        }  
        public void Save()  
        {  
            _context.SaveChanges();  
        }  
        private bool disposed = false;  
        protected virtual void Dispose(bool disposing)  
        {  
            if (!this.disposed)  
            {  
                if (disposing)  
                {  
                    _context.Dispose();  
                }  
            }  
            this.disposed = true;  
        }  
        public void Dispose()  
        {  
            Dispose(true);  
            GC.SuppressFinalize(this);  
        }  
    }  
}