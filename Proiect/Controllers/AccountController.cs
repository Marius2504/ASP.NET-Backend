﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proiect.Entities.Auth;
using Proiect.Entities.DTOs;
using Proiect.Models.Constants;
using Proiect.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        public AccountController(
            UserManager<User> userManager,
           IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }
        [HttpPost("register")]
        [AllowAnonymous]

        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {

            var exists = await _userManager.FindByEmailAsync(dto.Email);
            if (exists != null)
            {
                return BadRequest("User already registered!");
            }
                      
            var result = await _userService.RegisterUserAsync(dto);

            if (result == "success")
            {
                return Ok(result);
            }
            

            return BadRequest(result);
        }
        
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);

            if (token == "")
            {
                return BadRequest("User or password doesn't exist");
            }
            return Ok(new { token });
        }
    }
}
