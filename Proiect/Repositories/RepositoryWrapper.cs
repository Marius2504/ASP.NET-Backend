using Proiect.Models;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionTokenRepository;
        public RepositoryWrapper(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }
        
        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionTokenRepository == null) _sessionTokenRepository = new SessionTokenRepository(_context);
                return _sessionTokenRepository;
            }
        }
        
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
