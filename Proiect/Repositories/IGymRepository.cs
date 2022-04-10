using Proiect.Entities;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public interface IGymRepository:IGenericRepository<Gym>
    {
        Task<Gym> GetRecenziiByName(string name);
        Task<List<Gym>> GetGymWithAdress(string name);
    }
}
