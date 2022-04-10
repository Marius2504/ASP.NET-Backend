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
    public class AntrenorRepository : GenericRepository<Antrenor>, IAntrenorRepository
    {
        public AntrenorRepository(AppDbContext context): base(context) { }

        public async Task<Antrenor> GetById(int id)
        {
            return await _context.Antrenors.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Antrenor> GetByName(string name)
        {
            return await _context.Antrenors.Where(a => a.Nume.Equals(name)).FirstOrDefaultAsync();
        }

        
    }
}
