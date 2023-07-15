using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class RegisterUserDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool isTrainer { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
