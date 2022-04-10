using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Models;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class GymRepository : GenericRepository<Gym>, IGymRepository
    {
        public GymRepository(AppDbContext context) : base(context) { }
        public async Task<List<Gym>> GetGymWithAdress(string name)
        {
            return await _context.Gyms.Include(a => a.Adresas).ToListAsync();
        }

        public async Task<Gym> GetRecenziiByName(string name)
        {
            return await _context.Gyms.Where(a => a.Nume.Equals(name)).FirstOrDefaultAsync(); 
        }
    }
}
