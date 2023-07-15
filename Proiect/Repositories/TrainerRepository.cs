using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Entities.DTOs;
using Proiect.Models;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
       // protected AppDbContext _context;
        public TrainerRepository(AppDbContext context) : base(context) 
        {
          //  _context = context;
        }

        public override async Task<Trainer> GetByIdAsync(int id)
        {
            var ret = await _context.Trainers.Include(t => t.Clients).Include(t => t.TrainerGyms).ThenInclude(tg => tg.Gym).ThenInclude(g => g.Address).FirstOrDefaultAsync(trainer => trainer.Id == id);
            return ret;
        }
        
        public override ICollection<Trainer> GetAll()
        {
            return _context.Trainers.Include(t =>t.Clients).Include(t=>t.TrainerGyms).ThenInclude(tg=>tg.Gym).ThenInclude(_g => _g.Address).ToList();
        }
        

        public IQueryable<dynamic> GetAllGroupByAge()
        {
            var li = _context.Trainers.GroupBy(a => a.Age).Select(b=> new { Age = b.Key, Number = b.Count() });
            //IEnumerable<Antrenor> ant = li.SelectMany(group => group);
            return li;
        }
        public IQueryable<dynamic> GetAllAccountTrainers()
        {
            //Query Syntax
            var entryPoint = (from trainer in _context.Trainers
                              join user in _context.Users on trainer.Id equals user.Id
                              where trainer.Name == user.Name
                              select new 
                              {
                                  trainer.Id,
                                  trainer.Age,
                                  trainer.PhoneNumber,
                                  trainer.Name,
                                  trainer.Email,
                                  trainer.Options
                              });

            /* ------ Same code Method Syntax
            var list = _context.Trainers.ToList().Join(_context.Users.ToList(), 
                trainer => new { trainer.Id, trainer.Name}, 
                user =>new { user.Id,Name = user.FirstName},
                (trainer,user) => new
                {
                    trainer.Id,
                    trainer.Age,
                    trainer.PhoneNumber,
                    trainer.Name,
                    trainer.Email,
                    trainer.Options
                });
            */                                
            return entryPoint;
        }

        public async Task<Trainer> GetById(int id)
        {
            return await _context.Trainers.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Trainer> GetByName(string name)
        {
            return await _context.Trainers.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public IQueryable<Trainer> GetFirst(int nr)
        {
            return _context.Trainers.Take(nr);
        }

        
    }
}
