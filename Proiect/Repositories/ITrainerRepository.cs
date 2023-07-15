using Proiect.Entities;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        Task<Trainer> GetByName(string name);
        Task<Trainer> GetById(int id);
        IQueryable<Trainer> GetFirst(int nr);
        IQueryable<dynamic> GetAllGroupByAge();
        IQueryable<dynamic> GetAllAccountTrainers();


    }
}
