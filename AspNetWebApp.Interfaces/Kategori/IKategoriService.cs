using System;
using System.Linq;

namespace AspNetWebApp.Interfaces.Kategori
{
    public interface IKategoriService : IGenericService<Entities.Models.Siniflar.Kategori>
    {
        IQueryable KategoriRaporu(DateTime baslangic,DateTime bitis);
    }
}