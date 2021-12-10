using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AspNetWebApp.Dal.Abstract.UrunDal;
using AspNetWebApp.Dal.Concrete.EntityFramework.Context;
using AspNetWebApp.Entities.Models.Siniflar;

namespace AspNetWebApp.Dal.Concrete.EntityFramework.Repository
{
    public class EfUrunRepository : IUrunRepository, IDisposable
    {
        private  AspNetWebAppContext _aspNetWebAppContext;
        
        public EfUrunRepository(AspNetWebAppContext aspNetWebAppContext)
        {
            this._aspNetWebAppContext = aspNetWebAppContext;
        }
       

        public IEnumerable<Urun> GetUruns()
        {
            return _aspNetWebAppContext.Uruns.ToList(); 
        }

        public Urun GetUrunByID(int urunId)
        {
            return _aspNetWebAppContext.Uruns.Find(urunId);
        }

        public void InsertUrun(Urun urun)
        {
            _aspNetWebAppContext.Uruns.Add(urun);
        }

        public void DeleteUrun(int urunId)
        {
            Urun urun = _aspNetWebAppContext.Uruns.Find(urunId);  
            _aspNetWebAppContext.Uruns.Remove(urun);
        }

        public void UpdateUrun(Urun urun)
        {
            _aspNetWebAppContext.Entry(urun).State = EntityState.Modified; 
        }

        public void Save()
        {
            _aspNetWebAppContext.SaveChanges(); 
        }
        
        private bool disposed = false;  

        protected virtual void Dispose(bool disposing)  
        {  
            if (!this.disposed)  
            {  
                if (disposing)  
                {  
                    _aspNetWebAppContext.Dispose();  
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