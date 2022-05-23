using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proiect.Entities.Auth;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<User> _userManager;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.User.GetAllUsers();

            return Ok(new { users });
        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeEmail(int id)
        {
            try
            {
                var y = _repository.User.FirstOrDefaultAsync(u => u.Email.Equals(email));
                await _repository.SaveAsync();
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
        */
        
        
    }
}
