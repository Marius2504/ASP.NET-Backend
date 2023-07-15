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

        [HttpPut("/changeEmail")]
        public async Task<IActionResult> ChangeEmail([FromBody]User user)
        {
            try
            {
                var foundUser = await _repository.User.GetByIdAsync(user.Id);
                if (foundUser != null)
                {
                    if (foundUser.Name == user.Name &&
                        foundUser.Email == user.Email) 
                        {
                            _repository.User.Update(user);
                            await _repository.SaveAsync();
                            return NoContent();
                        }
                    return NotFound("You can only change the email");
                }
                return NotFound("User doesn't exist");
            }
            catch
            {
                return NotFound();
            }
        }  
        
    }
}
