using Proiect.Entities;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface IAntrenorRepository : IGenericRepository<Antrenor>
    {
        Task<Antrenor> GetByName(string name);
        Task<Antrenor> GetById(int id);
        IQueryable<Antrenor> GetFirst(int nr);
        IQueryable<dynamic> GetAllGroupByAge();
       
    }
}
